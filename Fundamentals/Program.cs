using System;

/*
 * Demo of fundamentals
 * by Joe Mayo
 */

class Program { }
namespace Fundamentals
{
    class Program
    {
        static void Main()
        {
            MyNamespace.Program myProg = new MyNamespace.Program();
            Program currProg = new Program();
            // variables

            char grade = 'A';
            int twitterFriends = 2000;
            string firstName = "Joe";
            string lastName = "Mayo";
            double percent = 100;
            decimal price = 9.95m;

            // statements

            string fullName = firstName + " " + lastName;

            Console.WriteLine("Name: {0}, Friends: {1}", fullName, twitterFriends);

            if (percent == 100)
                Console.WriteLine("Done!");

            if (percent < 50)
            {
                Console.WriteLine("Just getting started...");
            }
            else if (percent < 100)
            {
                Console.WriteLine("Keep going.");
            }
            else
            {
                Console.WriteLine("Done!");
            }

            switch (grade)
            {
                case 'A':
                    Console.WriteLine("Outstanding!!");
                    break;
                case 'B':
                    Console.WriteLine("Excellent!");
                    break;
                case 'C':
                    Console.WriteLine("Satisfactory.");
                    break;
                default:
                    Console.WriteLine("Keep trying.");
                    break;
            }

            // loops

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(i);
            }

            float[] measurements = new float[] {1.2f, 3.4f, 1.2f, 3.4f};
            foreach (float measurement in measurements)
            {
                Console.WriteLine(measurement);
            }

            while (true)
            {
                Console.WriteLine("This executes only one time.");
                break;
            }

            do
            {
                Console.WriteLine("This executes only one time.");
                break;
            } while (true);

            Console.ReadKey();
        }
    }
}

namespace MyNamespace
{
    class Program
    {

    }
}
