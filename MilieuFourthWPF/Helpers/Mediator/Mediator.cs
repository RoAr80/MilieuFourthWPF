using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilieuFourthWPF
{
    public delegate void MessageReceivedEventHandler(object sender, object message);
    public class Mediator
    {
        public event MessageReceivedEventHandler MessageReceived;

        public void Send(object sender, object message)
        {
            MessageReceived?.Invoke(sender, message);
        }
    }
}
