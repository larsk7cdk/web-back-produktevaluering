using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web_back_produktevaluering.web.Models;
using web_back_produktevaluering.web.Repositories;

namespace web_back_produktevaluering.web.Controllers
{
    public class EvalueringsController : Controller
    {
        private readonly IRepository<Evaluering> _evalueringRepository;

        public EvalueringsController(IRepository<Evaluering> evalueringRepository)
        {
            _evalueringRepository = evalueringRepository;
        }

        public async Task<IActionResult> Index() => View(await _evalueringRepository.ReadAll());
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var evaluering = await _evalueringRepository.ReadById((int)id);
            if (evaluering == null) return NotFound();

            return View(evaluering);
        }

        public IActionResult Create()
        {
            return View();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EvalueringId,Navn,Produkt,Karakter")]
            Evaluering evaluering)
        {
            if (ModelState.IsValid)
            {
                await _evalueringRepository.Create(evaluering);
                return RedirectToAction(nameof(Index));
            }

            return View(evaluering);
        }

        // GET: Evaluerings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var evaluering = await _evalueringRepository.ReadById((int)id);
            if (evaluering == null) return NotFound();

            return View(evaluering);
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EvalueringId,Navn,Produkt,Karakter")]
            Evaluering evaluering)
        {
            if (id != evaluering.EvalueringId) return NotFound();

            if (ModelState.IsValid)
            {
                await _evalueringRepository.Update(evaluering);
                return RedirectToAction(nameof(Index));
            }

            return View(evaluering);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var evaluering = await _evalueringRepository.ReadById((int)id);
            if (evaluering == null) return NotFound();

            return View(evaluering);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _evalueringRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}