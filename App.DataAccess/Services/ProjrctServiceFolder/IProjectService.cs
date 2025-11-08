using App.Domain.Models;

namespace App.DataAccess.Services.ProjrctServiceFolder
{
    public interface IProjectService
    {
        Task<List<Project>> GetAll();
        Task<Project> GetById(int id);
        Task Add(Project model);
        Task Update(int id, Project model);
        Task Delete(int id);
    }
}
