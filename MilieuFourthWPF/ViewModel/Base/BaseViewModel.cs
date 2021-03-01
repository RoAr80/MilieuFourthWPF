using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MilieuFourthWPF
{
    public class BaseViewModel : INotifyPropertyChanged
    {


        #region INotifyPropertyChanged Implementation
        /// <summary>
        /// The event that is fired when any child property changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Call this to fire a <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public void CallerPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        ///// <summary>
        ///// A global lock for property checks so prevent locking on different instances of expressions.
        ///// Considering how fast this check will always be it isn't an issue to globally lock all callers.
        ///// </summary>
        //protected object mPropertyValueCheckLock = new object();

        //protected async Task RunCommandAsync(Expression<Func<bool>> updatingFlag, Func<Task> action)
        //{
        //    // Lock to ensure single access to check
        //    lock (mPropertyValueCheckLock)
        //    {
        //        // Check if the flag property is true (meaning the function is already running)
        //        if (updatingFlag.GetPropertyValue())
        //            return;

        //        // Set the property flag to true to indicate we are running
        //        updatingFlag.SetPropertyValue(true);
        //    }

        //    try
        //    {
        //        // Run the passed in action
        //        await action();
        //    }
        //    finally
        //    {
        //        // Set the property flag back to false now it's finished
        //        updatingFlag.SetPropertyValue(false);
        //    }
        //}
    }
}
