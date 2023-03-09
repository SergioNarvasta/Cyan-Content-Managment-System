using CMS.Dominio.Entidades;

namespace CMS.Dominio.Interfaces
{
    public interface IFileCollection
    {
        Task InsertFile(FileCreate file);
        Task UpdateFile(FileClass file);
        Task DeleteFile(string id);
        Task<FileClass> GetFileById(string id);
        Task<IEnumerable<FileCreate>> GetAllFiles();
    }
}
