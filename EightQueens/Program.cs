using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EightQueens
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<double> number = new List<double>();
            EightQueen queen = new EightQueen(13);
            Stopwatch sWatch = new Stopwatch();
            //queen.GetSolution();
            for (int i = 0; i <= 2; i++)
            {
                sWatch.Restart();
                int rezult = queen.GetSolution();
                sWatch.Stop();
                TimeSpan tSpan;
                tSpan = sWatch.Elapsed;
                Console.WriteLine(tSpan.ToString());
                Console.WriteLine(rezult);
            }
            Console.ReadKey();
        }
    }
}
