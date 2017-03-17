using Ninject.Modules;

namespace RealmSample.Droid.Modules
{
    /// <summary>
    /// Loads the Android platform specific services into the kernel.
    /// Use this method to bind all android platform specific services
    /// </summary>
    public class PlatformModule : NinjectModule
    {
        public override void Load()
        {
            // Bind Platform Specific Modules Here
            // Example: Bind<ILocationService>().To<LocationService>().InSingletonScope();
        }
    }
}