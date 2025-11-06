using WebApplication1.Models;

namespace WebApplication1.Services.HobbiesServiceFolder
{
    public interface IHobbyService
    {
        Task<List<Hobbies>> GetAll();
        Task<Hobbies> GetById(int id);
        Task Add(Hobbies model);
        Task Update(int id, Hobbies model);
        Task Delete(int id);
    }
}
