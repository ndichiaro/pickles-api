using System.ComponentModel.DataAnnotations;

namespace Pickles.Api.Models
{
    public class VoteApiModel
    {
        [Required]
        public int PickleTypeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Range(0, 99999)]
        public int ZipCode { get; set; }
        public double? Latitute { get; set; }
        public double? Longitude { get; set; }
    }
}
