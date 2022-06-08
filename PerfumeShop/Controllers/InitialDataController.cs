using Microsoft.AspNetCore.Mvc;
using PerfumeShop.DataAccess;
using PerfumeShop.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PerfumeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitialDataController : ControllerBase
    {
        private readonly PerfumeContext _context;

        public InitialDataController(PerfumeContext context)
        {
            _context = context;
        }


        // POST api/<InitialDataController>
        [HttpPost]
        public IActionResult Post()
        {
            var categories = new List<Category>
            {
                new Category
                {
                    CategoryName = "Men"
                },
                new Category
                {
                    CategoryName = "Woman"
                },
                new Category
                {
                    CategoryName = "Unisex"
                }
            };

            var brands = new List<Brand>
            {
                new Brand
                {
                    BrandName = "Armani"
                },
                new Brand
                {
                    BrandName = "Burberry"
                },
                new Brand
                {
                    BrandName = "Calvin Klein"
                },
                new Brand
                {
                    BrandName = "Carolina Herrera"
                },
                new Brand
                {
                    BrandName = "Cartier"
                },
                new Brand
                {
                    BrandName = "Gucci"
                },
                new Brand
                {
                    BrandName = "Hugo Boss"
                },
                new Brand
                {
                    BrandName = "Lacoste"
                },
                new Brand
                {
                    BrandName = "Prada"
                },
                new Brand
                {
                    BrandName = "Tom Ford"
                },
                new Brand
                {
                    BrandName = "Versace"
                },
                new Brand
                {
                    BrandName = "YSL"
                },
            };

            var productTypes = new List<ProductType>
            {
                new ProductType
                {
                    Type = "Perfume"
                },
                new ProductType
                {
                    Type = "Eau de toilette"
                },
                new ProductType
                {
                    Type = "Perfume water"
                }
            };

            var milliliters = new List<Milliliter>
            {
                new Milliliter
                {
                    Capacity = 30
                },
                new Milliliter
                {
                    Capacity = 50
                },
                new Milliliter
                {
                    Capacity = 75
                },
                new Milliliter
                {
                    Capacity = 100
                },
                new Milliliter
                {
                    Capacity = 150
                }
            };

            var perfumes = new List<Perfume>
            {
                new Perfume
                {
                    Name = "Eros man Edt",
                    Description = "Versace je lansirao Eros - miris inspirisan i duboko povezan sa grčkom mitologijom. Cilj ovog izdanja je otkriti i razuzdati neobuzdane strasti, naglasiti želje. Miris je nazvan po grčkom bogu ljubavi i sinu boginje Afrodite - Erosu. Inspiracija Starom Grčkom traje još iz vremena kada je Gianni Versace dizao svoju modnu imperiju i za simbol brenda uzeo mitološku Meduzu koja krasi mnoge proizvode ove kuće, pa i novu bočicu muškog parfema Eros.",
                    Brand = brands.ElementAt(10),
                    Category = categories.ElementAt(0),
                },
                new Perfume
                {
                    Name = "Bad Boy man Edt",
                    Description = "Brend Carolina Herrera je u svoj novi parfem Bad Boy Le Parfum upleo mit o večitoj pobuni a novi muški miris je odraz iznenađujućih nota koje odlikuju jaku i energičnu ličnost. Prateći uspeh Bad Boy poaletne vode, ovaj novi parfem je beg od tradicionalnih formula koji donosi novi olifaktivni univerzum zasnovan na dualnosti modernog muškarca",
                    Brand = brands.ElementAt(9),
                    Category = categories.ElementAt(0),
                },
                new Perfume
                {
                    Name = "Dylan Blue man Edt",
                    Description = "Dylan Blue je esencija današnjeg Versace muškarca. Ovo je miris prepun karaktera i individualnosti, izraz muževne snage i harizme. Sviđa mi se kako uzima tradicionalne note i čini ih potpuno modernim, potpuno svežim za danas, i sutra.",
                    Brand = brands.ElementAt(10),
                    Category = categories.ElementAt(0),
                },
                new Perfume
                {
                    Name = "Luna Rossa Ocean Man Edt",
                    Description = "Luna Rossa OCEAN novi je miris za muškarce kuće PRADA. Magnetičan poziv u nove avanture, utemeljen na ideji da s tehnologijom možemo pomerati svoje granice, ostvariti ono što je nekada bilo nemoguće i otkrivati nove vidike. ",
                    Brand = brands.ElementAt(8),
                    Category = categories.ElementAt(0),
                },
            };

            var perfumeProductTypes = new List<PerfumeProductType>
            {
               new PerfumeProductType
               {
                   Perfume = perfumes.ElementAt(0),
                   ProductType = productTypes.ElementAt(0)
               },
               new PerfumeProductType
               {
                   Perfume = perfumes.ElementAt(0),
                   ProductType = productTypes.ElementAt(1)
               },
               new PerfumeProductType
               {
                   Perfume = perfumes.ElementAt(0),
                   ProductType = productTypes.ElementAt(2)
               },
               new PerfumeProductType
               {
                   Perfume = perfumes.ElementAt(1),
                   ProductType = productTypes.ElementAt(0)
               },
               new PerfumeProductType
               {
                   Perfume = perfumes.ElementAt(2),
                   ProductType = productTypes.ElementAt(0)
               },
               new PerfumeProductType
               {
                   Perfume = perfumes.ElementAt(2),
                   ProductType = productTypes.ElementAt(2)
               },
               new PerfumeProductType
               {
                   Perfume = perfumes.ElementAt(3),
                   ProductType = productTypes.ElementAt(0)
               },
               new PerfumeProductType
               {
                   Perfume = perfumes.ElementAt(3),
                   ProductType = productTypes.ElementAt(2)
               },
            };

            var perfumeMilliliters = new List<PerfumeMilliliter>
            {
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(0),
                   Milliliter = milliliters.ElementAt(0)
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(0),
                   Milliliter = milliliters.ElementAt(1)
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(0),
                   Milliliter = milliliters.ElementAt(2)
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(0),
                   Milliliter = milliliters.ElementAt(3)
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(0),
                   Milliliter = milliliters.ElementAt(4)
               },

               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(1),
                   Milliliter = milliliters.ElementAt(0)
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(1),
                   Milliliter = milliliters.ElementAt(1)
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(1),
                   Milliliter = milliliters.ElementAt(2)
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(1),
                   Milliliter = milliliters.ElementAt(3)
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(1),
                   Milliliter = milliliters.ElementAt(4)
               },

               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(2),
                   Milliliter = milliliters.ElementAt(0)
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(2),
                   Milliliter = milliliters.ElementAt(1)
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(2),
                   Milliliter = milliliters.ElementAt(2)
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(2),
                   Milliliter = milliliters.ElementAt(3)
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(2),
                   Milliliter = milliliters.ElementAt(4)
               },

               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(3),
                   Milliliter = milliliters.ElementAt(0)
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(3),
                   Milliliter = milliliters.ElementAt(1)
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(3),
                   Milliliter = milliliters.ElementAt(2)
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(3),
                   Milliliter = milliliters.ElementAt(3)
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(3),
                   Milliliter = milliliters.ElementAt(4)
               },
            };

            _context.Categories.AddRange(categories);
            _context.Brands.AddRange(brands);
            _context.ProductTypes.AddRange(productTypes);
            _context.Milliliters.AddRange(milliliters);
            _context.Perfumes.AddRange(perfumes);
            _context.PerfumeProductTypes.AddRange(perfumeProductTypes);
            _context.PerfumeMilliliters.AddRange(perfumeMilliliters);


            _context.SaveChanges();

            return StatusCode(StatusCodes.Status201Created);

        }

    }
}
