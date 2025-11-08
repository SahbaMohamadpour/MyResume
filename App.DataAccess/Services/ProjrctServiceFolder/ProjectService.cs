using App.Domain.Models;
using App.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace App.DataAccess.Services.ProjrctServiceFolder
{
    public class ProjectService : IProjectService
    {
        private readonly DataContext _context;
        public ProjectService(DataContext context)
        {
            _context = context;
        }
        public async Task Add(Project model)
        {
            await _context.Projects.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var Projects = await _context.Projects.FindAsync(id);
            if (Projects != null)
            {
                _context.Projects.Remove(Projects);

            }
            await _context.SaveChangesAsync();

        }

        public async Task<List<Project>> GetAll()
        {
            return await _context.Projects
                 .OrderByDescending(s => s.UpdateAt).ToListAsync();


        }

        public async Task<Project> GetById(int id)
        {
            var data = await _context.Projects
                .FirstOrDefaultAsync(s => s.Id == id);
            if (data is null)
            {
                return null;
            }

            return data;

        }

        public  async Task Update(int id, Project model)
        {
            var data = await _context.Projects
                .FirstOrDefaultAsync(s => s.Id == id);

            if (data != null)
            {
                _context.Projects.Update(data);

            }
            await _context.SaveChangesAsync();
        }
    }
}
