using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WithoutBorders.Core.Repository;
using WithoutBorders.Data.Entities;
using WithoutBordersASP.Models.Dto;

namespace WithoutBordersASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<int, Mentor> mentorRepo;
        private readonly IRepository<int, MainEntity> mainRepo;

        public HomeController(IRepository<int, Mentor> mentorRepo, IRepository<int, MainEntity> mainRepo)
        {
            this.mentorRepo = mentorRepo;
            this.mainRepo = mainRepo;
        }

        public async Task<IActionResult> Index()
        {
            MainEntity data = await mainRepo.GetByIdAsync(1,m=>m.Expectations);
            return View(new MainEntityDto(data));
        }

        [HttpGet("mentors")]
        public async Task<IActionResult> Mentors()
        {
            if (mentorRepo is null) return this.StatusCode(500);

            IEnumerable <Mentor> data = await mentorRepo.GetAllAsync();
            return View(data.ToList());
        }
    }
}