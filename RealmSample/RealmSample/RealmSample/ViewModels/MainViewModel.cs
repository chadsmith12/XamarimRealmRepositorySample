using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using RealmSample.Interfaces;
using RealmSample.Models;

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
            var test = _personService.GetAll().ToList();
            People = new ObservableCollection<Person>(test);

            _personService.Insert(new Person
            {
                FirstName = "Chad",
                LastName = "Smith"
            });
            _personService.Insert(new Person
            {
                FirstName = "Maria",
                LastName = "Lopez"
            });
            _personService.Insert(new Person
            {
                FirstName = "Priscilla",
                LastName = "Gonzalez"
            });
            // Todo: Grab the people from Realm Here
            var people = _personService.GetAll();

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
