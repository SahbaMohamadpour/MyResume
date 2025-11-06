using WebApplication1.Models;

namespace WebApplication1.Services.LanguageServiceFolder
{
    public interface ILanguageService
    {
        Task<List<Language>> GetAll();
        Task<Language> GetById(int id);
        Task Add(Language model);
        Task Update(int id, Language model);
        Task Delete(int id);
    }
}
