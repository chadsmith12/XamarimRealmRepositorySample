using System;

namespace RealmSample.RealmData
{
    /// <summary>
    /// Exception that is thrown when some kind of action was tried to be preformed on an object that is not a persistent Realm Object.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class RealmObjectNotManagedException : Exception
    {
        public RealmObjectNotManagedException() : base("Object is not managed by Realm. Make sure the item you insert has been added and is a persistent object in Realm.")
        {
        }

        public RealmObjectNotManagedException(string message) : base(message)
        {
            
        }

        public RealmObjectNotManagedException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}
