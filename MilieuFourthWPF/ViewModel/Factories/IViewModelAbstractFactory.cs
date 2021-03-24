namespace MilieuFourthWPF
{
    public interface IViewModelAbstractFactory
    {
        BaseViewModel CreateViewModel(ApplicationWindowPageEnum appPageEnum);
    }
}
