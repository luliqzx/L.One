using L.One.Cons.Controller;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.One.Cons
{
    class Program
    {
        static IActorController ActorController { get; set; }

        static void Main(string[] args)
        {
            var container = new Container();
            Bootstrap.Start(container);
            ActorController = container.GetInstance<IActorController>();
            ActorController.Delete();
            ActorController.Create();

        }
    }
}
