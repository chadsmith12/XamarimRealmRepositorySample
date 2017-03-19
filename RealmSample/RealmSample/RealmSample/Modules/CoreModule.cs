using Ninject.Modules;
using RealmSample.Interfaces;
using RealmSample.Services;
using RealmSample.ViewModels;

namespace RealmSample.Modules
{
    /// <summary>
    /// The Core Modules/Services that need to be loaded/inejcted in.
    /// </summary>
    /// <seealso>
    ///     <cref>Ninject.Modules.NinjectModule</cref>
    /// </seealso>
    public class CoreModule : NinjectModule
    {
        /// <summary>
        /// Loads the core services into the kernel.
        /// Use this method to bind all view models and core services
        /// </summary>
        public override void Load()
        {
            // Bind ViewModels here
            // Example:
            // Bind<MainViewModel>().ToSelf();
            Bind<MainViewModel>().ToSelf();

            // Bind Core Services
            // Example:
            // var dataService = new DataService();
            // Bind<IDataService>().ToMethod(x => dataService);
            Bind<IPersonService>().ToMethod(x => new PersonService());
        }
    }
}
