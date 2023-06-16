using BusinessManager.Interface;
using DataManager;
using DataManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Repository
{
    public class CategoryRepos : ICategory
    {
        private readonly LinkedGateContext db;
        public CategoryRepos()
        {
            db = new LinkedGateContext();
        }

        public async Task<ICollection<DevicesCategory>> GetCategoriesAsync()
        {
            return await db.DevicesCategories.ToListAsync();
        }
    }
}
