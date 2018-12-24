namespace DataAccessLayer.Entities
{
    public class Teams2Users
    {
        public int Id { get; set; }

        public User Member { get; set; }
        public int MemberId { get; set; }

        public Team Team { get; set; }
        public int TeamId { get; set; }

    }
}
