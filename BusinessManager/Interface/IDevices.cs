using DataManager;
using DataManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Interface
{
    public interface IDevices
    {

        Task<ICollection<Devices>> GetDevicesAsync();
        Task<Devices> GetDeviceAsync(int id);
        Task<bool> AddDevice(Devices device);
        Task<bool> UpdateDevice(Devices device);
        void DisposeDB();
    }
}
