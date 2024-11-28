using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    internal class SalesReceipt_DTO
    {
        [Key]
        public int ID_Sale { get; set; }
        [Required]
        [Display(Name = "SaleDate")]
        public Nullable<System.DateTime> SaleDate { get; set; }
        [Required]
        [Display(Name = "Employee_ID")]
        public int Employee_ID { get; set; }
        [Required]
        [Display(Name = "Customer_ID")]
        public int Customer_ID { get; set; }
        [Required]
        [Display(Name = "TotalAmount")]
        public Nullable<int> TotalAmount { get; set; }
    }
}
