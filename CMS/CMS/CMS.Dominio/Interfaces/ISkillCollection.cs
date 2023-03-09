using CMS.Dominio.Entidades;

namespace CMS.Dominio.Interfaces
{
    public interface ISkillCollection
    {
        Task DeleteFile(string id);
        Task<IEnumerable<Skill>> GetAllSkills();
        Task InsertSkill(Skill skill);
    }
}
