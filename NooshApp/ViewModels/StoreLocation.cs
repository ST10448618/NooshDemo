namespace NooshApp.ViewModels
{
    /// <summary>
    /// Represents one physical Noosh store location.
    /// Static config data — no admin editing requirement, so no DB table needed.
    /// </summary>
    public class StoreLocation
    {
        public string Name { get; set; } = string.Empty;
        public string MallName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string WhatsAppNumber { get; set; } = string.Empty;
        public string OpeningHours { get; set; } = string.Empty;
        public string GoogleMapsUrl { get; set; } = string.Empty;
        public string MapEmbedUrl { get; set; } = string.Empty;
        public string DirectionsUrl =>
            $"https://www.google.com/maps/dir/?api=1&destination={Uri.EscapeDataString(Address)}";
    }
}