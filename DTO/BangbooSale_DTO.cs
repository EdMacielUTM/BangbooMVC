using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace DTO
{
    internal class BangbooSale_DTO
    {
        [Key]
        public int ID_BangbooSales { get; set; }
        [Required]
        [Display(Name = "SalesReceipt_ID")]
        public int SalesReceipt_ID { get; set; }
        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [Required]
        [Display(Name = "Bangboo_ID")]
        public int Bangboo_ID { get; set; }
    }
}
