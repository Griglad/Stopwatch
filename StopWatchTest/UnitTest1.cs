using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StopWatchTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using Stopwatch;
    using System.Threading;
    using System.Linq;
    using System.Collections.Generic;

    namespace TestProject1
    {
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            [ExpectedException(typeof(InvalidOperationException))]
            public void Attempt_ToStopTheWatchBeforeItStarts_ThrowsAnException()
            {

                var stopWatch = new Stopwatch();
                stopWatch.Stop();

            }


            [TestMethod]
            [ExpectedException(typeof(InvalidOperationException))]
            public void Attempt_ToStartTheWatchTwice_ThrowsAnException()
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                stopWatch.Start();


            }


            [TestMethod]
            [DataRow(3000)]
            public void Attempt_‘ÔCheckAll_TheAddedTime_InDictionary_After_Multiple_StartsAndStops(int milliseconds)
            {

                var stopWatch = new Stopwatch();
                stopWatch.Start();
                Thread.Sleep(milliseconds);
                stopWatch.Stop();
                var elapsed = stopWatch.ElapsedTime;

                stopWatch.Start();
                Thread.Sleep(milliseconds);
                stopWatch.Stop();
                elapsed = stopWatch.ElapsedTime;

                stopWatch.Start();
                Thread.Sleep(milliseconds);
                stopWatch.Stop();
                elapsed = stopWatch.ElapsedTime;


                stopWatch.Start();
                Thread.Sleep(milliseconds);
                stopWatch.Stop();
                elapsed = stopWatch.ElapsedTime;

                int totalMilliseconds = milliseconds * elapsed.Count;

                var totalDuration = stopWatch.Durations.ElementAt(elapsed.Count - 1).Value;

                Assert.AreEqual((totalMilliseconds / 1000), Math.Abs((int)totalDuration.TotalSeconds));

            }

        }
    }


}
