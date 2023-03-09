using CMS.Dominio.Entidades;

namespace Personal.Interfaces
{
    public interface IProjectCollection
    {
        Task InsertProject(Project project);
        Task UpdateProject(Project project);
        Task DeleteProject(string id);
        Task<Project> GetProjectById(string id);
        Task<IEnumerable<Project>> GetAllProjects();
    }
}
