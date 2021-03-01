using System;
using System.Collections.Generic;
using System.Text;

namespace MilieuFourthWPF
{
    public class ApplicationWindowEventArgs : EventArgs
    {
        public readonly ApplicationWindowPageEnum PreviousPage;
        public ApplicationWindowEventArgs(ApplicationWindowPageEnum prevPage)
        {
            PreviousPage = prevPage;
        }
    }
}
