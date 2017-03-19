using Realms;

namespace RealmSample.RealmData
{
    /// <summary>
    /// This class is used to configure your realm.
    /// </summary>
    public static class RealmConfigure
    {
        /// <summary>
        /// The current version of the shema.
        /// Change this value when you are preforming a migration to let realm know what version of the schema it is working with.
        /// </summary>
        public const ulong SchemaVersion = 0;

        /// <summary>
        /// The callback function that realm will run when it needs to preform a migration.
        /// This will be called anytime realm needs to preform a migration
        /// </summary>
        /// <param name="migration">The migration.
        /// Gives you access to the new realm and the old realm that the migration is preforming.
        /// </param>
        /// <param name="oldSchemaVersion">The old schema version that we are migrating from.</param>
        public static void MigrationCallback(Migration migration, ulong oldSchemaVersion)
        {
            switch (oldSchemaVersion)
            {
                default:
                    break;
            }
        }
    }
}
