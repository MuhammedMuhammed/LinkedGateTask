using DataManager.Models;
using DataManager.Seeders;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager
{
    public class LinkedGateContext :DbContext
    {
        public LinkedGateContext() : base("name=LinkedGate") {
        }
        public DbSet<Devices> Devices { get; set; }
        public DbSet<PropertyItems> Properties { get; set; }
        public DbSet<DevicesCategory> DevicesCategories { get; set; }
        public DbSet<CategoriesProperties> CategoriesProperties { get; set; }
        public DbSet<DevicesProperties> DevicesProperties { get; set; }
    }
}
