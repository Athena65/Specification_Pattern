
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{

    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? City { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? Street { get; set; }
    }
}
