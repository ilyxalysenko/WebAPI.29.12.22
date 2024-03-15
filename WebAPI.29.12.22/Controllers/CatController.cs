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
    public class CatController : ControllerBase
    {
        public CatController()
        {
            byte[] img1 = Repository.ReadImage(1);
            byte[] img2 = Repository.ReadImage(2);
            byte[] img3 = Repository.ReadImage(3);
            byte[] img4 = Repository.ReadImage(4);
            byte[] img5 = Repository.ReadImage(5);

            Repository = Repository.GetInstance();
            Repository.Kitties.Add(new Cat {Name = "Дорожка", Age = 3, Id = 1, Description = "", Image = img1});
            Repository.Kitties.Add(new Cat {Name = "Подмышка", Age = 1, Id = 2, Description = "", Image = img2});
            Repository.Kitties.Add(new Cat {Name = "Гремлин", Age = 12, Id = 3, Description = "", Image = img3});
            Repository.Kitties.Add(new Cat {Name = "Крысофаг", Age = 5, Id = 4, Description = "", Image = img4});
        }                                                                                         

        public Repository Repository;

        [HttpGet(Name = "GetCat")]
        public IEnumerable<ITailable> Get()
        {
            return Repository.Kitties;
        }

        [HttpPost]
        public IActionResult Post(Cat cat)
        {
            Repository.Kitties.Add(cat);
            return Ok();
        }

        
    }
}
