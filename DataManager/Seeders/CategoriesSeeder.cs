using DataManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Seeders
{
    public class CategoriesSeeder
    {
        public CategoriesSeeder()
        {
            Seed();
        }
        void Seed()
        {
            try
            {
                using (LinkedGateContext context = new LinkedGateContext())
                {
                    context.Database.CreateIfNotExists();
                    IList<DevicesCategory> categories = new List<DevicesCategory>
            {
                new DevicesCategory() { Name = "Printer",CategoriesProperties = new List<CategoriesProperties>{
                    new CategoriesProperties(){PropertyId = 4},
                    new CategoriesProperties(){PropertyId = 5}
                } },
                new DevicesCategory() { Name = "Laptop",CategoriesProperties = new List<CategoriesProperties>{
                    new CategoriesProperties(){PropertyId = 2},
                    new CategoriesProperties(){PropertyId = 4},
                    new CategoriesProperties(){PropertyId = 5},
                    new CategoriesProperties(){PropertyId = 8},
                } },
                new DevicesCategory() { Name = "Switch" ,CategoriesProperties = new List<CategoriesProperties>{
                    new CategoriesProperties(){PropertyId = 7},
                    new CategoriesProperties(){PropertyId = 9}
                }},
            };
                    context.DevicesCategories.AddRange(categories);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
