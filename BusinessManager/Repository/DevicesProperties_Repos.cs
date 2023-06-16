using BusinessManager.Interface;
using DataManager;
using DataManager.Models;
using DataManager.Models.Views;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Repository
{
    public class DevicesProperties_Repos : IDevicesProperties, IDevicePropertyGet, IRefreshDevProp
    {
        readonly LinkedGateContext _linkedGateContext;
        public DevicesProperties_Repos()
        {
            _linkedGateContext = new LinkedGateContext();
        }

        public async Task<bool> RefreshDevPropAsync(ICollection<DevicesProperties> devicesProperties, int devId)
        {
            try
            {
                var existedProps = _linkedGateContext.DevicesProperties.Where(dp => dp.DeviceID == devId).ToList();
                _linkedGateContext.DevicesProperties.RemoveRange(existedProps);
                _linkedGateContext.DevicesProperties.AddRange(devicesProperties);
                await _linkedGateContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<ICollection<DevCatProps>> Get(int catId, int? devId)
        {
            var data = await (from cp in _linkedGateContext.CategoriesProperties
                              join prop in _linkedGateContext.Properties on cp.PropertyId equals prop.ID
                              join dp in _linkedGateContext.DevicesProperties on
                                new { propId = cp.PropertyId, devCode = (devId ?? 0) } equals new { propId = dp.PropID, devCode =  dp.DeviceID } into gdp
                              from subdp in gdp.DefaultIfEmpty()
                              where cp.CategoryId == catId
                              select new DevCatProps()
                              {
                                  CatPropId = cp.ID,
                                  Description = prop.Description,
                                  PropId = cp.PropertyId,
                                  Value = subdp.Value,
                                  DeviceId = subdp.DeviceID,
                                  DevPropId = subdp.ID,
                              }
                          ).ToListAsync();
            return data;
        }

        public async Task<bool> Insert(ICollection<DevicesProperties> list)
        {
            try
            {
                _linkedGateContext.DevicesProperties.AddRange(list);
                await _linkedGateContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Update(ICollection<DevicesProperties> list)
        {
            try
            {
                foreach (var deviceProp in list)
                {
                    var devPropDB = _linkedGateContext.DevicesProperties
                        .FirstOrDefault(dp => deviceProp.DeviceID == dp.DeviceID
                        && deviceProp.PropID == dp.PropID);
                    if (devPropDB != null)
                    {
                        _linkedGateContext.Entry(deviceProp).State = EntityState.Modified;

                    }
                    else
                    {
                        _linkedGateContext.Entry(deviceProp).State = EntityState.Added;

                    }
                }
                await _linkedGateContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
