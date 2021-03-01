using System;

namespace MilieuFourthWPF
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}