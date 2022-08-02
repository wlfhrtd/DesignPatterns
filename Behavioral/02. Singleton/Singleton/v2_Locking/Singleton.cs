using System;


namespace Singleton.v2_Locking
{
    public sealed class Singleton
    {
        private static Singleton? instance = null;

        private static readonly object padlock = new object();

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
                // heavy performance hit since applying lock for every reference without check (for null) do we really need lock
                lock (padlock)
                {
                    return instance ??= new Singleton();
                }
            }
        }
    }
}
