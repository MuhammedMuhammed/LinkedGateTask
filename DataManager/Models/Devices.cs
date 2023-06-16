using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Models
{
    public class Devices
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DisplayName("Category")]
        public int CatId { get; set; }
        public string Memo { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime AcquisitionDate { get; set; }
        [ForeignKey(nameof(CatId))]
        public DevicesCategory Category { get; set; }
        public ICollection<DevicesProperties> DevicesProperties { get; set; }


    }
}
