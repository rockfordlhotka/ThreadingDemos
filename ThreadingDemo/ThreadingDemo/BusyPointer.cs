using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ThreadingDemo
{
  class BusyPointer : IDisposable
  {
    private Cursor _last;

    public BusyPointer()
    {
      _last = Cursor.Current;
      Cursor.Current = Cursors.WaitCursor;
    }

    public void Dispose()
    {
      Cursor.Current = _last;
    }
  }
}
