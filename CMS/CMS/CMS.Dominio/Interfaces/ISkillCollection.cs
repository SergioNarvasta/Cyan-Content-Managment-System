using CMS.Dominio.Entidades;

namespace Personal.Interfaces
{
    public interface ISkillCollection
    {
        Task DeleteFile(string id);
        Task<IEnumerable<Skill>> GetAllSkills();
        Task InsertSkill(Skill skill);
    }
}
