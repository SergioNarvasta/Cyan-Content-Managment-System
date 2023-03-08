using Personal.Models;

namespace Personal.Interfaces
{
    public interface IFileCollection
    {
        Task InsertFile(FileClass file);
        Task UpdateFile(FileClass file);
        Task DeleteFile(string id);
        Task<FileClass> GetFileById(string id);
        Task<IEnumerable<FileClass>> GetAllFiles();
    }
}
