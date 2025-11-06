using WebApplication1.Models;

namespace WebApplication1.Services.SkillServiceFolder
{
    public interface ISkillService
    {
        Task<List<Skills>> GetAll();
        Task<Skills> GetById(int id);
        Task Add(skills model);
        Task Update(int id, skills model);
        Task Delete(int id);
    }
}
