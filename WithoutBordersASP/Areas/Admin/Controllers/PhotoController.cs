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
    [Area("admin")]
    public class PhotoController:Controller
    {
        private readonly IRepository<int, Photo> photoRepo;
        private readonly IRepository<int, Year> yearRepo;
        private readonly IRepository<int, Camp> campRepo;
        private int tempId;
        

        public PhotoController(IRepository<int, Photo> photoRepo,
            IRepository<int, Year> yearRepo, IRepository<int, Camp> campRepo)
        {
            this.photoRepo = photoRepo;
            this.campRepo = campRepo;
            this.yearRepo = yearRepo;
        }

        [HttpGet("/photos")]
        public async Task<IActionResult> All()
        {
            IEnumerable<Year> data = await yearRepo.GetAllAsync(y => y.Camps);
            return View(data.Select(d=>new YearDto(d)));
        }

        [HttpGet("/photos/{id}")]
        public async Task<IActionResult> One(int id)
        {
            tempId = id;
            Camp camp = await campRepo.GetByIdAsync(id, c => c.Photos);
            IEnumerable<Photo> data = camp.Photos;
            return View(data);
        }

        [HttpGet("/photos/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            photoRepo.Delete(tempId);
            await photoRepo.SaveAsync();
            return this.One(ViewBag.campId);
        }
    }
}