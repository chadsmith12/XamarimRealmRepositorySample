using System;
using System.ComponentModel;
using System.Threading.Tasks;
using RealmSample.ViewModels;

namespace RealmSample.Interfaces
{
    public interface INavigationService
    {
        /// <summary>
        /// Gets a value indicating whether we can go back in the navigation stack.
        /// </summary>
        /// <value>
        /// <c>true</c> if we can go back; otherwise, <c>false</c>.
        /// </value>
        bool CanGoBack { get; }

        /// <summary>
        /// Goes back to the previous page in the navigation stack.
        /// </summary>
        /// <returns></returns>
        Task GoBack();

        /// <summary>
        /// Navigates to the view model type.
        /// </summary>
        /// <param name="asModal">Navigates to the view as a modal</param>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <returns></returns>
        Task NavigateTo<TViewModel>(bool asModal = false) where TViewModel : BaseViewModel;

        /// <summary>
        /// Navigates to view model type
        /// Takes in a parameter to pass in to the view model
        /// enables the use of a strongly typed parameter to be passed into the navigation
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <typeparam name="TParameter">The type of the parameter.</typeparam>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        Task NavigateTo<TViewModel, TParameter>(TParameter parameter) where TViewModel : BaseViewModel;

        /// <summary>
        /// Removes the last view from the navigation stack.
        /// </summary>
        /// <returns></returns>
        Task RemoveLastView();

        /// <summary>
        /// Clears the back stack.
        /// </summary>
        /// <returns></returns>
        Task ClearBackStack();

        /// <summary>
        /// Navigates to the specified URI.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns></returns>
        Task NavigateToUri(Uri uri);

        /// <summary>
        /// Occurs when [can go back changed].
        /// </summary>
        event PropertyChangedEventHandler CanGoBackChanged;
    }
}
