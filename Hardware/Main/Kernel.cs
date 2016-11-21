using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Hardware;
using Display;
using Cosmos.HAL;
using System.Diagnostics;

namespace Hardware
{
    public class Kernel : Sys.Kernel
    {
        DisplayDriver display;
        protected override void BeforeRun()
        {
            display = new DisplayDriver();
        }

        protected override void Run()
        {
            display.init();
            
        }
    }
}
