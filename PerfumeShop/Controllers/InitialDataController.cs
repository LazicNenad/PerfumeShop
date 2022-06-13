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
                new Brand
                {
                    BrandName = "PACCO RABANNE"
                },
                new Brand
                {
                    BrandName = "DSQUARED2"
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

                new Perfume
                {
                    Name = "Hero Man Edt",
                    Description = "Miris je pojačan iskričavom notom bergamota i okrepljujućom smrekom i crnim biberom. Srce odiše toplotom kedrovine sa tri jedinstvena i različita podneblja – Virdžinija, Atlas planine i Himalaji. ‘Burberry Hero predstavlja dvojnost snage i osetljivosti. Istovremeno predstavlja bezvremenost Burberry brenda i modernu muževnost.",
                    Brand = brands.ElementAt(1),
                    Category = categories.ElementAt(0),
                },

                new Perfume
                {
                    Name = "Original Man Edp",
                    Description = "DSQUARED2 Original Man edp perfume.",
                    Brand = brands.ElementAt(12),
                    Category = categories.ElementAt(2),
                },

                new Perfume
                {
                    Name = "Phantom Man Edt",
                    Description = "Zakoračite u Paco svet i pridružite se intergalaktičkoj zabavi gde možete biti šta god želite. Nije bitno ko ste, nije bitno sa koje planete dolazite. Futuristički aromatični miris, zeleni bljesak limuna sa zavodljivom kremastom lavandom. Prvi parfem nastao ljudskom kreativnošću pokrenutom veštačkom inteligencijom.",
                    Brand = brands.ElementAt(13),
                    Category = categories.ElementAt(0),
                },

                new Perfume
                {
                    Name = "Crystal Noir Woman Edp",
                    Description = "Ona ima držanje, korača visoko podignute glave, sa onim samo njoj svojstvenim osmehom. Poseduje urođenu sposobnost da uvek bude seksi i izuzetno samouverena. Ima razvijen smisao za modu i eleganciju, voli raskoš i ekscentričnost i glamur sveta Heaute Couture.",
                    Brand = brands.ElementAt(10),
                    Category = categories.ElementAt(1),
                },

                new Perfume
                {
                    Name = "Libre Woman Edp",
                    Description = "Novi YSL parfem Libre je miris slobode, namenjen onima koji žive po svojim pravilima. Ovaj floralni miris kombinuje esenciju lavande iz Francuske sa senzualnim marokanskim cvetom narandže i kreira jedinstvenu cvetnu fuziju koju komplementira smela nota akorda mošusa. Libre znači slobodna i slavi slobodu: miris namenjen onima koji žele i koji se usuđuju da budu to što jesu.",
                    Brand = brands.ElementAt(11),
                    Category = categories.ElementAt(1),
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

               new PerfumeProductType
               {
                   Perfume = perfumes.ElementAt(4),
                   ProductType = productTypes.ElementAt(1)
               },
               new PerfumeProductType
               {
                   Perfume = perfumes.ElementAt(4),
                   ProductType = productTypes.ElementAt(2)
               },

               new PerfumeProductType
               {
                   Perfume = perfumes.ElementAt(5),
                   ProductType = productTypes.ElementAt(0)
               },
               new PerfumeProductType
               {
                   Perfume = perfumes.ElementAt(5),
                   ProductType = productTypes.ElementAt(1)
               },
               new PerfumeProductType
               {
                   Perfume = perfumes.ElementAt(5),
                   ProductType = productTypes.ElementAt(2)
               },

               new PerfumeProductType
               {
                   Perfume = perfumes.ElementAt(6),
                   ProductType = productTypes.ElementAt(0)
               },

               new PerfumeProductType
               {
                   Perfume = perfumes.ElementAt(7),
                   ProductType = productTypes.ElementAt(0)
               },
            };

            var perfumeMilliliters = new List<PerfumeMilliliter>
            {
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(0),
                   Milliliter = milliliters.ElementAt(0),
                   UnitPrice = 5000
                   
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(0),
                   Milliliter = milliliters.ElementAt(1),
                   UnitPrice = 5900
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(0),
                   Milliliter = milliliters.ElementAt(2),
                   UnitPrice = 6800
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(0),
                   Milliliter = milliliters.ElementAt(3),
                   UnitPrice = 9000
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(0),
                   Milliliter = milliliters.ElementAt(4),
                   UnitPrice = 15000
               },

               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(1),
                   Milliliter = milliliters.ElementAt(0),
                   UnitPrice = 6300
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(1),
                   Milliliter = milliliters.ElementAt(1),
                   UnitPrice = 7300
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(1),
                   Milliliter = milliliters.ElementAt(2),
                   UnitPrice = 9500
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(1),
                   Milliliter = milliliters.ElementAt(3),
                   UnitPrice = 11300
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(1),
                   Milliliter = milliliters.ElementAt(4),
                   UnitPrice = 16300
               },

               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(2),
                   Milliliter = milliliters.ElementAt(0),
                   UnitPrice = 7400
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(2),
                   Milliliter = milliliters.ElementAt(1),
                   UnitPrice = 8500
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(2),
                   Milliliter = milliliters.ElementAt(2),
                   UnitPrice = 10300
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(2),
                   Milliliter = milliliters.ElementAt(3),
                   UnitPrice = 14300
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(2),
                   Milliliter = milliliters.ElementAt(4),
                   UnitPrice = 22700
               },

               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(3),
                   Milliliter = milliliters.ElementAt(0),
                   UnitPrice = 5300
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(3),
                   Milliliter = milliliters.ElementAt(1),
                   UnitPrice = 6300
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(3),
                   Milliliter = milliliters.ElementAt(2),
                   UnitPrice = 8700
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(3),
                   Milliliter = milliliters.ElementAt(3),
                   UnitPrice = 13300
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(3),
                   Milliliter = milliliters.ElementAt(4),
                   UnitPrice = 17500
               },

               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(4),
                   Milliliter = milliliters.ElementAt(0),
                   UnitPrice = 4700
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(4),
                   Milliliter = milliliters.ElementAt(1),
                   UnitPrice = 7500
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(4),
                   Milliliter = milliliters.ElementAt(2),
                   UnitPrice = 8700
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(4),
                   Milliliter = milliliters.ElementAt(3),
                   UnitPrice = 15000
               },
               new PerfumeMilliliter
               {
                   Perfume = perfumes.ElementAt(4),
                   Milliliter = milliliters.ElementAt(4),
                   UnitPrice = 22500
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
