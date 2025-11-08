using App.Domain.Models;

namespace App.DataAccess.Services.personalInfoServiceFolder
{
    public interface IPersonalInfoService
    {
        Task<List<Personalinfo>> GetAll();
        Task<Personalinfo> GetById(int id);
        Task Add(Personalinfo model);
        Task Update(int id, Personalinfo model);
        Task Delete(int id);
    }
}
