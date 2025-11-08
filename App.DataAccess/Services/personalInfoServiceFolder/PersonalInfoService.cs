using App.Domain.Models;
using App.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace App.DataAccess.Services.personalInfoServiceFolder
{
    public class PersonalInfoService : IPersonalInfoService
    {
        private readonly DataContext _context;
        public PersonalInfoService(DataContext context)
        {
            _context = context;
        }
        public async Task Add(Personalinfo model)
        {
            await _context.Personalinfos.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {

            var Personalinfo = await _context.Personalinfos.FindAsync(id);
            if (Personalinfo != null)
            {
                _context.Personalinfos.Remove(Personalinfo);

            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<Personalinfo>> GetAll()
        {
            return await _context.Personalinfos
                .OrderByDescending(s => s.UpdateAt).ToListAsync();

        }

        public async Task<Personalinfo> GetById(int id)
        {
            var data = await _context.Personalinfos
                .FirstOrDefaultAsync(s => s.Id == id);
            if (data is null)
            {
                return null;
            }

            return data;
        }

        public async Task Update(int id, Personalinfo model)
        {
            var data = await _context.Personalinfos
                .FirstOrDefaultAsync(s => s.Id == id);

            if (data != null)
            {
                _context.Personalinfos.Update(data);

            }
            await _context.SaveChangesAsync();
        }
    }
}
