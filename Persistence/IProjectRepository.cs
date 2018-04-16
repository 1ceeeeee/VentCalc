using System.Collections.Generic;
using System.Threading.Tasks;
using VentCalc.Models;

namespace VentCalc.Persistence
{
    public interface IProjectRepository
    {
         Task<List<Project>> ReadAll();
         Task<Project> ReadSingle(int id);
         Task<Project> Create(Project project);
         Task<Project> Update(Project project);
         void Delete(int id);
    }
}