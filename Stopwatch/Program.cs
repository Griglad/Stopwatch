using System;
using System.Collections.Generic;
using System.Threading;

namespace Stopwatch
{
    class Program
    {
        static void Main(string[] args)
        {

            var stopWatch = new Stopwatch();
            int milliseconds = 3000;


            Begin(stopWatch);
            Thread.Sleep(milliseconds);
            Terminate(stopWatch);
            ShowResult(stopWatch);


            
            Begin(stopWatch);
            Thread.Sleep(milliseconds);
            Terminate(stopWatch);
            ShowResult(stopWatch);
            

            Begin(stopWatch);
            Thread.Sleep(milliseconds);
            Terminate(stopWatch);
            ShowResult(stopWatch);

            Begin(stopWatch);
            Thread.Sleep(milliseconds);
            Terminate(stopWatch);
            ShowResult(stopWatch);

            Begin(stopWatch);
            Thread.Sleep(milliseconds);
            Terminate(stopWatch);
            ShowResult(stopWatch);
          

        }


        static void Begin(Stopwatch stopWatch)
        {
            try
            {

                stopWatch.Start();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(-1);

            }

        }
        static void Terminate(Stopwatch stopWatch)
        {

            try
            {

                stopWatch.Stop();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(-1);

            }
        }
        static void ShowResult(Stopwatch stopWatch)
        {

            stopWatch.ShowElapsedTime();

        }








    }

}
