using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace SetConnetionString
{
    class ConnectionStringFile
    {
        string ConnectionString;
        string PathConfig;
        string Format;
        ConnectionStringFile()
        {
            Format = ".txt";
            Hello();
            SetString();
            SetFolder();
            Console.WriteLine("Write now?(Y/N)");
            if (ReadChoice())
            {
                File.WriteAllText(PathConfig, ConnectionString + Format);
            }
        }

        static void Main(string[] args)=>new ConnectionStringFile();

        void Hello()
        {
            Console.WriteLine("Hello!\n");
            Console.WriteLine("\r\nThis application is developed for configuring" +
                " a configuration file that will store the database connection string.");
        }
        void SetString()
        {
            Console.Write("\r\n\r\nPlease provide your connection string:");
            ConnectionString = Console.ReadLine();
            Console.WriteLine("\r\n\r\nIs everything specified correctly?(Y/N) " + $"\n{ConnectionString}\r\n\r\n");

            bool correctly = ReadChoice();
            Console.Clear();
            if ( !correctly ) { Console.WriteLine("It is not correctly \n"); SetString(); }
        }
        void SetFolder()
        {
            Console.WriteLine("Now let's decide on the directory to store the configuration. " +
                "Please enter the path to this directory:");
            PathConfig = Console.ReadLine();
            Console.WriteLine("\r\n\r\nIs everything specified correctly?(Y/N) " + $"\n{PathConfig}\r\n\r\n");

            bool correctly = ReadChoice();
            Console.Clear();
            if (!correctly) { Console.WriteLine("It is not correctly \n"); SetFolder(); }
        }
        bool ReadChoice()
        {
            string choice = Console.ReadLine();
            bool result = false;
            switch (choice.ToLower())
            {
                case "y":
                    result = true;
                    return result;
                    break;
                case "n":
                    return false;
                    break;
                default:
                    
                    return false;
                    break;
            }
        }
    }
}
