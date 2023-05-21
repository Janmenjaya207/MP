using Microsoft.AspNetCore.Mvc;
using MP_MB_MD.Core;
using MP_MB_MD.Core.ProjectAggregate;
using MP_MB_MD.Core.ProjectAggregate.Specifications;
using MP_MB_MD.SharedKernel.Interfaces;
using MP_MB_MD.Web.ApiModels;
using MP_MB_MD.Web.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace MP_MB_MD.Web.Controllers
{
    [Route("[controller]")]
    public class ProjectController : Controller
    {
        private readonly IRepository<Project> _projectRepository;

        public ProjectController(IRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        // GET project/{projectId?}
        [HttpGet("{projectId:int}")]
        public async Task<IActionResult> Index(int projectId = 1)
        {
            var spec = new ProjectByIdWithItemsSpec(projectId);
            var project = await _projectRepository.GetBySpecAsync(spec);

            var dto = new ProjectViewModel
            {
                Id = project.Id,
                Name = project.Name,
                Items = project.Items
                            .Select(item => ToDoItemViewModel.FromToDoItem(item))
                            .ToList()
            };
            return View(dto);
        }
    }
}
