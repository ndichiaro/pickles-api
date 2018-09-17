using System.ComponentModel.DataAnnotations;

namespace Pickles.Api.Models
{
    public class VoteApiModel
    {
        [Required]
        public int PickleTypeId { get; set; }
        [Required]
        public int PickleStyleId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(5)]
        public string ZipCode { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
