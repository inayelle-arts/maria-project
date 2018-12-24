using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class Label
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }

        public Board Board { get; set; }
        public int BoardId { get; set; }    
    }
}
