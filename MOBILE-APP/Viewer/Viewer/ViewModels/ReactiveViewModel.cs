using ReactiveUI;


namespace Viewer.ViewModels
{
    public abstract class ReactiveViewModel : ReactiveObject, ISupportsActivation
    {
        public ViewModelActivator Activator { get; }

        protected ReactiveViewModel() : this(new ViewModelActivator())
        {
            
        }

        protected ReactiveViewModel(ViewModelActivator viewModelActivator)
        {
            Activator = viewModelActivator;
        }
    }
}