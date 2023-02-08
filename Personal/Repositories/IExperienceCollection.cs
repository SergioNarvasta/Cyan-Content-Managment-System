using Personal.Models;
using System.Collections.Generic;

namespace Personal.Repositories
{
    public interface IProjectCollection
    {
        Task InsertExperience(Experience experience);

        Task UpdateExperience(Experience experience);

        Task DeleteExperience(string id);

        Task<Project> GetExperienceById(string id);
        
        Task<IEnumerable<Experience>> GetAllExperience();
    }
}
