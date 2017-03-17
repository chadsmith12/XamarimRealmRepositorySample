using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Ninject.Modules;
using RealmSample.Modules;
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

        public App(params INinjectModule[] patformModules)
        {
            InitializeComponent();
            var mainPage = new NavigationPage(new MainPage());

            // Register all the our core services with the kernal
            Kernal = new StandardKernel(new CoreModule(), new NavigationModule(mainPage.Navigation));
            // Register all of our platform specific modules with the kernal
            Kernal.Load(patformModules);

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
