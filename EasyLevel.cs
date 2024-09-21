using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangMadu
{
    internal class EasyLevel : BaseLevel
    {
        public override string Name => "Easy";
        public override ConsoleColor Color => ConsoleColor.Green;
        public override int Speed => 200;
        public override int Width => 80;
        public override int Height => 25;
    }
}
