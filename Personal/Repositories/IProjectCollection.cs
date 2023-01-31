using Personal.Models;

namespace Personal.Repositories
{
    public interface IProjectCollection
    {
        Task InsertProject(Project project);
        Task UpdateProject(Project project);
        Task DeleteProject(Project project);
        Task<Project> GetProject(string id);
        Task<List<Project>> GetAllProjects();
    }
}
