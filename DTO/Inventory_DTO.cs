using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    internal class Inventory_DTO
    {
        [Key]
        public int ID_Inventory { get; set; }
        [Required]
        [Display(Name = "Bangboo_ID")]
        public int Bangboo_ID { get; set; }
        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [Required]
        [Display(Name = "LastRestockDate")]
        public Nullable<System.DateTime> LastRestockDate { get; set; }
    }
}
