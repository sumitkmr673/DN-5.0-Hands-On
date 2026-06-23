using System;

namespace SingletonPatternExample

{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------Testing Singleton Pattern-----------------------\n");

            Logger logger1 = Logger.GetInstance();
            logger1.Log("This is the first message - logger1.");
            
            Logger logger2 = Logger.GetInstance();
            logger2.Log("This is the second message - logger2.");

            if (ReferenceEquals(logger1, logger2))
            {
                Console.WriteLine("\nBoth logger1 and logger2 are the same instance. [PASSED]");
            }
            else
            {
                Console.WriteLine("\nBoth variables are different instances. [FAILED]");
            }
            
        }
    }
}