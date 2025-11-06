using WebApplication1.Models;

namespace WebApplication1.Services.ProjrctServiceFolder
{
    public interface IProjectService
    {
        Task<List<skills>> GetAll();
        Task<skills> GetById(int id);
        Task Add(skills model);
        Task Update(int id, skills model);
        Task Delete(int id);
    }
}
