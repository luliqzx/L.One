using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.One.Domain.Entity
{
    public interface IAuditable
    {
        string CreateBy { get; set; }
        DateTime? CreateDate { get; set; }
        string CreateTerminal { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }
        string UpdateTerminal { get; set; }
        int Version { get; }
    }
}
