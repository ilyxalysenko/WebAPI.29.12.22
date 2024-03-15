using WebAPI._29._12._22.Models;
using System.Data;
using System.Data.SqlClient;

namespace WebAPI._29._12._22
{
    public class Repository
    {
        static string connectionString = "Server=(locarldb)\\mssqllocaldb;Database=master;Trusted_Connection=True;";

        private static Repository? Instance;
        private static string Directory = "C:/Users/Илья/source/repos/WebAPI.29.12.22/WebAPI.29.12.22/bin/Debug/net8.0/IdImages";

        public List<Cat> Kitties;
        private Repository()
        { Kitties = new List<Cat>(); }

        public static Repository GetInstance()
        {
            if (Instance == null)
                Instance = new Repository();
            return Instance;
        }
        public static byte[] ReadImage(byte id)
        {
            string imageName = (id + ".jpg");
            string fullPath = Path.Combine(Directory, imageName);
            byte[] result = File.ReadAllBytes(fullPath);
            return result;
        }
    }
}
