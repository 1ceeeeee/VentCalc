using System;

namespace VentCalc.Persistence {
    public abstract class CrudBase : BaseEntity {

        public int? CreateUserId { get; set; }

        public int? UpdateUserId { get; set; }

        public int? DeleteUsertId { get; set; }

        public DateTime? CreateDate { get; set; } = DateTime.Now;

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        protected CrudBase(int createUserId) {
            CreateUserId = createUserId;
            CreateDate = DateTime.Now;
        }

        protected CrudBase() {
            CreateDate = DateTime.Now;
        }
    }
}