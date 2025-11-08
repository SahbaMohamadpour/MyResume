using App.Domain.Models;
using App.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace App.DataAccess.Services.LanguageServiceFolder
{
    public class LanguageService : ILanguageService
    {
        private readonly DataContext _context;
        public LanguageService(DataContext context)
        {
            _context = context;
        } 

        public async Task Add(Language model)
        {
            await _context.Languages.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async  Task Delete(int id)
        {
            var Languages = await _context.Languages.FindAsync(id);
            if (Languages != null)
            {
                _context.Languages.Remove(Languages);

            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<Language>> GetAll()
        {
            return await _context.Languages
                .OrderByDescending(s => s.UpdateAt).ToListAsync();

        }

        public async Task<Language> GetById(int id)
        {
            var data = await _context.Languages
                .FirstOrDefaultAsync(s => s.Id == id);
            if (data is null)
            {
                return null;
            }

            return data;
        }

        public async Task Update(int id, Language model)
        {
            var data = await _context.Languages
                .FirstOrDefaultAsync(s => s.Id == id);

            if (data != null)
            {
                _context.Languages.Update(data);

            }
            await _context.SaveChangesAsync();
        }
    }
}
