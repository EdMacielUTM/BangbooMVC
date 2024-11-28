using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    internal class Employee_DTO
    {
        [Key]
        public int ID_Employee { get; set; }
        [Required]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "HireDate")]
        public Nullable<System.DateTime> HireDate { get; set; }
        [Required]
        [Display(Name = "Salary")]
        public Nullable<decimal> Salary { get; set; }
        [Required]
        [Display(Name = "Address_ID")]
        public int Address_ID { get; set; }
    }
}
