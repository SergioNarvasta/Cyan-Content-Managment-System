using Personal.Models;
using System.Collections.Generic;

namespace Personal.Repositories
{
    public interface IExperienceCollection
    {
        Task InsertExperience(Experience experience);

        Task UpdateExperience(Experience experience);

        Task DeleteExperience(string id);

        Task<Experience> GetExperienceById(string id);
        
        Task<IEnumerable<Experience>> GetAllExperiences();
    }
}
