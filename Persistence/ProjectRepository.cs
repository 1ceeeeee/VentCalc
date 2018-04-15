using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public int CreateProject(Project project) 
        {
            context.Projects.Add(project);
            context.SaveChanges();
            return project.Id;
        }

        // public void CalculateProject(int id)
        // {
        //     var project = context.Projects
        //     .Include(p => p.Rooms)
        //         .ThenInclude(r => r.City)
        //     .Include(p => p.Rooms)
        //         .ThenInclude(r => r.BuildingType)
        //     .Include(p => p.Rooms)
        //         .ThenInclude(r => r.RoomType)
        //     .Where(p => p.Id == id)
        //     .FirstOrDefault();

        //     foreach (var item in project.Rooms)
        //     {
        //         item.Area = (item.Area != null ) ? item.Area : item.Length * item.Width;
        //         item.Volume = item.Area * item.Height;
        //         item.InflowCalc = item.Volume * item.RoomType.Inflow;
        //         item.ExhaustCalc = item.Volume * item.RoomType.Exhaust;   
        //     }
        //     context.Projects.Update(project);
        //     context.SaveChanges();
        // } 

        public async Task<Project> GetSingle(int id)
        {
            return await context.Projects
                .Include(p => p.Rooms)
                    .ThenInclude(r => r.City)
                .Include(p => p.Rooms)
                    .ThenInclude(r => r.BuildingType)
                .Include(p => p.Rooms)
                    .ThenInclude(r => r.RoomType)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}