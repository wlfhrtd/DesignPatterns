using System;


namespace Singleton.v3_BetterLocking
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
                // double-checked locking algorithm
                // acquire lock only when needed - if only instance is null ~~ better performance
                if (instance == null)
                {
                    lock(padlock)
                    {
                        instance ??= new Singleton();
                    }
                }

                return instance;
            }
        }
    }
}
