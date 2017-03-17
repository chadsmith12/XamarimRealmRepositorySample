using System;
using System.Threading.Tasks;
using RealmSample.Interfaces;

namespace RealmSample.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Private Fields
        #endregion

        #region Constructors
        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
        #endregion

        #region Methods
        public override Task Init()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Properties
        #endregion
    }
}
