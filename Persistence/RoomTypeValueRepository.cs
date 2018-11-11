using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VentCalc.Models;

namespace VentCalc.Persistence
{
    public class RoomTypeValueRepository : IRoomTypeValueRepository
    {
        private readonly VentCalcDbContext context;
        public RoomTypeValueRepository(VentCalcDbContext context)
        {
            this.context = context;
        }

    }
}