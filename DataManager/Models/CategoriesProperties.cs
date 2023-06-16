using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Models
{
    public class CategoriesProperties
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Index("CP_CategoryIdANDPropertyId", 1, IsUnique = true)]
        public int CategoryId { get; set; }
        [Required]
        [Index("CP_CategoryIdANDPropertyId",2, IsUnique = true)]
        public int PropertyId { get; set; }

        [ForeignKey("CategoryId")]
        public DevicesCategory DevicesCategory { get; set; }
        [ForeignKey("PropertyId")]
        public PropertyItems PropertyItem { get; set; }
    }
}
