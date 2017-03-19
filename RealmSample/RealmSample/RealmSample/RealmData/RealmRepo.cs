using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Realms;
using RealmSample.Annotations;
using Xamarin.Forms;

namespace RealmSample.RealmData
{
    /// <summary>
    /// A generic Realm Service that provides acces to working with realm objects in a service/repository manner
    /// </summary>
    /// <typeparam name="TRealmObject">The type of the realm object.</typeparam>
    public class RealmService<TRealmObject> where TRealmObject : RealmObject
    {
        // access to the current realm
        private readonly Realms.Realm _currentRealm;

        public RealmService()
        {
            _currentRealm = ((App) Application.Current).CurrentRealm;
        }

        /// <summary>
        /// Writes the specified action.
        /// This preforms a realm transaction.
        /// If an exception occurs during the write then the transaction is disposed of and is never commited.
        /// </summary>
        /// <param name="writeAction">The action to preform to write.</param>
        /// <exception cref="System.ArgumentNullException">writeAction</exception>
        public void Write([NotNull] Action writeAction)
        {
            if (writeAction == null) throw new ArgumentNullException(nameof(writeAction));

            _currentRealm.Write(writeAction);
        }

        /// <summary>
        /// Writes the specified action async in a worker thread.
        /// Will create a temporary realm transaction on the worker thread.
        /// If an exception occurs during the write then the transaction is disposed of and will never be commited.
        /// You can provide a callback action to <paramref name="callbackAction"/> for an action to be invoked after the write occurs.
        /// </summary>
        /// <param name="writeAction">The write action.</param>
        /// <param name="callbackAction">The callback action.</param>
        /// <returns>An async task that you can operate off of.</returns>
        /// <exception cref="System.ArgumentNullException">writeAction</exception>
        public async Task WriteAsync([NotNull] Action<Realms.Realm> writeAction, Action callbackAction)
        {
            if(writeAction == null) throw new ArgumentNullException(nameof(writeAction));

            await _currentRealm.WriteAsync(writeAction);
            callbackAction?.Invoke();
        }

        /// <summary>
        /// Inserts the specified item into the realm object to have realm start treating this a persistent object.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The object as a realm object.</returns>
        public TRealmObject Insert(TRealmObject item)
        {
            return _currentRealm.Add(item);
        }

        /// <summary>
        /// Updates the specified item inside of the realm.
        /// The item must have a primary key for it to be updated.
        /// If not then the realm object will not be found and this update will act as an insert.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The item as a realm object.</returns>
        public TRealmObject Update(TRealmObject item)
        {
            return _currentRealm.Add(item, true);
        }

        /// <summary>
        /// Preforms a bulk insert on the given items.
        /// Each of of the objects in <paramref name="items"/> will be inserted into the realm for realm to treat it as persistent object.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>All the items that were inserted as a querable.</returns>
        public IQueryable<TRealmObject> BulkInsert(IReadOnlyList<TRealmObject> items)
        {
            // for all the items automatically select and insert them
            return items.Select(Insert).AsQueryable();
        }

        /// <summary>
        /// Preforms a bulk update to the given items.
        /// If any of the items do not have a primary key then the realm object to update will not be found and the update will be preformed as an insert.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>All the items that were updated as a queryable.</returns>
        public IQueryable<TRealmObject> BulkUpdate(IReadOnlyList<TRealmObject> items)
        {
            return items.Select(Update).AsQueryable();
        }

        /// <summary>
        /// Gets the realm object by its identifier or primary key.
        /// </summary>
        /// <param name="id">The primary key.</param>
        /// <returns>The realm object that was found.</returns>
        public TRealmObject GetById(long id)
        {
            return _currentRealm.Find<TRealmObject>(id);
        }

        /// <summary>
        ///Gets the realm object by its identifier or primary key.
        /// </summary>
        /// <param name="id">The primary key.</param>
        /// <returns>The realm object that was found.</returns>
        public TRealmObject GetById(string id)
        {
            return _currentRealm.Find<TRealmObject>(id);
        }

        /// <summary>
        /// Gets all the realm objects.
        /// </summary>
        /// <returns></returns>
        public IQueryable<TRealmObject> GetAll()
        {
            return _currentRealm.All<TRealmObject>();
        }

        /// <summary>
        /// Gets all the realm objects.
        /// </summary>
        /// <param name="predicate">The predicate to filter the realm objects we need by.</param>
        /// <returns>All of the realm objects.</returns>
        public IQueryable<TRealmObject> GetAll(Expression<Func<TRealmObject, bool>> predicate)
        {
            return _currentRealm.All<TRealmObject>().Where(predicate);
        }

        /// <summary>
        /// Removes/Deletes the object from the realm.
        /// </summary>
        /// <param name="id">The primary key.</param>
        public void Remove(long id)
        {
            var realmItem = GetById(id);
            _currentRealm.Remove(realmItem);
        }

        /// <summary>
        /// Removes/Deletes the object from the realm.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Remove(string id)
        {
            var realmItem = GetById(id);
            _currentRealm.Remove(realmItem);
        }

        /// <summary>
        /// Removes/Deletes the object from the realm.
        /// <paramref name="item"/> must be a persistent Realm object that was already added to the Realm.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="item"/> is null.</exception>
        /// <exception cref="RealmSample.RealmData.RealmObjectNotManagedException">Thrown when <paramref name="item"/> is not currently managed by Realm</exception>
        public void Remove([NotNull]TRealmObject item)
        {
            if(item == null) throw new ArgumentNullException(nameof(item));
            if(!item.IsManaged) throw new RealmObjectNotManagedException();

            _currentRealm.Remove(item);
        }

        /// <summary>
        /// Starts the write transaction.
        /// Can be used to create scope for object updates.
        /// </summary>
        /// <example>
        /// using(var write in StartTransaction())
        /// {
        ///      // Preform any inserts, updates, or deletes in here
        /// }
        /// </example>
        /// <returns>A realm transaction to provide scope to read and write realm objects.</returns>
        public Transaction StartTransaction()
        {
            return _currentRealm.BeginWrite();
        }
    }
}
