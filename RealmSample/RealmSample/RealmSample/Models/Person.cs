using Realms;

namespace RealmSample.Models
{
    public class Person : RealmObject
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int Age { get; set; }
    }
}
