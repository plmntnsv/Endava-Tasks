using System.ComponentModel.DataAnnotations;

namespace OnlineShop.WebClient.Models
{
    public class CustomerViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public string Phone { get; set; }

        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public string SecondPhone { get; set; }

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public string Address { get; set; }
    }
}