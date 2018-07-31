using System.ComponentModel.DataAnnotations;

namespace VentCalc.Persistence
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }        
        
    }
}