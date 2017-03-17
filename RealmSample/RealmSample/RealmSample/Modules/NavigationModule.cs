using Ninject.Modules;
using RealmSample.Interfaces;
using RealmSample.Services;
using RealmSample.ViewModels;
using Xamarin.Forms;

namespace RealmSample.Modules
{
    public class NavigationModule : NinjectModule
    {
        #region Private Fields
        // the navigation service that gets binded.
        private readonly INavigation _formsNavigation;
        #endregion

        #region Constructors        
        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationModule"/> class.
        /// </summary>
        /// <param name="formsNavigation">The forms navigation.</param>
        public NavigationModule(INavigation formsNavigation)
        {
            _formsNavigation = formsNavigation;
        }
        #endregion

        #region Load Kernals
        /// <summary>
        /// Loads/registers the navigation mappings into the kernel.
        /// This is where you need to register your View Model to View Mappings
        /// </summary>
        public override void Load()
        {
            // make the navigation service to register the view models to the view mappings
            var navigationService = new NavigationService
            {
                XamarinNavigation = _formsNavigation
            };

            // Register View Model to View Mappings Here
            navigationService.RegisterViewMapping(typeof(MainViewModel), typeof(MainPage));

            // Bind the Navigation Service
            Bind<INavigationService>().ToMethod(x => navigationService).InSingletonScope();
        }
        #endregion
    }
}
