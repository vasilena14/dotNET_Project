namespace DataAccess.Migrations
{
    using DataStructure;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.MotoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataAccess.MotoContext context)
        {
            context.Categories.AddOrUpdate(category => category.ID,
                new Category() { Title = "Sport", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Category() { Title = "Supermoto", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Category() { Title = "Enduro", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Category() { Title = "Touring", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Category() { Title = "Adventure", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Category() { Title = "Cruiser", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
            );

            context.Brands.AddOrUpdate(brand => brand.ID,
                new Brand() { Name = "KTM", Country = "Austria", Founded = 1934, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Brand() { Name = "Honda", Country = "Japan", Founded = 1948, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Brand() { Name = "Husqvarna", Country = "Sweden", Founded = 1903, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Brand() { Name = "Yamaha", Country = "Japan", Founded = 1955, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Brand() { Name = "Triumph", Country = "England", Founded = 1984, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Brand() { Name = "BMW", Country = "Germany", Founded = 1916, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
            );

            context.Engines.AddOrUpdate(engine => engine.ID,
                new Engine() { Type = "four-stroke", Cylinders = "parallel-twin", CoolingSystem = "liquid-cooled", Capacity = 471, Horsepower = 45.9, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Engine() { Type = "four-stroke", Cylinders = "in-line three", CoolingSystem = "liquid-cooled", Capacity = 800, Horsepower = 93.9, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Engine() { Type = "four-stroke", Cylinders = "transverse three", CoolingSystem = "liquid-cooled", Capacity = 847, Horsepower = 114, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Engine() { Type = "two-stroke", Cylinders = "single", CoolingSystem = "liquid-cooled", Capacity = 249, Horsepower = 49.77, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Engine() { Type = "four-stroke", Cylinders = "single", CoolingSystem = "liquid-cooled", Capacity = 690, Horsepower = 72, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Engine() { Type = "four-stroke", Cylinders = "transverse four", CoolingSystem = "liquid-cooled", Capacity = 999, Horsepower = 207, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
            );
        }
    }
}
