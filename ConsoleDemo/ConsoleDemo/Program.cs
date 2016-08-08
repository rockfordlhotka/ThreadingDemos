using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Press <enter> to start");
      Console.ReadLine();

      var worker = new UsingThread();
      worker.SingleThread();
      worker.TwoThreads();
      worker.FourThreads();
      worker.ThreadPool();
      worker.ThreadPool();
      Console.ReadLine();
    }
  }
}
