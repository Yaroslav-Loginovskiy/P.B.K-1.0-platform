using QuizPrototype.Data.Models;
using System;
using System.Threading;

namespace QuizPrototype.Services
{
    public static class TimerService
    {

        public static void StartTimer(Object obj)
        {

            int? userTime = (int)obj;
           
             
            userTime = userTime * 60;
            // Создайте AutoResetEvent, чтобы сигнализировать о пороге тайм-аута в
            //  обратный вызов таймера достигнут.
            var autoEvent = new AutoResetEvent(false);

            var statusChecker = new StatusChecker(userTime);

            // Создать таймер который вызывает CheckStatus после одной секунды     Create a timer that invokes CheckStatus after one second, 
            // и каждые последующие 1/4 секунды                                    and every 1/4 second thereafter.
            Console.WriteLine("{0:h:mm:ss.fff} Creating timer.\n",
                              DateTime.Now);
            var stateTimer = new Timer(statusChecker.CheckStatus,
                                       autoEvent, 0, 100);

            autoEvent.WaitOne();
            var result = statusChecker.GetResult();
            stateTimer.Dispose();
            
            Console.WriteLine("\nDestroying timer.");
        }


    }
    class StatusChecker
    {
        private int? maxCount;
        public StatusChecker(int? count)
        {

            maxCount = count;
        }

        // This method is called by the timer delegate.
        public void CheckStatus(Object stateInfo)
        {
            AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;

            //  Console.WriteLine("Time left: {0}", maxCount--);
            maxCount--;

            if (maxCount == 180)
            {
                Console.WriteLine("3 minutes remaining...");
            }
            else
            {
                if (maxCount == 120)
                {
                    Console.WriteLine("2 minutes remaining...");
                }
                else
                {
                    if (maxCount == 60)
                    {
                        Console.WriteLine(" 1 minute remaining...");
                    }
                    else
                    {
                        if (maxCount <= 0)
                        {
                            autoEvent.Set();
                            

                        }
                    }
                }
            }


        }

        public bool GetResult()
        {
            return false;
        }
    }

}



