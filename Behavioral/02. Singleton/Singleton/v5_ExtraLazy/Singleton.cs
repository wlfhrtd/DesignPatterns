using System;


namespace Singleton.v5_ExtraLazy
{
    public sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();

        // accessing any public property WILL NOT initialize instance
        public static readonly string SOMETHING = "something";
        public const double PI = 3.1415926;       

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
                return Nested.instance; // now only first instance call initializes it
            }
        }

        private class Nested
        {
            // presence of static constructor tells C# compiler not to mark type as BeforeFieldInit (relaxed type init semantic)
            // when absent - compiler may initialize type not only AT any property call but even BEFORE
            static Nested() { }
            // can't use private in nested classes
            internal static readonly Singleton instance = new Singleton();
        }
    }
}
