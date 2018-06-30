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

        public RoomTypeValue GetRoomTypeValue(Project project, int roomTypeId)
        {
            int idRoomTypeValue = 0;
            var roomTypeValueList = context.RoomTypeValues.Where(rtv => rtv.RoomTypeId == roomTypeId).ToList();
            
            if (roomTypeValueList.Count > 1)
            {
                //Общая площадь всех помещений проекта
                var areaTotal = project.Rooms.Sum(r => (r.Area != null) ? r.Area : r.Length * r.Width);
                //общее кол-во людей во всех помещениях
                var peopleAmountTotal = project.Rooms.Sum(r => r.PeopleAmount);

                var peoplePerSquareMeter = areaTotal/peopleAmountTotal;

                switch (roomTypeId)
                {
                    case 8:
                        idRoomTypeValue = (peoplePerSquareMeter < 20) ? 5 : 6;
                        break;
                    case 9:
                        idRoomTypeValue = (peoplePerSquareMeter < 20) ? 7 : 8;
                        break;
                    case 15:
                        idRoomTypeValue = (peoplePerSquareMeter < 20) ? 14 : 15;
                        break;
                    case 20:
                        idRoomTypeValue = (peoplePerSquareMeter < 20) ? 20 : 21;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                idRoomTypeValue = roomTypeValueList.SingleOrDefault(rtv => rtv.RoomTypeId == roomTypeId).Id;
            }
            var roomTypeValue = context.RoomTypeValues.SingleOrDefault(rtv => rtv.Id == idRoomTypeValue);
            return roomTypeValue;
        }
    }
}