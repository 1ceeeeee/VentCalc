using System.Collections.Generic;
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

         public async Task<List<Project>> ReadAll()
         {
            return await context.Projects.ToListAsync();
         }

        public async Task<Project> ReadSingle(int id)
        {
            return await context.Projects
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Project> Create(Project project)
        {   
            context.Projects.Add(project);
            context.SaveChanges();
            return await context.Projects.FirstOrDefaultAsync(r => r.Id == project.Id);
        }

        public async Task<Project> Update(Project project)
        {
            context.Projects.Update(project);
            context.SaveChanges();
            return await context.Projects.FirstOrDefaultAsync(r => r.Id == project.Id);
        }

        public void Delete(int id)
        {
            var project = context.Projects.FirstOrDefault(r => r.Id == id);
            context.Projects.Remove(project);
            context.SaveChanges();
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


    }
}