using DataManager.Models;
using DataManager.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Interface
{
    public interface IDevicePropertyGet
    {
        Task<ICollection<DevCatProps>> Get(int catId, int? devId);

    }
}
