using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Models.Views
{
    public class DevPropsView
    {
        public Devices Devices { get; set; }
        public ICollection<DevCatProps> DevCatProps { get; set; }
    }
}
