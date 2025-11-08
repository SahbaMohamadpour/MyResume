using App.Domain.Models;

namespace App.DataAccess.Services.SkillServiceFolder
{
    public interface ISkillService
    {
        Task<List<Skill>> GetAll();
        Task<Skill> GetById(int id);
        Task Add(Skill model);
        Task Update(int id, Skill model);
        Task Delete(int id);
    }
}
