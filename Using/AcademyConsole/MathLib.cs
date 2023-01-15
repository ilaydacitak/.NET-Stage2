using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyConsole
{
    public class MathLib : IDisposable
    {
        public bool IsDisposed { get; private set; } = false;

        public void Dispose()
        {
            IsDisposed = true;

        }

        public void Show()
        {
            System.Console.WriteLine("Dispose Status {0}", IsDisposed);
        }
    }
}
