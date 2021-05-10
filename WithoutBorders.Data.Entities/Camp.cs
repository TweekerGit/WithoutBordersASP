using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WithoutBorders.Core;

namespace WithoutBorders.Data.Entities
{
    public class Camp :IEntity<int>
    {
        public int Id { get; set; }
        
        [MaxLength(32)]
        public string Place { get; set; }
        [MaxLength(32)]
        public string Name { get; set; }
        
        [ForeignKey(nameof(Year))]
        public int YearId { get; set; }
        
        public virtual Year Year { get; set; }
        
    }
}