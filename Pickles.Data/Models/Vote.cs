namespace Pickles.Data.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public int PickleTypeId { get; set; }
        public int PickleStyleId { get; set; }
        public int VoterId { get; set; }

        public PickleType Type { get; set; }
        public PickleStyle Style { get; set; }
        public Voter Voter { get; set; }
    }
}
