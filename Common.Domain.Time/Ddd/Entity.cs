using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Domain.Ddd
{
    public abstract class Entity<T>
    {
        public T Id { get; protected set; }
        public int Version { get; set; }

        //public string CreatedBy { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public string LastModifiedBy { get; set; }
        //public DateTime? LastModifiedDate { get; set; }
    }

    public abstract class Entity<T1, T2>
    {
        public T1 Id { get; protected set; }
        public T2 UniqueId { get; set; }
        public int Version { get; set; }
    }
}
