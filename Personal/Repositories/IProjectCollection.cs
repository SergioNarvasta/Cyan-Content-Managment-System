using Personal.Models;

namespace Personal.Repositories
{
    public interface IProjectCollection
    {
        Task InsertProject(Project project);
        Task UpdateProject(Project project);
        Task DeleteProject(string id);
        Task<Project> GetProjectById(string id);
        Task<List<Project>> GetAllProjects();
    }
}
