using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SNewsMVC.Models.Category
{
    public class InsertCategoryViewModel
    {
        [Required(ErrorMessage = "Unesite naziv kategorije")]
        [Display(Name = "Naziv")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Opis")]
        [StringLength(100)]
        public string Description { get; set; }
    }
}
