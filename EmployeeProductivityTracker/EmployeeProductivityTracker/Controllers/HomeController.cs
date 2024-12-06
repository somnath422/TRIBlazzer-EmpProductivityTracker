using EmployeeProductivityTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeProductivityTracker.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private const string FilePath = @"C:\Users\Somnath_Roy\Documents\office\Coding Katas\06-Dec-2024\TRIBlazzer-EmpProductivityTracker\EmployeeProductivityTracker\EmployeeProductivityTracker\Team data.xlsx";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index([FromQuery] string AreaPath, [FromQuery] string Assignee, [FromQuery] string IterationPath)
        {
            
            var workItems = ExcelDataReader.ReadWorkItemsFromExcel(FilePath);

            DashboardModel model = new DashboardModel();

            model.Assignes = workItems.Select(wi => wi.AssignedTo.Trim()).Distinct().ToList();

            model.Teams = workItems.Select(wi => wi.AreaPath.Trim()).Distinct().ToList();

            model.Sprints = workItems.Select(wi => wi.IterationPath.Trim()).Distinct().ToList();

            model.WorkItems = workItems;

            if (!string.IsNullOrEmpty(AreaPath))
            {
                model.WorkItems = workItems.Where(w => w.AreaPath == AreaPath).ToList();
            }

            if(!string.IsNullOrEmpty(Assignee))
            {
                model.WorkItems = workItems.Where(w => w.AssignedTo == Assignee).ToList();
            }

            if (!string.IsNullOrEmpty(IterationPath))
            {
                model.WorkItems = workItems.Where(w => w.IterationPath == IterationPath).ToList();
            }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}