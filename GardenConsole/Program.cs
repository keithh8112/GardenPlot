﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GardenPlot;

namespace GardenConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInput user = new UserInput();
            user.Input(args);
        }
    }
}
