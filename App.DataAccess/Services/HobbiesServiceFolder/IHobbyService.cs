using App.Domain.Models;

namespace App.DataAccess.Services.HobbiesServiceFolder
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
