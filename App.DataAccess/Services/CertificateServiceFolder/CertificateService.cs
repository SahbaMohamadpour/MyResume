using App.Domain.Models;
using App.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace App.DataAccess.Services.CertificateServiceFolder
{
    public class CertificateService : ICertificateService
    {

        private readonly DataContext _context;
        public CertificateService(DataContext context)
        {
            _context = context;
        }
        public async Task Add(Certificate model)
        {
            await _context.Certificates.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var Certificates = await _context.Certificates.FindAsync(id);
            if (Certificates != null)
            {
                _context.Certificates.Remove(Certificates);

            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<Certificate>> GetAll()
        {
            return await _context.Certificates
                .OrderByDescending(s => s.UpdateAt).ToListAsync();

        }

        public async Task<Certificate> GetById(int id)
        {
            var data = await _context.Certificates
                .FirstOrDefaultAsync(s => s.Id == id);
            if (data is null)
            {
                return null;
            }

            return data;
        }

        public async Task Update(int id, Certificate model)
        {
            var data = await _context.Certificates
                .FirstOrDefaultAsync(s => s.Id == id);

            if (data != null)
            {
                _context.Certificates.Update(data);

            }
            await _context.SaveChangesAsync();
        }
    }
}
