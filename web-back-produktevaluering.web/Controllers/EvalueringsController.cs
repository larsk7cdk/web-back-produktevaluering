using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_back_produktevaluering.web.Models;

namespace web_back_produktevaluering.web.Controllers
{
    public class EvalueringsController : Controller
    {
        private readonly AppDbContext _context;

        public EvalueringsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Evaluerings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Evalueringer.ToListAsync());
        }

        // GET: Evaluerings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var evaluering = await _context.Evalueringer
                .FirstOrDefaultAsync(m => m.EvalueringId == id);
            if (evaluering == null) return NotFound();

            return View(evaluering);
        }

        // GET: Evaluerings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Evaluerings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EvalueringId,Navn,Produkt,Karakter")]
            Evaluering evaluering)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evaluering);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(evaluering);
        }

        // GET: Evaluerings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var evaluering = await _context.Evalueringer.FindAsync(id);
            if (evaluering == null) return NotFound();
            return View(evaluering);
        }

        // POST: Evaluerings/Edit/5
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
                try
                {
                    _context.Update(evaluering);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvalueringExists(evaluering.EvalueringId))
                        return NotFound();
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(evaluering);
        }

        // GET: Evaluerings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var evaluering = await _context.Evalueringer
                .FirstOrDefaultAsync(m => m.EvalueringId == id);
            if (evaluering == null) return NotFound();

            return View(evaluering);
        }

        // POST: Evaluerings/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evaluering = await _context.Evalueringer.FindAsync(id);
            _context.Evalueringer.Remove(evaluering);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvalueringExists(int id)
        {
            return _context.Evalueringer.Any(e => e.EvalueringId == id);
        }
    }
}