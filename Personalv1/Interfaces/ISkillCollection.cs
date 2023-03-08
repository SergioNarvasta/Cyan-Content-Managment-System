using Personal.Models;

namespace Personal.Interfaces
{
    public interface ISkillCollection
    {
        Task DeleteFile(string id);
        Task<IEnumerable<Skill>> GetAllSkills();
        Task InsertSkill(Skill skill);
    }
}
