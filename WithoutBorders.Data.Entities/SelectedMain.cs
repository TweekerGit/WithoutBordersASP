using System.ComponentModel.DataAnnotations.Schema;
using WithoutBorders.Core;

namespace WithoutBorders.Data.Entities
{
    public class SelectedMain:IEntity<int>
    {
        public int Id { get; set; }
        
        [ForeignKey(nameof(MainEntity))]
        public int MainId { get; set; }
        public MainEntity MainEntity { get; set; }
        
    }
}