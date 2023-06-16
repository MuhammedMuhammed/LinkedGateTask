using DataManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Seeders
{
    public class PropertiesSeeder
    {
        public PropertiesSeeder()
        {
            Seed();
        }
        public void Seed()
        {
            try
            {
                using (LinkedGateContext context = new LinkedGateContext())
                {
                    context.Database.CreateIfNotExists();
                    IList<PropertyItems> propertyItems = new List<PropertyItems>
            {
                new PropertyItems() { Description = "HD" },
                new PropertyItems() { Description = "Processor" },
                new PropertyItems() { Description = "Dimensions" },
                new PropertyItems() { Description = "MAC Address" },
                new PropertyItems() { Description = "IP Address" },
                new PropertyItems() { Description = "Current User" },
                new PropertyItems() { Description = "Network Speed" },
                new PropertyItems() { Description = "Operating System" },
                new PropertyItems() { Description = "Ports" }
            };
                    context.Properties.AddRange(propertyItems);
                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
