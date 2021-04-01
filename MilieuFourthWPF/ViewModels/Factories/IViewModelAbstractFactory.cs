namespace MilieuFourthWPF
{
    public interface IViewModelAbstractFactory
    {
        BaseViewModel CreateViewModel(ApplicationWindowControlEnum appPageEnum);
    }
}
