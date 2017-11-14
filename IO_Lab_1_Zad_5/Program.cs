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

        static void Main(string[] args)
        {
            int[] tab = new int[SIZE_Tab];
            Random rnd = new Random();
            for (int i = 0; i < SIZE_Tab; i++)
                tab[i] = rnd.Next(0, 100);
            for (int i = 0; i < SIZE_Tab; i++)
                Console.WriteLine(tab[i] + " ");
               
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
