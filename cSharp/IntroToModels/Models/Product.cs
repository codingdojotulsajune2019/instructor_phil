using System.ComponentModel.DataAnnotations;

namespace IntroToModels.Models
{
    public class Product
    {
        [Required(ErrorMessage="Name is required!")]
        [MinLength(2, ErrorMessage="Name must be 2 chars long!")]
        public string Name {get; set;}

        [Required(ErrorMessage="Amount must be present!")]
        [Range(1, 50, ErrorMessage="Amount must be between 1 and 50")]
        public int? Amount {get; set;}
    }
}