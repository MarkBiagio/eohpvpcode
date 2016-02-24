using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVP.DomainModel
{
    public abstract class Entity
    {
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var entity = obj as Entity;

            return this.Id.Equals(entity.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
