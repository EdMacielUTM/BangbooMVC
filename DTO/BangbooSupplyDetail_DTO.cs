using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    internal class BangbooSupplyDetail_DTO
    {
        [Key]
        public int ID_Detail { get; set; }
        [Required]
        [Display(Name = "ID_Bangboo")]
        public int ID_Bangboo { get; set; }
        [Required]
        [Display(Name = "ID_Supplier")]
        public int ID_Supplier { get; set; }
        [Required]
        [Display(Name = "SupplyAmount")]
        public int SupplyAmount { get; set; }
        [Required]
        [Display(Name = "SupplyDate")]
        public Nullable<System.DateTime> SupplyDate { get; set; }
        [Required]
        [Display(Name = "UnitCost")]
        public Nullable<int> UnitCost { get; set; }
    }
}
