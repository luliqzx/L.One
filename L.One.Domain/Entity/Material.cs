using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.One.Domain.Entity
{
    public class Material : BaseEntity<string>
    {
        public virtual string Description { get; set; }
        public virtual Actor Supplier { get; set; }
    }
}
