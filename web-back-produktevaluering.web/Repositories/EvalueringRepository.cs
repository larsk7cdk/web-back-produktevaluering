using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using web_back_produktevaluering.web.Models;

namespace web_back_produktevaluering.web.Repositories
{
    public class EvalueringRepository : IRepository<Evaluering>
    {
        private readonly AppDbContext _context;

        public EvalueringRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Evaluering>> ReadAll() => await _context.Evalueringer.OrderByDescending(x => x.Oprettet).ToListAsync();

        public async Task<Evaluering> ReadById(int id) => await _context.Evalueringer.OrderByDescending(x => x.Oprettet).FirstOrDefaultAsync(m => m.EvalueringId == id);

        public async Task Create(Evaluering model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Evaluering model)
        {
            try
            {
                _context.Update(model);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var evalueringExists = _context.Evalueringer.Any(e => e.EvalueringId == model.EvalueringId);
                if (!evalueringExists)
                    throw new Exception($"Produkt {model.Navn} findes ikke");

                throw;
            }
        }

        public async Task Delete(int id)
        {
            var model = await _context.Evalueringer.FindAsync(id);
            _context.Evalueringer.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}