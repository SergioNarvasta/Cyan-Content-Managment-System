﻿using Personal.Models;

namespace Personal.Interfaces
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