using WebApplication1.Models;

namespace WebApplication1.Services.personalInfoServiceFolder
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
