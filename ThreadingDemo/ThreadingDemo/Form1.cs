using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingDemo
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private int _uiThread;

    private void Form1_Load(object sender, EventArgs e)
    {
      _uiThread = Thread.CurrentThread.ManagedThreadId;
    }


    private void toolStripButton1_Click(object sender, EventArgs e)
    {
      textBox1.Clear();
      using (new BusyPointer())
        SingleThread();
    }

    private void toolStripButton2_Click(object sender, EventArgs e)
    {
      textBox1.Clear();
      using (new BusyPointer())
        TwoThreads();
    }

    private void toolStripButton3_Click(object sender, EventArgs e)
    {
      textBox1.Clear();
      using (new BusyPointer())
        FourThreads();
    }

    private void toolStripButton4_Click(object sender, EventArgs e)
    {
      textBox1.Clear();
      using (new BusyPointer())
        ThreadPool();
    }

    private void toolStripButton5_Click(object sender, EventArgs e)
    {
      toolStrip1.Enabled = false;
      textBox1.Clear();
      var bw = new BackgroundWorker();
      bw.DoWork += (o, arg) =>
      {
        //SingleThread();
        TwoThreads();
        //FourThreads();
        //ThreadPool();
        //TPL();
      };
      bw.RunWorkerCompleted += (o, arg) =>
      {
        WriteLine("Background worker complete");
        toolStrip1.Enabled = true;
      };
      bw.RunWorkerAsync();
    }

    private void toolStripButton6_Click(object sender, EventArgs e)
    {
      textBox1.Clear();
      using (new BusyPointer())
        TPL();
    }

    // ==============================================================================
    // ==============================================================================

    private delegate void WriteLineDelegate1();
    private delegate void WriteLineDelegate2(object arg);
    private delegate void WriteLineDelegate3(string format, params object[] args);

    private void WriteLine()
    {
      if (Thread.CurrentThread.ManagedThreadId != _uiThread)
        this.BeginInvoke(new WriteLineDelegate1(() =>
          {
            WriteLine();
          }));
      else
        textBox1.AppendText(Environment.NewLine);
    }

    private void WriteLine(object arg)
    {
      if (Thread.CurrentThread.ManagedThreadId != _uiThread)
        this.BeginInvoke(new WriteLineDelegate2((e) =>
        {
          WriteLine(e);
        }), arg);
      else
      {
        textBox1.AppendText(arg.ToString());
        WriteLine();
      }
    }

    private void WriteLine(string format, params object[] args)
    {
      if (Thread.CurrentThread.ManagedThreadId != _uiThread)
        this.BeginInvoke(new WriteLineDelegate3((o, e) =>
        {
          WriteLine(o, e);
        }), format, args);
      else
      {
        textBox1.AppendText(string.Format(format, args));
        WriteLine();
      }
    }

    public void SingleThread()
    {
      var start = DateTime.Now;

      double resolution = .00001;
      var area = AreaCalculator.FindArea(.001, 1000, resolution);

      var end = DateTime.Now;
      var time = end - start;

      WriteLine(area);

      WriteLine();
      WriteLine("Done in {0}.{1} seconds", time.Seconds, time.Milliseconds);
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
          WriteLine("Thread {0}", Thread.CurrentThread.ManagedThreadId);
          ((ThreadResult)o).Area = AreaCalculator.FindArea(.001, 500, resolution);
        });
      var t2 = new Thread((o) =>
        {
          WriteLine("Thread {0}", Thread.CurrentThread.ManagedThreadId);
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

      WriteLine(area);

      WriteLine();
      WriteLine("Done in {0}.{1} seconds", time.Seconds, time.Milliseconds);
    }

    public void FourThreads()
    {
      var start = DateTime.Now;

      double resolution = .00001;
      double area = 0;

      var t1 = new Thread((o) =>
      {
        WriteLine("Thread {0}", Thread.CurrentThread.ManagedThreadId);
        ((ThreadResult)o).Area = AreaCalculator.FindArea(.001, 250, resolution);
      });
      var t2 = new Thread((o) =>
      {
        WriteLine("Thread {0}", Thread.CurrentThread.ManagedThreadId);
        ((ThreadResult)o).Area = AreaCalculator.FindArea(250 + resolution, 500, resolution);
      });
      var t3 = new Thread((o) =>
      {
        WriteLine("Thread {0}", Thread.CurrentThread.ManagedThreadId);
        ((ThreadResult)o).Area = AreaCalculator.FindArea(500 + resolution, 750, resolution);
      });
      var t4 = new Thread((o) =>
      {
        WriteLine("Thread {0}", Thread.CurrentThread.ManagedThreadId);
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

      WriteLine(area);

      WriteLine();
      WriteLine("Done in {0}.{1} seconds", time.Seconds, time.Milliseconds);
    }

    public void ThreadPool()
    {
      var start = DateTime.Now;

      double resolution = .00001;
      double area = 0;
      int step = 4;

      var results = new List<double> { 0, 0, 0, 0 };

      var done = new AutoResetEvent(false);
      int counter = 0;

      for (int loop = 0; loop <= step - 1; loop++)
      {
        System.Threading.ThreadPool.QueueUserWorkItem((o) =>
          {
            int idx = (int)o;
            WriteLine("Thread {0}:{1}", idx, Thread.CurrentThread.ManagedThreadId);
            results[idx] = AreaCalculator.FindArea(idx * (1000 / step) + .001, (idx + 1) * (1000 / step), resolution);
            Interlocked.Increment(ref counter);
            done.Set();
          }, loop);
      }

      while (counter < step)
        done.WaitOne();

      area = (from r in results select r).Sum();

      var end = DateTime.Now;
      var time = end - start;

      WriteLine(area);

      WriteLine();
      WriteLine("Done in {0}.{1} seconds", time.Seconds, time.Milliseconds);
    }

    public void TPL()
    {
      var start = DateTime.Now;

      double resolution = .00001;
      double area = 0;
      int step = 4;

      var results = new List<double> { 0, 0, 0, 0 };

      Parallel.For(0, step, (idx) =>
        {
          WriteLine("Thread {0}:{1}", idx, Thread.CurrentThread.ManagedThreadId);
          results[idx] = AreaCalculator.FindArea(idx * (1000 / step) + .001, (idx + 1) * (1000 / step), resolution);
        });

      area = (from r in results select r).Sum();

      var end = DateTime.Now;
      var time = end - start;

      WriteLine(area);

      WriteLine();
      WriteLine("Done in {0}.{1} seconds", time.Seconds, time.Milliseconds);
    }
  }
}
