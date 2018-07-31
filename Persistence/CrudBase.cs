using System;

namespace VentCalc.Persistence {
    public abstract class CrudBase : BaseEntity {   

        public int CreateUserId { get; set; }    

        public int? UpdateUserId { get; set; }

        public int? DeleteUsertId { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DateDelete { get; set; }
    }
}