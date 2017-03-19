using System;
using System.Linq;
using RealmSample.Interfaces;
using RealmSample.Models;
using RealmSample.RealmData;

namespace RealmSample.Services
{
    public class PersonService : RealmService<Person>, IPersonService
    {
        IQueryable<Person> IPersonService.GetAll()
        {
            var items = GetAll();
            return items;
        }

        void IPersonService.Insert(Person person)
        {
            //using(var transaction = StartTransaction())
            //{
            //    Insert(person);
            //    transaction.Commit();
            //}
            Write(() =>
            {
                Insert(person);
            });
        }

        void IPersonService.Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
