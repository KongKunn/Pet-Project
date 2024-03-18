using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TETEX.Models;
using TETEX.Models.Models_View;

namespace TETEX.Controllers
{
    public class SectionsController : Controller
    {
          private readonly AppDbContext dbcontext;
        public SectionsController(AppDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SectionsModelView viewModel)
        {
            var sections = new Sections
            {
                Id = Guid.NewGuid(),
                Name = viewModel.Name,
                ModifiedDate = DateTime.Now,
                CreatedDate = viewModel.CreatedDate,
                CourseId = viewModel.CourseId,
                Course = viewModel.Course,
                VideoUrl= viewModel.VideoUrl,

            };


            await dbcontext.Sections.AddAsync(sections);
            await dbcontext.SaveChangesAsync();

            string routeId = (string)RouteData.Values["id"];

            IQueryable<Sections> section = dbcontext.Sections;



            section = section.Where(c => c.CourseId.ToString() == routeId);


            List<Sections> sectionsList = await section.ToListAsync();
            return View("Views/Sections/List.cshtml", sectionsList);
        }
        public async Task<IActionResult> List()
        {
            string routeId = (string)RouteData.Values["id"];

            IQueryable<Sections> sections = dbcontext.Sections; 

            
                
                sections = sections.Where(c =>   c.CourseId.ToString() == routeId);
            

            List<Sections> sectionsList = await sections.ToListAsync();
            return View("Views/Sections/List.cshtml",sectionsList);
        }
        public async Task<IActionResult> Search(string search)
        {
            string routeId = (string)RouteData.Values["id"];

            IQueryable<Sections> sections = dbcontext.Sections;
            sections = sections.Where(c => c.CourseId.ToString() == routeId && c.Name.Contains(search));
            List<Sections> sectionsList = await sections.ToListAsync();
            return View("Views/Sections/List.cshtml", sectionsList);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
          var sections =  await dbcontext.Sections.FindAsync(id);
            return View(sections);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Sections viewModel)
        {
            var sections = await dbcontext.Sections.FindAsync(viewModel.Id);
            if (sections is not null)
            {
                sections.Name = viewModel.Name;
                sections.ModifiedDate = DateTime.Now;
                sections.CreatedDate = viewModel.CreatedDate;
                //sections.CourseId = viewModel.CourseId;
                sections.VideoUrl = viewModel.VideoUrl;
                dbcontext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Sections");
        }
        public async Task<IActionResult> Delete(Sections viewModel)
        {
            var sections = await dbcontext.Sections.FindAsync(viewModel.Id);
            if (sections is not null)
            {
                dbcontext.Sections.Remove(viewModel);
                await dbcontext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Sections");

        }

    }


}
