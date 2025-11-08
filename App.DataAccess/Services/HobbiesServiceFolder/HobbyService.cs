using App.Domain.Models;
using App.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace App.DataAccess.Services.HobbiesServiceFolder
{
    public class HobbyService : IHobbyService
    {
        private readonly DataContext _context;
        public HobbyService(DataContext context)
        {
            _context = context;
        }
        public async Task Add(Hobbies model)
        {
            await _context.Hobby.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var Hobby = await _context.Hobby.FindAsync(id);
            if (Hobby != null)
            {
                _context.Hobby.Remove(Hobby);

            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<Hobbies>> GetAll()
        {
            return await _context.Hobby
                .OrderByDescending(s => s.UpdateAt).ToListAsync();

        }

        public async Task<Hobbies> GetById(int id)
        {
            var data = await _context.Hobby
                .FirstOrDefaultAsync(s => s.Id == id);
            if (data is null)
            {
                return null;
            }

            return data;
        }

        public async Task Update(int id, Hobbies model)
        {
            var data = await _context.Hobby
               .FirstOrDefaultAsync(s => s.Id == id);

            if (data != null)
            {
                _context.Hobby.Update(data);

            }
            await _context.SaveChangesAsync();
        }
    }
}
