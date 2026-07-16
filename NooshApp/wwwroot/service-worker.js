// Service Worker for NOOSH PWA.
// Handles install-time caching, activation cleanup, and fetch interception
// for offline support.

const CACHE_VERSION = 'noosh-cache-v1';

// Core assets needed for the app shell to work offline.
// Keep this list focused — cache what's needed for basic navigation,
// not every possible page (dynamic pages like Menu/Rewards need live data anyway).
const CORE_ASSETS = [
    '/',
    '/offline.html',
    '/css/site.css',
    '/js/site.js',
    '/lib/bootstrap/dist/css/bootstrap.min.css',
    '/lib/bootstrap/dist/js/bootstrap.bundle.min.js',
    '/images/icons/icon-192.png',
    '/images/icons/icon-512.png'
];

// --- INSTALL: runs once when the service worker is first registered ---
self.addEventListener('install', function (event) {
    event.waitUntil(
        caches.open(CACHE_VERSION).then(function (cache) {
            return cache.addAll(CORE_ASSETS);
        })
    );

    // Activate this new service worker immediately, without waiting
    // for old tabs using a previous version to close.
    self.skipWaiting();
});

// --- ACTIVATE: runs after install, good place to clean up old caches ---
self.addEventListener('activate', function (event) {
    event.waitUntil(
        caches.keys().then(function (cacheNames) {
            return Promise.all(
                cacheNames
                    .filter(function (name) {
                        return name !== CACHE_VERSION; // remove any cache from a previous version
                    })
                    .map(function (name) {
                        return caches.delete(name);
                    })
            );
        })
    );

    self.clients.claim();
});

// --- FETCH: intercepts every network request the page makes ---
self.addEventListener('fetch', function (event) {
    const request = event.request;

    // Only handle GET requests — never cache POST (form submissions, logins, etc.)
    if (request.method !== 'GET') {
        return;
    }

    // Strategy: Network-first for page navigations (HTML documents),
    // so users always see live content when online, but get a graceful
    // offline page instead of a browser error when they're not.
    if (request.mode === 'navigate') {
        event.respondWith(
            fetch(request).catch(function () {
                return caches.match('/offline.html');
            })
        );
        return;
    }

    // Strategy: Cache-first for static assets (CSS, JS, images) —
    // these rarely change and loading from cache is instant.
    event.respondWith(
        caches.match(request).then(function (cachedResponse) {
            if (cachedResponse) {
                return cachedResponse;
            }

            return fetch(request).then(function (networkResponse) {
                // Cache successful responses for next time, but only
                // for same-origin requests (don't cache third-party CDN calls
                // like Font Awesome/Google Fonts indefinitely without control).
                if (networkResponse.ok && request.url.startsWith(self.location.origin)) {
                    return caches.open(CACHE_VERSION).then(function (cache) {
                        cache.put(request, networkResponse.clone());
                        return networkResponse;
                    });
                }

                return networkResponse;
            }).catch(function () {
                // Network failed and nothing cached — nothing more we can do
                // for this particular asset (e.g. an image), so this may 404
                // gracefully in the browser depending on the resource type.
            });
        })
    );
});