using System.Threading.Tasks;
using VentCalc.Models;

namespace VentCalc.Persistence
{
    public interface IProjectRepository
    {
        int CreateProject(Project project); 
        void CalculateProject(int id);
        Task<Project> GetSingle (int id);
    }
}