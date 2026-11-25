using System.Security.Cryptography.X509Certificates;

namespace GitHub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Repository> repositories = new List<Repository>();
            List<File> files = new List<File>();
            bool continueProgram = true;

            while (continueProgram)
            {
                PrintInfo();
                bool isUserInputParseSuccess = int.TryParse(Console.ReadLine(), out int userInput);

                if (isUserInputParseSuccess)
                {
                    if (userInput == 1)
                    {
                        Console.WriteLine("Enter name of new repository");
                        string nameOfNewRepository = Console.ReadLine();

                        if (!string.IsNullOrEmpty(nameOfNewRepository))
                        {
                            Repository repository = new Repository(nameOfNewRepository);
                            Console.WriteLine("Success");
                        }
                        else
                        {
                            Console.WriteLine("Wrong input");
                        }
                    }
                    else if (userInput == 2)
                    {
                        Console.WriteLine("Enter name of new file");
                        string nameOfFile = Console.ReadLine();
                        
                        if (!string.IsNullOrEmpty(nameOfFile)) 
                        {
                            Console.WriteLine("Enter text of file");
                            string textOfFile = Console.ReadLine();
                            
                            if (!string.IsNullOrEmpty(textOfFile))
                            {
                                File file = new File(nameOfFile, textOfFile);
                                files.Add(file);
                                Console.WriteLine("Success");
                            }
                        }
                    }
                    else if (userInput == 0)
                    {
                        Console.WriteLine("Goodbye");
                        continueProgram = false;
                    }
                }
                else
                {
                    Console.WriteLine("Input is not a number");
                }
            }
        }

        static void PrintInfo()
        {
            Console.WriteLine("Enter 1 to make a new repository");
            Console.WriteLine("Enter 2 to add new file");
            Console.WriteLine("Enter 0 to stop the program");
        }
    }
}
