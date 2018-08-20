namespace Pickles.Data.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public int PickleTypeId { get; set; }
        public int VoterId { get; set; }

        public PickleType Pickle { get; set; }
        public Voter Voter { get; set; }
    }
}
