using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web_back_produktevaluering.web.Models;
using web_back_produktevaluering.web.Repositories;

namespace web_back_produktevaluering.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Evaluering> _evalueringRepository;

        public HomeController(IRepository<Evaluering> evalueringRepository)
        {
            _evalueringRepository = evalueringRepository;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _evalueringRepository.ReadAll();
            return View(result.Take(2));
        }

        public IActionResult About()
        {
            return View();
        }
    }
}