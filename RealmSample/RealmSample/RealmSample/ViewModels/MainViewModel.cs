using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Realms;
using RealmSample.Interfaces;
using RealmSample.Models;
using Xamarin.Forms;

namespace RealmSample.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Private Fields

        private readonly IPersonService _personService;
        #endregion

        #region Properties
        public ObservableCollection<Person> People { get; set; }
        #endregion

        #region Constructors
        public MainViewModel(INavigationService navigationService, IPersonService personService) : base(navigationService)
        {
            People = new ObservableCollection<Person>();
            _personService = personService;
        }
        #endregion

        #region Methods
        public override async Task Init()
        {
            var currentRealm = Realm.GetInstance();

            currentRealm.Write(() =>
            {
                currentRealm.Add(new Person
                {
                    FirstName = "Chad",
                    LastName = "Smith",
                    Age = 27,
                    Email = "Smith.Chad12@gmail.com",
                    PhoneNumber = "2147296420"
                });
                currentRealm.Add(new Person
                {
                    FirstName = "Maria",
                    LastName = "Lopez",
                    Age = 27,
                    Email = "Smith.Chad12@gmail.com",
                    PhoneNumber = "2147296420"
                });
                currentRealm.Add(new Person
                {
                    FirstName = "Priscilla",
                    LastName = "Gonzalez",
                    Age = 27,
                    Email = "Smith.Chad12@gmail.com",
                    PhoneNumber = "2147296420"
                });
            });

            var people = currentRealm.All<Person>();

            if (people != null)
            {
                People = new ObservableCollection<Person>(people);
            }
        }
        #endregion

        #region Properties
        #endregion
    }
}
