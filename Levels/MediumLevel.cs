using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangMadu
{

    // keskmise taseme alamklass
    internal class MediumLevel : BaseLevel
    {
        public override string Name => "Keskmine";
        public override ConsoleColor Color => ConsoleColor.Yellow;
        public override int Speed => 100;
        public override int Width => 70;
        public override int Height => 20;
    }
}
