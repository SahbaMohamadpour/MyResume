using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Services.ExprienceServiceFolder
{
    public class ExprienceService : IExprienceService
    {
        private readonly DataContext _context;
        public ExprienceService(DataContext context)
        {
            _context = context;
        }
        public async Task Add(Exprience model)
        {
            await _context.Expriences.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var Expriences = await _context.Expriences.FindAsync(id);
            if (Expriences != null)
            {
                _context.Expriences.Remove(Expriences);

            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<Exprience>> GetAll()
        {
            return await _context.Expriences
                .OrderByDescending(s => s.UpdateAt)
                .ToListAsync();
        }

        public async Task<Exprience> GetById(int id)
        {
            var data = await _context.Expriences
                .FirstOrDefaultAsync(s => s.Id == id);
            if (data is null)
            {
                return null;
            }

            return data;
        }

        public async Task Update(int id, Exprience model)
        {
            var data = await _context.Expriences
                .FirstOrDefaultAsync(s => s.Id == id);

            if (data != null)
            {
                _context.Expriences.Update(data);

            }
            await _context.SaveChangesAsync();
        }
    }
}
