using WebAPI._29._12._22.Models;
using System.Data.SqlTypes;

namespace WebAPI._29._12._22
{
    public class Repository
    {
        private static Repository? Instance;

        public List<Woman> Women;
        private Repository()
        { Women = new List<Woman>(); }

        public static Repository GetInstance()
        {
            if (Instance == null)
                Instance = new Repository();
            return Instance;
        }
        public static byte[] ReadImage(byte id)
        {
            string imageName = (id + ".jpg");
            string fullPath = Path.Combine("C:/Users/Илья/source/repos/WebAPI.29.12.22/WebAPI.29.12.22/bin/Debug/net8.0/IdImages", imageName);
            byte[] result = File.ReadAllBytes(fullPath);
            return result;
        }
    }
}
