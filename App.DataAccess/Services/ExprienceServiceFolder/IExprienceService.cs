using WebApplication1.Models;

namespace WebApplication1.Services.ExprienceServiceFolder
{
    public interface IExprienceService
    {
        Task<List<Exprience>> GetAll();
        Task<Exprience> GetById(int id);
        Task Add(Exprience model);
        Task Update(int id, Exprience model);
        Task Delete(int id);
    }
}
