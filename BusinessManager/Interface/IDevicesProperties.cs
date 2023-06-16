using DataManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Interface
{
    public interface IDevicesProperties
    {
        Task<bool> Insert(ICollection<DevicesProperties> list);
        Task<bool> Update(ICollection<DevicesProperties> list);
    }
}
