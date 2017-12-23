using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedundantCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            Kod obj = new Kod(7);
            int num=0;
            while (obj.AddOne())
            {
                num++;
                System.Console.WriteLine("{0} {1}", num, obj.ToString());
            }
            while (obj.SubstractOne())
            {
                num--;
                System.Console.WriteLine("{0} {1}", num, obj.ToString());
            }
            System.Console.ReadKey();
        }
    }
}
