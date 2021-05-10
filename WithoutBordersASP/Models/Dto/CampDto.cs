using System;
using WithoutBorders.Data.Entities;

namespace WithoutBordersASP.Models.Dto
{
    public class CampDto
    {
        public int? Id { get; set; }
        public string Place { get; set; }
        public string Name { get; set; }
        public int? YearId { get; set; }
        public YearDto Year { get; set; }

        public CampDto(Camp camp)
        {
            this.Id = camp.Id;
            this.Place = camp.Place;
            this.Name = camp.Place;
            this.YearId = camp.YearId;
            this.Year = new YearDto(camp.Year);
        }

        public Camp ToEntity()
        {
            return new()
            {
                Id = this.Id ?? throw new ArgumentNullException(nameof(Id)),
                Place = this.Place,
                YearId = this.YearId ?? throw new ArgumentNullException(nameof(YearId)),
                Year = this.Year.ToEntity()
            };
        }
    }
}