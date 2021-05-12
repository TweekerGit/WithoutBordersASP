using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WithoutBorders.Core.Repository;
using WithoutBorders.Data.Entities;
using WithoutBordersASP.Models.Dto;

namespace WithoutBordersASP.Areas.Admin.Controllers
{
    public class YearController : Controller
    {
        private readonly IRepository<int, Year> yearRepo;

        public YearController(IRepository<int, Year> yearRepo)
        {
            this.yearRepo = yearRepo;
        }

        [Area("admin")]
        [HttpGet("/years")]
        public async Task<IActionResult> All()
        {
            IEnumerable<Year> data = await yearRepo.GetAllAsync(y => y.Camps);
            return View(data.Select(d=>new YearDto(d)));
        }
    }
}