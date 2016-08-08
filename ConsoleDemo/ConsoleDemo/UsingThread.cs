using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication1
{
  class UsingThread
  {
    public void SingleThread()
    {
      var start = DateTime.Now;

      double resolution = .00001;
      var area = AreaCalculator.FindArea(.001, 1000, resolution);

      var end = DateTime.Now;
      var time = end - start;

      Console.WriteLine(area);

      Console.WriteLine();
      Console.WriteLine("Done in {0}.{1} seconds", time.Seconds, time.Milliseconds);
    }

    private class ThreadResult
    {
      public double Area { get; set; }
    }

    public void TwoThreads()
    {
      var start = DateTime.Now;

      double resolution = .00001;
      double area = 0;

      var t1 = new Thread((o) =>
        {
          Console.WriteLine("Thread {0}", Thread.CurrentThread.ManagedThreadId);
          ((ThreadResult)o).Area = AreaCalculator.FindArea(.001, 500, resolution);
        });
      var t2 = new Thread((o) =>
        {
          Console.WriteLine("Thread {0}", Thread.CurrentThread.ManagedThreadId);
          ((ThreadResult)o).Area = AreaCalculator.FindArea(500 + resolution, 1000, resolution);
        });
      var t1r = new ThreadResult();
      t1.Start(t1r);
      var t2r = new ThreadResult();
      t2.Start(t2r);
      
      t1.Join();
      t2.Join();

      area = t1r.Area + t2r.Area;

      var end = DateTime.Now;
      var time = end - start;

      Console.WriteLine(area);

      Console.WriteLine();
      Console.WriteLine("Done in {0}.{1} seconds", time.Seconds, time.Milliseconds);
    }

    public void FourThreads()
    {
      var start = DateTime.Now;

      double resolution = .00001;
      double area = 0;

      var t1 = new Thread((o) =>
      {
        Console.WriteLine("Thread {0}", Thread.CurrentThread.ManagedThreadId);
        ((ThreadResult)o).Area = AreaCalculator.FindArea(.001, 250, resolution);
      });
      var t2 = new Thread((o) =>
      {
        Console.WriteLine("Thread {0}", Thread.CurrentThread.ManagedThreadId);
        ((ThreadResult)o).Area = AreaCalculator.FindArea(250 + resolution, 500, resolution);
      });
      var t3 = new Thread((o) =>
      {
        Console.WriteLine("Thread {0}", Thread.CurrentThread.ManagedThreadId);
        ((ThreadResult)o).Area = AreaCalculator.FindArea(500 + resolution, 750, resolution);
      });
      var t4 = new Thread((o) =>
      {
        Console.WriteLine("Thread {0}", Thread.CurrentThread.ManagedThreadId);
        ((ThreadResult)o).Area = AreaCalculator.FindArea(750 + resolution, 1000, resolution);
      });

      var t1r = new ThreadResult();
      t1.Start(t1r);
      var t2r = new ThreadResult();
      t2.Start(t2r);
      var t3r = new ThreadResult();
      t3.Start(t3r);
      var t4r = new ThreadResult();
      t4.Start(t4r);

      t1.Join();
      t2.Join();
      t3.Join();
      t4.Join();

      area = t1r.Area + t2r.Area + t3r.Area + t4r.Area;

      var end = DateTime.Now;
      var time = end - start;

      Console.WriteLine(area);

      Console.WriteLine();
      Console.WriteLine("Done in {0}.{1} seconds", time.Seconds, time.Milliseconds);
    }

    public void ThreadPool()
    {
      var start = DateTime.Now;

      double resolution = .00001;
      double area = 0;

      var results = new List<double> { 0, 0, 0, 0 };

      var done = new AutoResetEvent(false);
      int counter = 0;

      for (int loop = 0; loop <= 3; loop++)
      {
        System.Threading.ThreadPool.QueueUserWorkItem((o) =>
          {
            int idx = (int)o;
            Console.WriteLine("Thread {0}:{1}", idx, Thread.CurrentThread.ManagedThreadId);
            results[idx] = AreaCalculator.FindArea(idx * 250 + .001, (idx + 1) * 250, resolution);
            Interlocked.Increment(ref counter);
            done.Set();
          }, loop);
      }

      while (counter < 4)
        done.WaitOne();

      area = (from r in results select r).Sum();

      var end = DateTime.Now;
      var time = end - start;

      Console.WriteLine(area);

      Console.WriteLine();
      Console.WriteLine("Done in {0}.{1} seconds", time.Seconds, time.Milliseconds);
    }
  }
}
