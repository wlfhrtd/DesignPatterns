using System;


namespace Singleton.v1_Naive
{
    // non-thread-safe implementation
    public sealed class Singleton
    {
        private static Singleton? instance;

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
                return instance ??= new Singleton(); // X number of threads here will call constructor X times
            }
        }      
    }
}
