using App.Domain.Models;
using System.Diagnostics;

namespace App.DataAccess.Services.CertificateServiceFolder
{
    public interface ICertificateService
    {
        Task<List<Certificate>> GetAll();
        Task<Certificate> GetById(int id);
        Task Add(Certificate model);
        Task Update(int id, Certificate model);
        Task Delete(int id);
    }
}
