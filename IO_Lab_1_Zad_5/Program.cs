using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IO_Lab_1_Zad_5
{
    class Program
    {
        public static int SIZE_Tab = 256;
        public static int SIZE_Frag = 32;
        public static int Sum = 0;
        static int[] tab = new int[SIZE_Tab];
        public static readonly object Lock = new object();
        static void Main(string[] args)
        {
            
            Random rnd = new Random();
            for (int i = 0; i < SIZE_Tab; i++)
                tab[i] = rnd.Next(0, 100);

            int pom = sum(tab, 0, SIZE_Tab);
            Console.WriteLine("Suma testowa: " + pom);
            
          
            int count = SIZE_Tab / SIZE_Frag;
            AutoResetEvent[] are = new AutoResetEvent[count];

            for (int i = 0; i < count; i++)
                are[i] = new AutoResetEvent(false);

            for (int i = 0; i < count; i++)
                ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadSum), new object[] { i * SIZE_Frag, (i + 1) * SIZE_Frag, are[i] });      
            WaitHandle.WaitAll(are);
            Console.WriteLine("Suma na watkach: " + Sum);

        }
        static void ThreadSum(Object stateInfo)
        {
            var start_pom = ((object[])stateInfo)[0];
            var end_pom = ((object[])stateInfo)[1];
            AutoResetEvent are = ((object[])stateInfo)[2] as AutoResetEvent;
            int start = (int)start_pom;
            int end = (int)end_pom;
            int pom = sum(tab, start, end);
            Sum += pom;
            are.Set();
        }

        static int sum(int[] tab, int start, int end)
        {
            lock (Lock)
            {
                int pom = 0;
                for (int i = start; i < end; i++)
                {
                    pom += tab[i];
                }
                return pom;
            }
        }

    }
}
