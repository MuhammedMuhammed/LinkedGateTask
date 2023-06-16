using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Models.Views
{
    public class DevCatProps
    {
        public int? CatPropId { get; set; }
        public string Description { get; set; }
        public int? PropId { get; set; }
        public int? DeviceId { get; set; }
        public string Value { get; set; }
        public int? DevPropId { get; set; }
    }
}
