﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GardenPlot;

/*
2,2,10,20
100,10,5,5
5, 5, 10, 10
*/

namespace GardenPlot
{
    public class UserInput
    {
        Reader reader;
        Dictionary<string, List<int>> plotsdictionary;
        string plotchoice;
        string input;
        PlotOverlap PlotOverlap;
        TotalFence TotalFence;
        MinFence MinFence;
        TotalFertilizer TotalFertilizer;
        Rotate Rotate;

        public UserInput()
        {
            Console.WriteLine("1, 2, 3, 4, or 5.");
            plotchoice = Console.ReadLine();
            //Console.WriteLine("Input where the source file is.");
            input = "plotfiles/plots.txt";// Console.ReadLine();
            //Console.WriteLine("Input where the destination file will be.");
            //string output = Console.ReadLine();
            reader = new Reader();
            plotsdictionary = reader.reader(input);
            PlotOverlap = new PlotOverlap();
            TotalFence = new TotalFence();
            MinFence = new MinFence();
            TotalFertilizer = new TotalFertilizer();
            Rotate = new Rotate();
        }

        public void Input()
        {
            
            if (plotchoice == "1")
            {
                List<string> output = PlotOverlap.checkOverlap(plotsdictionary);
                PlotOverlap.writer("plotfiles/overlapping_plots.txt", output);
            }

            if (plotchoice == "2")
            {
                int total = TotalFence.getTotalFence(plotsdictionary);
                TotalFence.writer("plotfiles/total_fencing.txt", total);
            }

            if (plotchoice == "3")
            {
                int total = MinFence.getTotalFence(plotsdictionary);
                MinFence.writer("plotfiles/minimum_fencing.txt", total);
            }

            if (plotchoice == "4")
            {
                float totalfertilizer = TotalFertilizer.GetTotalFertilizer(plotsdictionary);
                TotalFertilizer.writer("plotfiles/total_fertilizer.txt", totalfertilizer);
            }

            if (plotchoice == "5")
            {
                Console.WriteLine("Enter the desired rotation.");
                Console.WriteLine("Must be 90, 180, or 270.");
                string rotate = Console.ReadLine();

                Dictionary<string, List<int>> rotateit = Rotate.RotateAll(rotate, plotsdictionary);
                //Rotate.writer("plotfiles/rotated_plots.txt", rotateit);
            }

            if (plotchoice == "6")
            {
                foreach (KeyValuePair<string, List<int>> pair in plotsdictionary)
                {
                    Console.WriteLine("{0} - {1},{2} - {3},{4}", pair.Key, pair.Value[0], pair.Value[1], pair.Value[2], pair.Value[3]);
                }
                Console.Read();
            }
        }
    }
}