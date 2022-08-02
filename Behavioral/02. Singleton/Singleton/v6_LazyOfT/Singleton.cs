using System;


namespace Singleton.v6_LazyOfT
{
    public sealed class Singleton
    {
        // no null checks just use Lazy<T>
        private static readonly Lazy<Singleton> lazy = new(() => new Singleton());
        // accessing any public property WILL NOT initialize instance
        public static readonly string SOMETHING = "something";

        // private parameterless; if need parameters look for Factory
        private Singleton()
        {
            // can only be instantiated from within class
            Logger.Log("Constructor invoked.");
        }


        public static Singleton Instance
        {
            get
            {
                Logger.Log("Instance called.");
                return lazy.Value; // Lazy<T> usage
            }
        }
    }
}
