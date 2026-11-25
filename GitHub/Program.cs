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
                    else if (userInput == 3)
                    {
                        Console.WriteLine("Enter name of new commit");
                        string nameOfNewCommit = Console.ReadLine();

                        if (!string.IsNullOrEmpty(nameOfNewCommit))
                        {
                            bool commitIsNotCompleted = true;
                            List<File> filesForCommit = new List<File>();

                            while (commitIsNotCompleted)
                            {
                                Console.WriteLine("Enter name of file to add or 0 to complete");
                                string nameOfFile = Console.ReadLine();

                                if (nameOfFile == "0")
                                {
                                    if (filesForCommit.Count == 0)
                                    {
                                        Console.WriteLine("You have to add atleast 1 file to the commit (canceling creation)");
                                        commitIsNotCompleted = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Commit is created");
                                        Commit commit = new Commit(nameOfNewCommit, filesForCommit);
                                        commitIsNotCompleted = false;
                                    }
                                }
                                else if (!string.IsNullOrEmpty(nameOfFile))
                                {
                                    File findedFile = GetFileByname(nameOfFile, files);

                                    if (findedFile != null)
                                    {
                                        filesForCommit.Add(findedFile);
                                        Console.WriteLine("File has been saved");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Wrong name of file");
                                    }
                                }
                            }
                        }
                    }
                    else if (userInput == 0)
                    {
                        Console.WriteLine("Goodbye");
                        continueProgram = false;
                    }
                    else
                    {
                        Console.WriteLine("Wrong input");
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
            Console.WriteLine("Enter 3 to make a new commit");
            Console.WriteLine("Enter 0 to stop the program");
        }

        static File GetFileByname(string nameOfFile, List<File> files)
        {
            foreach (File file in files)
            {
                if (file.Name == nameOfFile)
                {
                    return file;
                }
            }

            return null;
        }
    }
}
