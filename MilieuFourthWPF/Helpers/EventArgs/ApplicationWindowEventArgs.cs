using System;
using System.Collections.Generic;
using System.Text;

namespace MilieuFourthWPF
{
    public class ApplicationWindowEventArgs : EventArgs
    {
        public readonly ApplicationWindowControlEnum PreviousPage;
        public ApplicationWindowEventArgs(ApplicationWindowControlEnum prevPage)
        {
            PreviousPage = prevPage;
        }
    }
}
