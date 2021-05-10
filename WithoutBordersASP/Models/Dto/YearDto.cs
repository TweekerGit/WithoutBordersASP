using System;
using System.Collections.Generic;
using System.Linq;
using WithoutBorders.Data.Entities;

namespace WithoutBordersASP.Models.Dto
{
    public class YearDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Camp> Camps { get; set; }

        public YearDto(Year year)
        {
            this.Id = year.Id;
            this.Name = year.Name;
            this.Camps = Camps.ToList();
        }

        public Year ToEntity()
        {
            return new()
            {
                Id = this.Id ?? throw new ArgumentNullException(nameof(Id)),
                Name = this.Name,
                Camps = this.Camps.ToList()
            };
        }
    }
}