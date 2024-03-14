using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using WebAPI._29._12._22.Interfaces;
using WebAPI._29._12._22.Models;


namespace WebAPI._29._12._22.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WomanController : ControllerBase
    {
        public WomanController()
        {
            byte[] img1 = Repository.ReadImage(1);
            byte[] img2 = Repository.ReadImage(2);
            byte[] img3 = Repository.ReadImage(3);
            byte[] img4 = Repository.ReadImage(4);
            byte[] img5 = Repository.ReadImage(5);

            Repository = Repository.GetInstance();
            Repository.Women.Add(new Woman { Name = "Zosya с ВИЧ", Age = 40, Image = img1, Anal = true, Classic = true, GoldenRain = true, Id = 1, Oral = true     });
            Repository.Women.Add(new Woman { Name = "Аксинья Дождливая", Age = 21, Image = img2, Anal = false, Classic = false, GoldenRain = true, Id = 2, Oral = false    });
            Repository.Women.Add(new Woman { Name = "Пока ещё теплая бабушка", Age = 87, Image = img3, Anal = true, Classic = true, GoldenRain = true, Id = 3, Oral = true });
            Repository.Women.Add(new Woman { Name = "Самая сладкая сучка", Age = 21, Image = img4, Anal = true, Classic = false, GoldenRain = false, Id = 4, Oral = false });
            Repository.Women.Add(new Woman { Name = "Я здесь главный", Age = 22, Image = img5, Anal = false, Classic = false, GoldenRain = true, Id = 5, Oral = false });
        }

        public Repository Repository;

        [HttpGet(Name = "GetWoman")]
        public IEnumerable<IFuck> Get()
        {
            return Repository.Women;
        }

        [HttpPost]
        public IActionResult Post(Woman woman)
        {
            Repository.Women.Add(woman);
            return Ok();
        }

        
    }
}
