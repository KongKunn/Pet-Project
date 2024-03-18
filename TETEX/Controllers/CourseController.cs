using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using TETEX.Models;
using TETEX.Models.Models_View;

namespace TETEX.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _dbcontext;
        public CourseController(AppDbContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CourseModelView viewModel)
        {
            var course1 = new Course
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description,
                Requirments = viewModel.Requirments,
                UserId = viewModel.UserId,
                CategoryCourseld = viewModel.CategoryCourseld,
                ModifiedDate = DateTime.Now,

            };

            await _dbcontext.Course.AddAsync(course1);
            await _dbcontext.SaveChangesAsync();
            return RedirectToAction("List");
        }
        public async Task<IActionResult> List(int pageIndex = 1, int pageSize = 5)
        {
            var courses = _dbcontext.Course.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return View(courses);
        }

        public async Task<IActionResult> ListSearch(string search)
        {
            // Lấy danh sách các khóa học
            var course = _dbcontext.Course.Where(c => c.Name.Contains(search)).ToList();
            // Chuyển danh sách các khóa học thành danh sách và trả về view
            return View("Views/Course/List.cshtml", course);
        }




        //  --------   PHAN TRANG ----------- 
        public async Task<IActionResult> Pagination(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 10;
            var courses = await _dbcontext.Course.OrderBy(c => c.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();


            return View(courses);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var Course = await _dbcontext.Course.FindAsync(id);
            return View(Course);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Course viewModel)
        {
            var course = await _dbcontext.Course.FindAsync(viewModel.Id);
            if (course is not null)
            {
                course.Name = viewModel.Name;
                course.Description = viewModel.Description;
                course.Requirments = viewModel.Requirments;
                course.UserId = viewModel.UserId;
                course.CategoryCourseld = viewModel.CategoryCourseld;
                course.ModifiedDate = viewModel.ModifiedDate;
                _dbcontext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Course");
        }
        public async Task<IActionResult> Delete(Course viewModel)
        {
            var course = await _dbcontext.Course.FindAsync(viewModel.Id);
            if (course is not null)
            {
                _dbcontext.Course.Remove(viewModel);
                await _dbcontext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Course");

        }

    }


}
