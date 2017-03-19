using Ninject;
using Ninject.Modules;
using Realms;
using RealmSample.Modules;
using RealmSample.RealmData;
using RealmSample.ViewModels;
using Xamarin.Forms;

namespace RealmSample
{
    public partial class App : Application
    {
        /// <summary>
        /// Gets or sets the kernal.
        /// This can be used to get services that were loaded from the kernal.
        /// </summary>
        /// <value>
        /// The kernal.
        /// </value>
        public IKernel Kernal { get; set; }

        /// <summary>
        /// Gets the current realm database that the application is working with.
        /// </summary>
        /// <value>
        /// The current realm database.
        /// </value>
        public Realms.Realm CurrentRealm { get; }

        public App(params INinjectModule[] patformModules)
        {
            InitializeComponent();
            var mainPage = new NavigationPage(new MainPage());

            // setup and get an instance to our current Realm
            CurrentRealm = Realms.Realm.GetInstance(new RealmConfiguration
            {
                SchemaVersion = RealmConfigure.SchemaVersion,
                MigrationCallback = RealmConfigure.MigrationCallback,
            });

            CurrentRealm.Write(() =>
            {
                CurrentRealm.RemoveAll();
            });
            
            // Register all the our core services with the kernal
            Kernal = new StandardKernel(new CoreModule(), new NavigationModule(mainPage.Navigation));
            // Register all of our platform specific modules with the kernal
            Kernal.Load(patformModules);

            mainPage.BindingContext = Kernal.Get<MainViewModel>();
            MainPage = mainPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            CurrentRealm.RemoveAll();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
