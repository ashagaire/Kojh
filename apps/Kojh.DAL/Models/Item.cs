using System.ComponentModel.DataAnnotations;

namespace Kojh.DAL.Models
{
    public class Item
    {
        [Key] public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
