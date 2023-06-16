using DataManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Interface
{
    public interface IRefreshDevProp
    {
        Task<bool> RefreshDevPropAsync(ICollection<DevicesProperties> devicesProperties,int devId);
    }
}
