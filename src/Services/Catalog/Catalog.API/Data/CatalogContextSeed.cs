
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<CatalogCategory> catalogCategories,
            IMongoCollection<CatalogBrand> catalogBrands,
            IMongoCollection<CatalogDiscount> catalogDiscounts,
            IMongoCollection<CatalogItem> catalogItems)
        {
            var existingCatalogCategories = catalogCategories.Find(p => true).ToList().Any();

            if (!existingCatalogCategories)
                catalogCategories.InsertManyAsync(GetPreconfiguredCatalogTypes());


            var existingCatalogBrands = catalogBrands.Find(p => true).ToList().Any();

            if (!existingCatalogBrands)
                catalogBrands.InsertManyAsync(GetPreconfiguredCatalogBrands());


            var existingCatalogDiscounts = catalogDiscounts.Find(p => true).ToList().Any();

            if (!existingCatalogDiscounts)
                catalogDiscounts.InsertManyAsync(GetPreconfiguredCatalogDiscounts());


            var existingItems = catalogItems.Find(p => true).ToList().Any();

            if (!existingItems)
                catalogItems.InsertManyAsync(GetPreconfiguredProducts());

        }


        private static IEnumerable<CatalogBrand> GetPreconfiguredCatalogBrands()
        {
            return new List<CatalogBrand>()
            {
                new CatalogBrand() { Code = "armani",Name = "Armani" },
                new CatalogBrand() { Code = "versace", Name = "House Of Versace" },
                new CatalogBrand() { Code = "prada", Name = "Prada" },
                new CatalogBrand() { Code = "gucci", Name = "GUCCI" },
                new CatalogBrand() { Code = "fendi", Name = "Fendi" },
                new CatalogBrand() { Code = "nmike", Name = "Nike" },
                new CatalogBrand() { Code = "puma", Name = "Puma" },
                new CatalogBrand() { Code = "mn", Name = "New Balance" },
                new CatalogBrand() { Code = "underarmour", Name = "Under Armour" },
            };
        }

        private static IEnumerable<CatalogCategory> GetPreconfiguredCatalogTypes()
        {
            return new List<CatalogCategory>()
            {
                new CatalogCategory() { Code = "sportswear", Name="Sportswear", LocaleCode="en"},
                new CatalogCategory() { Code = "mens",  Name = "Mens", LocaleCode="en" },
                new CatalogCategory() { Code = "womens",Name = "Womens" , LocaleCode="en"},
                new CatalogCategory() { Code = "kids", Name = "Kids" , LocaleCode="en"},
                new CatalogCategory() { Code = "fashion", Name = "Fashion" , LocaleCode="en"},
                new CatalogCategory() { Code = "households", Name = "HouseHolds" , LocaleCode="en"},
                new CatalogCategory() { Code = "interiors", Name = "Interiors" , LocaleCode="en"},
                new CatalogCategory() { Code = "clothing", Name = "Clothing", LocaleCode="en" },
                new CatalogCategory() { Code = "bags", Name = "Bags" , LocaleCode="en"},
                new CatalogCategory() { Code = "shoes", Name = "Shoes", LocaleCode="en"},
            };
        }

        private static IEnumerable<CatalogDiscount> GetPreconfiguredCatalogDiscounts()
        {
            return new List<CatalogDiscount>()
            {
                new CatalogDiscount() {
                    Code = "seasonal",
                    Description="Season Discount",
                    Percent=20, IsActive= false},

                new CatalogDiscount() {
                    Code = "weekly",
                    Description="Weekly Discount",
                    Percent= 10, IsActive= true},

            };
        }


        private static IEnumerable<CatalogItem> GetPreconfiguredProducts()
        {
            return new List<CatalogItem>()
            {
                new CatalogItem()
                {
                    Name = "PumaMenScuderiaFerrari",
                    Summary = "PUMA Men's Scuderia Ferrari Race Big Shield Tee",
                    Description = "PUMA Men's Scuderia Ferrari Race Big Shield Tee",
                    ImageFileName = "PumaMenScuderiaFerrari.jpg",
                    Price = 140.00M,
                    CategoryCode = "sportswear",
                    BrandCode = "puma"
                },
               
            };
        }
    }
}