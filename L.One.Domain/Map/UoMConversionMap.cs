using FluentNHibernate.Mapping;
using L.One.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.One.Domain.Map
{
    public class UoMConversionMap : ClassMap<UoMConversion>
    {
        public UoMConversionMap()
        {
            this.CompositeId()
                .KeyReference(x => x.BaseUoM, "BaseUoM")
                .KeyReference(x => x.ConvUoM, "ConvUoM");
            //this.References(x => x.BaseUoM).Column("BaseUoM");
            this.Map(x => x.BaseQty).Default("0");
            this.Map(x => x.ConvQty).Default("0");
        }
    }
}
