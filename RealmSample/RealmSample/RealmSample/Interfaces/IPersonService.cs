using System.Collections.Generic;
using System.Linq;
using RealmSample.Models;
using RealmSample.RealmData;

namespace RealmSample.Interfaces
{
    public interface IPersonService
    {
        IQueryable<Person> GetAll();

        void Insert(Person person);

        void Update(Person person);
    }
}
