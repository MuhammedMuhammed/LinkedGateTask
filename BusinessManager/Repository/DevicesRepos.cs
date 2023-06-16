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
    public class DevicesRepos : IDevices
    {
        private readonly LinkedGateContext db;
        private readonly IRefreshDevProp refreshDevProp;
        public DevicesRepos()
        {
            refreshDevProp = new DevicesProperties_Repos();
            db = new LinkedGateContext();
        }

        public async Task<bool> AddDevice(Devices device)
        {
            try
            {
                db.Devices.Add(device);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void DisposeDB()
        {
            db.Dispose();
        }

        public async Task<Devices> GetDeviceAsync(int id)
        {
            return await db.Devices.Include("Category")
                .Include("DevicesProperties")
                .FirstOrDefaultAsync(dv => dv.ID == id);

        }

        public async Task<ICollection<Devices>> GetDevicesAsync()
        {
            return await db.Devices.Include("Category").ToListAsync();

        }

        public async Task<bool> UpdateDevice(Devices device)
        {
            try
            {
                await refreshDevProp.RefreshDevPropAsync(device.DevicesProperties, device.ID);

                db.Entry(device).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
