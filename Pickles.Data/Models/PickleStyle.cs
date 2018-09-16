using System.Collections.Generic;

namespace Pickles.Data.Models
{
    public class PickleStyle
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Vote> Votes { get; set; }
    }
}