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
        private static AutoResetEvent event_1 = new AutoResetEvent(true);
        static void Main(string[] args)
        {
            
            Random rnd = new Random();
            for (int i = 0; i < SIZE_Tab; i++)
                tab[i] = rnd.Next(0, 100);
            for (int i = 0; i < SIZE_Tab; i++)
                Console.WriteLine(tab[i] + " ");
            int count = SIZE_Tab / SIZE_Frag;
            for(int i = 0; i < count; i++)
                ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadSum), new object[] { i * SIZE_Frag, (i + 1) * SIZE_Frag });

            //WaitHandle.WaitAll();
            Console.WriteLine(Sum);

        }
        static void ThreadSum(Object stateInfo)
        {
            var start_pom = ((object[])stateInfo)[0];
            var end_pom = ((object[])stateInfo)[1];
            int start = (int)start_pom;
            int end = (int)end_pom;
            int pom = sum(tab, start, end);
            Sum += pom;
        }

        static int sum(int[] tab, int start, int end)
        {
            int pom = 0;
            for(int i = start; i < end; i++)
            {
                pom += tab[i];
            }
            return pom;
        }

    }
}
