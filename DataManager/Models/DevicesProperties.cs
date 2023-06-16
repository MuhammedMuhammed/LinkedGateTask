using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Models
{
    public class DevicesProperties
    {
        [Key]
        public int ID {  get; set; }
        [Required]
        [Index("CP_PropIDANDDeviceID", 1, IsUnique = true)]
        public int PropID { get; set; }
        [Required]
        [Index("CP_PropIDANDDeviceID", 2, IsUnique = true)]
        public int DeviceID { get; set; }
        public string Value { get; set; }
        [ForeignKey("DeviceID")]
        public Devices Device { get; set; }
        [ForeignKey("PropID")]
        public PropertyItems DeviceProperty { get; set; }
    }
}
