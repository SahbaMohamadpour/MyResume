using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using static WebApplication1.Models.Skills;

namespace WebApplication1.Services.SkillServiceFolder
{
    public class SkillService : ISkillService
    {
        private readonly DataContext _context;
        public SkillService(DataContext context)
        {
            _context = context;
        }

        public async Task Add(skills model)
        {
            await _context.Skills.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var skill = await _context.Skill.FindAsync(id);
            if (skill != null)
            {
                _context.Skills.Remove(skill);

            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<Skills>> GetAll()
        {
            return await _context.Skills
                .OrderByDescending(s => s.UpdateAt).ToListAsync();

        }

        public async Task<Skills> GetById(int id)
        {
            var data = await _context.Skills
                .FirstOrDefaultAsync(s => s.Id == id);
            if (data is null)
            {
                return null;
            }

            return data;
        }

        public async Task Update(int id, skills model)
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
