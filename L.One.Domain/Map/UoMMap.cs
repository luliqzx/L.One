using FluentNHibernate.Mapping;
using L.One.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.One.Domain.Map
{
  public  class UoMMap:ClassMap<UoM>
    {
      public UoMMap()
      {
          this.Id(x => x.Id).GeneratedBy.Assigned();
          this.Map(x => x.Description).Unique();

          this.HasMany(x => x.UoMConversion).KeyColumn("BaseUoM").Cascade.AllDeleteOrphan().Inverse();

          #region Audit Trail

          this.Map(x => x.CreateBy);
          this.Map(x => x.CreateDate);
          this.Map(x => x.CreateTerminal);
          this.Map(x => x.UpdateBy);
          this.Map(x => x.UpdateDate);
          this.Map(x => x.UpdateTerminal);
          this.Version(x => x.Version).CustomType<int>();

          #endregion
      }
    }
}
