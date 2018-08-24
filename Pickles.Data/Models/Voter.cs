using System.Collections.Generic;

namespace Pickles.Data.Models
{
    public class Voter
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ZipCode { get; set; }
        public double? Latitute { get; set; }
        public double? Longitude { get; set; }
        public string IpAddress { get; set; }

        public List<Vote> Votes { get; set; }
    }
}
