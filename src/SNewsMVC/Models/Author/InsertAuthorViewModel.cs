using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SNewsMVC.Models.Author
{
    public class InsertAuthorViewModel
    {
        [Required(ErrorMessage = "Unesite ime autora")]
        [Display(Name = "Ime")]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Unesite prezime autora")]
        [Display(Name = "Prezime")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Unesite datum rođenja autora")]
        [Display(Name = "Datum rođenja")]
        public DateTime BirthDate { get; set; }
    }
}
