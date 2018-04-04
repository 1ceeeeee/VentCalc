using VentCalc.Models;

namespace VentCalc.Persistence
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly VentCalcDbContext context;
        public ProjectRepository(VentCalcDbContext context)
        {
            this.context = context;
        }

        // public Project GetAirExchangeReport(Project project)
        // {
            
        // }
    }
}