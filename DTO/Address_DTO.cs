using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DTO
{
    public class Address_DTO
    {
        [Key]
        public int ID_Address { get; set; }
        [Required]
        [Display(Name = "Street_Number")]
        public string Street_Number { get; set; }
        [Required]
        [Display(Name = "City")]
        public string City { get; set; }
        [Required]
        [Display(Name = "State")]
        public string State { get; set; }
        [Required]
        [Display(Name = "ZipCode")]
        public string ZipCode { get; set; }
    }
}
