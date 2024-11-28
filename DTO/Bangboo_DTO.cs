using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    internal class Bangboo_DTO
    {
        [Key]
        public int ID_Bangboo { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Element")]
        public string Element { get; set; }
        [Required]
        [Display(Name = "Rank")]
        public bool Rank { get; set; }
        [Required]
        [Display(Name = "Model")]
        public string Model { get; set; }
        [DataType(DataType.ImageUrl)]
        public string PictureURL { get; set; }
        [Required]
        [Display(Name = "Price")]
        public int Price { get; set; }
    }
}
