using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TETEX.Models;
using TETEX.Models.Models_View;

namespace TETEX.Controllers
{
    public class LessonController : Controller
    {
          private readonly AppDbContext dbcontext;
        public LessonController(AppDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(LessonModelView viewModel)
        {
            var lesson = new Lessons
            {
               

            Id =  Guid.NewGuid(),
            Name = viewModel.Name,
                Description = viewModel.Description,
                ModifiedDate = viewModel.ModifiedDate,
                SectionId = viewModel.SectionId,
            
            };


            await dbcontext.Lessons.AddAsync(lesson);
            await dbcontext.SaveChangesAsync();
            return RedirectToAction("List");
        }
        public async Task<IActionResult> List()
        {
           var lesson = await dbcontext.Lessons.ToListAsync();
            return View(lesson);
        }
        public async Task<IActionResult> ListSearch(string search)
        {

            IQueryable<Lessons> sections = dbcontext.Lessons;

            if (!string.IsNullOrEmpty(search))
            {
                sections = sections.Where(c => c.Name.Contains(search));
            }

            List<Lessons> LessonList = await sections.ToListAsync();
            return View(LessonList);
        }
        public async Task<IActionResult> ListLesson()
        {
            string routeId = (string)RouteData.Values["id"];
            var lesson = await dbcontext.Lessons.ToListAsync();
            List<Lessons> item1 = new List<Lessons>();


            //
            var ListLesson = await dbcontext.Lessons.ToListAsync();
            ListLesson = ListLesson.Where(c => c.SectionId.ToString() == routeId).ToList();


            return View( ListLesson);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
          var Lesson =  await dbcontext.Lessons.FindAsync(id);
            return View(Lesson);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Lessons viewModel)
        {
            var lesson = await dbcontext.Lessons.FindAsync(viewModel.Id);
            if (lesson is not null)
            {
                lesson.Name = viewModel.Name;
                lesson.Description = viewModel.Description;
                lesson.ModifiedDate = DateTime.Now;
                dbcontext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Lesson");
        }
        public async Task<IActionResult> Delete(Lessons viewModel)
        {
            var lesson = await dbcontext.Lessons.FindAsync(viewModel.Id);
            if (lesson is not null)
            {
                dbcontext.Lessons.Remove(viewModel);
                await dbcontext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Lesson");

        }

    }


}
