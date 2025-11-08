using App.Domain.Models;
using App.Infrastructure;
using Microsoft.EntityFrameworkCore;


namespace App.DataAccess.Services.SkillServiceFolder
{
    public class SkillService : ISkillService
    {
        private readonly DataContext _context;
        public SkillService(DataContext context)
        {
            _context = context;
        }

        public async Task Add(Skill model)
        {
            await _context.Skills.AddAsync(model);
            await _context.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            var trick = await _context.Skills.FindAsync(id);
            if (trick != null)
            {
                _context.Skills.Remove(trick);

            }
            await _context.SaveChangesAsync();


        }

        public async Task<List<Skill>> GetAll()
        {
            return await _context.Skills
                 .OrderByDescending(s => s.UpdateAt)
                 .ToListAsync();
        }

        public async Task<Skill> GetById(int id)
        {
            var data = await _context.Skills
                .FirstOrDefaultAsync(s => s.Id == id);
            if (data is null)
            {
                return null;
            }

            return data;
        }

        public async Task Update(int id, Skill model)
        {
            var data = await _context.Skills
                .FirstOrDefaultAsync(s => s.Id == id);

            if (data != null)
            {
                _context.Skills.Update(data);

            }
            await _context.SaveChangesAsync();
        }
    }
    
}
