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

        public IActionResult Index()
        {
            var data = ExcelDataReader.ReadWorkItemsFromExcel(FilePath);
            return View();
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