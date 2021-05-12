using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WithoutBorders.Core.Repository;
using WithoutBorders.Data.Entities;
using WithoutBordersASP.Models.Dto;

namespace WithoutBordersASP.Areas.Admin.Controllers
{
    [Area("admin")]
    public class MasterController : Controller
    {
        private readonly IRepository<int, MainEntity> mainRepo;

        public MasterController(IRepository<int, MainEntity> mainRepo)
        {
            this.mainRepo = mainRepo;
        }

        [HttpGet("/masters")]
        public async Task<IActionResult> All()
        {
            IEnumerable<MainEntity> data = await mainRepo.GetAllAsync(m=>m.Expectations);
            return View(data.Select(d=> new MainEntityDto(d)));
        }
    }
}