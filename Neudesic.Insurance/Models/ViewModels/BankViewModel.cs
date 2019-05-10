using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Neudesic.Insurance.Models.ViewModels
{
    public class BankViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="Name is required")]
        [StringLength(maximumLength:100,ErrorMessage ="Max length should be 100")]
        public string Name { get; set; }
    }
}
