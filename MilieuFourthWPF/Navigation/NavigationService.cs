using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MilieuFourthWPF
{
    public class NavigationService : INavigationService
    {
        //public BaseViewModel currentPage;
        public BaseViewModel CurrentPage { get; private set; }
        public ApplicationWindowControlEnum CurrentPageEnum { get; set; }
        public long UserSessionLocalId { get; set; }
        IViewModelAbstractFactory _viewModelAbstractFactory;
        public NavigationService(IViewModelAbstractFactory viewModelAbstractFactory)
        {
            _viewModelAbstractFactory = viewModelAbstractFactory;            
            //CurrentPage = _viewModelAbstractFactory.CreateViewModel(ApplicationWindowPageEnum.LoginAndRegPage);
            //NavigateTo(ApplicationWindowPageEnum.LoginAndRegPage);
        }

        public void NavigateTo(ApplicationWindowControlEnum appPageEnum)
        {
            var vm = _viewModelAbstractFactory.CreateViewModel(appPageEnum);

            // Property Injection O_o. Как будто должно быть в другом месте
            vm._navigationService = this;
            //Dispatcher.CurrentDispatcher.Invoke(() => CurrentPage = vm);
            CurrentPage = vm;
            ApplicationWindowControlEnum prevPage = CurrentPageEnum;
            CurrentPageEnum = appPageEnum;
            // ToDo: исправить второй аргумент
            PageChanged?.Invoke(this, new ApplicationWindowEventArgs(prevPage));

        }

        public void NavigateTo(ApplicationWindowControlEnum appPageEnum, object payload)
        {
            throw new NotImplementedException();
        }

        public event EventHandler<ApplicationWindowEventArgs> PageChanged;


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
    }


}

