using NooshApp.Models;

namespace NooshApp.Data
{
    /// <summary>
    /// Populates the database with starter data on first run.
    /// Safe to call every startup — each dataset checks independently
    /// so partially-seeded databases still get the missing pieces.
    /// </summary>
    public static class DbSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.MenuItems.Any())
            {
                SeedMenuItems(context);
            }

            if (!context.RewardMilestones.Any())
            {
                SeedRewardMilestones(context);
            }
        }

        private static void SeedMenuItems(ApplicationDbContext context)
        {
            var items = new List<MenuItem>
            {
                // ---------- Shawarma Wraps ----------
                new MenuItem
                {
                    Name = "Chicken Wrap",
                    Description = "Grilled chicken, onions, tomatoes, pickles, fried brinjal, cabbage, lettuce, cheese and fries.",
                    Price = 80.00m,
                    Category = "Shawarma Wraps",
                    ImageUrl = "/images/menu/chicken-wrap.jpg",
                    IsPopular = true,
                    IsVegetarian = false,
                    SpiceLevel = SpiceLevel.Mild
                },
                new MenuItem
                {
                    Name = "Beef Wrap",
                    Description = "Slow-cooked beef, onions, tomatoes, pickles, fried brinjal, cabbage, lettuce, cheese and fries.",
                    Price = 90.00m,
                    Category = "Shawarma Wraps",
                    ImageUrl = "/images/menu/beef-wrap.jpg",
                    IsPopular = true,
                    IsVegetarian = false,
                    SpiceLevel = SpiceLevel.Mild
                },
                new MenuItem
                {
                    Name = "Falafel Wrap",
                    Description = "Crispy falafel, onions, tomatoes, pickles, fried brinjal, cabbage, lettuce, cheese and fries.",
                    Price = 80.00m,
                    Category = "Shawarma Wraps",
                    ImageUrl = "/images/menu/falafel-wrap.jpg",
                    IsPopular = true,
                    IsVegetarian = true,
                    SpiceLevel = SpiceLevel.Medium
                },
                new MenuItem
                {
                    Name = "Chip Wrap",
                    Description = "Crispy fries, onions, tomatoes, pickles, fried brinjal, cabbage, lettuce and cheese, wrapped fresh.",
                    Price = 55.00m,
                    Category = "Shawarma Wraps",
                    ImageUrl = "/images/menu/chip-wrap.jpg",
                    IsPopular = false,
                    IsVegetarian = true,
                    SpiceLevel = SpiceLevel.None
                },

                // ---------- Shawarma Bowls ----------
                new MenuItem
                {
                    Name = "Chicken Bowl",
                    Description = "Grilled chicken on your choice of rice, fries, or half & half, loaded with all the fixings.",
                    Price = 110.00m,
                    Category = "Shawarma Bowls",
                    ImageUrl = "/images/menu/chicken-bowl.jpg",
                    IsPopular = true,
                    IsVegetarian = false,
                    SpiceLevel = SpiceLevel.Mild
                },
                new MenuItem
                {
                    Name = "Beef Bowl",
                    Description = "Slow-cooked beef on your choice of rice, fries, or half & half, loaded with all the fixings.",
                    Price = 120.00m,
                    Category = "Shawarma Bowls",
                    ImageUrl = "/images/menu/beef-bowl.jpg",
                    IsPopular = false,
                    IsVegetarian = false,
                    SpiceLevel = SpiceLevel.Mild
                },
                new MenuItem
                {
                    Name = "Falafel Bowl",
                    Description = "Crispy falafel on your choice of rice, fries, or half & half, loaded with all the fixings.",
                    Price = 110.00m,
                    Category = "Shawarma Bowls",
                    ImageUrl = "/images/menu/falafel-bowl.jpg",
                    IsPopular = false,
                    IsVegetarian = true,
                    SpiceLevel = SpiceLevel.Medium
                },

                // ---------- Loaded Cheesy Fries ----------
                new MenuItem
                {
                    Name = "Chilli Cheese Fries",
                    Description = "Loaded fries topped with melted cheese, guacamole, sour cream and crushed nachos.",
                    Price = 60.00m,
                    Category = "Loaded Cheesy Fries",
                    ImageUrl = "/images/menu/chilli-cheese-fries.jpg",
                    IsPopular = true,
                    IsVegetarian = true,
                    SpiceLevel = SpiceLevel.Medium
                },
                new MenuItem
                {
                    Name = "Chilli Cheese Fries — Chicken",
                    Description = "Loaded fries topped with grilled chicken, melted cheese, guacamole, sour cream and crushed nachos.",
                    Price = 80.00m,
                    Category = "Loaded Cheesy Fries",
                    ImageUrl = "/images/menu/chilli-cheese-fries-chicken.jpg",
                    IsPopular = false,
                    IsVegetarian = false,
                    SpiceLevel = SpiceLevel.Medium
                },
                new MenuItem
                {
                    Name = "Chilli Cheese Fries — Beef",
                    Description = "Loaded fries topped with slow-cooked beef, melted cheese, guacamole, sour cream and crushed nachos.",
                    Price = 100.00m,
                    Category = "Loaded Cheesy Fries",
                    ImageUrl = "/images/menu/chilli-cheese-fries-beef.jpg",
                    IsPopular = false,
                    IsVegetarian = false,
                    SpiceLevel = SpiceLevel.Medium
                },

                // ---------- Fries ----------
                new MenuItem
                {
                    Name = "Medium Fries",
                    Description = "Crispy golden fries.",
                    Price = 25.00m,
                    Category = "Fries",
                    ImageUrl = "/images/menu/fries-medium.jpg",
                    IsVegetarian = true,
                    SpiceLevel = SpiceLevel.None
                },
                new MenuItem
                {
                    Name = "Medium Saucy Fries",
                    Description = "Crispy fries drizzled with garlic sauce and peri peri.",
                    Price = 30.00m,
                    Category = "Fries",
                    ImageUrl = "/images/menu/fries-medium-saucy.jpg",
                    IsVegetarian = true,
                    SpiceLevel = SpiceLevel.Mild
                },
                new MenuItem
                {
                    Name = "Large Fries",
                    Description = "Crispy golden fries.",
                    Price = 45.00m,
                    Category = "Fries",
                    ImageUrl = "/images/menu/fries-large.jpg",
                    IsVegetarian = true,
                    SpiceLevel = SpiceLevel.None
                },
                new MenuItem
                {
                    Name = "Large Saucy Fries",
                    Description = "Crispy fries drizzled with garlic sauce and peri peri.",
                    Price = 55.00m,
                    Category = "Fries",
                    ImageUrl = "/images/menu/fries-large-saucy.jpg",
                    IsVegetarian = true,
                    SpiceLevel = SpiceLevel.Mild
                },

                // ---------- Sauce Tubs ----------
                new MenuItem
                {
                    Name = "Noosh Chilli Paste",
                    Description = "Our signature house-made chilli paste.",
                    Price = 10.00m,
                    Category = "Sauce Tubs",
                    ImageUrl = "/images/menu/sauce-chilli-paste.jpg",
                    IsVegetarian = true,
                    SpiceLevel = SpiceLevel.ExtraHot
                },
                new MenuItem
                {
                    Name = "Noosh Garlic Sauce",
                    Description = "Creamy house garlic sauce.",
                    Price = 10.00m,
                    Category = "Sauce Tubs",
                    ImageUrl = "/images/menu/sauce-garlic.jpg",
                    IsVegetarian = true,
                    SpiceLevel = SpiceLevel.None
                },
                new MenuItem
                {
                    Name = "Noosh Peri Peri",
                    Description = "Fiery house peri peri sauce.",
                    Price = 10.00m,
                    Category = "Sauce Tubs",
                    ImageUrl = "/images/menu/sauce-peri-peri.jpg",
                    IsVegetarian = true,
                    SpiceLevel = SpiceLevel.Hot
                },

                // ---------- Kids Meal ----------
                new MenuItem
                {
                    Name = "Noosh Kids Meal",
                    Description = "2 x Chicken Nooshie Wraps, crispy fries, a sauce tub, juice and a fun activity.",
                    Price = 75.00m,
                    Category = "Kids Meal",
                    ImageUrl = "/images/menu/kids-meal.jpg",
                    IsPopular = true,
                    IsVegetarian = false,
                    SpiceLevel = SpiceLevel.None
                }
            };

            context.MenuItems.AddRange(items);
            context.SaveChanges();
        }

        private static void SeedRewardMilestones(ApplicationDbContext context)
        {
            var milestones = new List<RewardMilestone>
            {
                new RewardMilestone { PointsRequired = 300, RewardName = "Free Fries", DisplayOrder = 1 },
                new RewardMilestone { PointsRequired = 600, RewardName = "Half Price Meal", DisplayOrder = 2 },
                new RewardMilestone { PointsRequired = 1000, RewardName = "Free Combo Deal", DisplayOrder = 3 }
            };

            context.RewardMilestones.AddRange(milestones);
            context.SaveChanges();
        }
    }
}