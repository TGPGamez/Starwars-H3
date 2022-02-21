using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Starwars
{
    class Program
    {
        static List<Planet> Planets = LoadData();
        static void Main(string[] args)
        {
            Opgave1();
            Opgave2();
            Opgave3();
            Opgave4();
            Opgave5();
            Opgave6();
            Opgave7();
            Opgave8();
            Opgave9();
            Opgave10();
            Opgave11();
            Opgave12();
            Opgave13();
            Opgave14();
            Opgave15();
            Opgave16();
            Console.ReadKey();
            
        }


        public static void Opgave1()
        {
            //Lambda solution
            IEnumerable<Planet> result = Planets.Where(x => x.Name.FirstOrDefault() == 'M');
            Printresult(1, result);


        }

        public static void Opgave2()
        {
            //Lambda solution
            IEnumerable<Planet> result = Planets.Where(x => x.Name.Contains('y') || x.Name.Contains('Y'));
            Printresult(2, result);
        }

        public static void Opgave3()
        {
            //Lambda solution
            IEnumerable<Planet> result = Planets.Where(x => x.Name.Length > 9 && x.Name.Length < 15);
            Printresult(3, result);
        }

        public static void Opgave4()
        {
            //Lambda solution
            IEnumerable<Planet> result = Planets.Where(x => x.Name[1] == 'a' && x.Name.LastOrDefault() == 'e');
            Printresult(4, result);
        }

        public static void Opgave5()
        {
            //Lambda solution
            IEnumerable<Planet> result = Planets.Where(x => x.RotationPeriod > 40)
                .OrderBy(o => o.RotationPeriod);
            Printresult(5, result);
        }

        public static void Opgave6()
        {
            //Lambda solution
            IEnumerable<Planet> result = Planets.Where(x => x.RotationPeriod > 10 && x.RotationPeriod < 20)
                .OrderBy(n => n.Name);
            Printresult(6, result);
        }

        public static void Opgave7()
        {
            //Lambda solution
            IEnumerable<Planet> result = Planets.Where(x => x.RotationPeriod > 30)
                .OrderBy(n => n.Name).ThenBy(r => r.RotationPeriod);
            Printresult(7, result);
        }

        public static void Opgave8()
        {
            //Lambda solution
            IEnumerable<Planet> result = Planets.Where(x => (x.RotationPeriod < 30 || x.SurfaceWater < 50) && x.Name.Contains("ba"))
                .OrderBy(n => n.Name).ThenBy(s => s.SurfaceWater).ThenBy(r => r.RotationPeriod);
            Printresult(8, result);
        }

        public static void Opgave9()
        {
            //Lambda solution
            IEnumerable<Planet> result = Planets.Where(x => x.SurfaceWater > 0).OrderByDescending(s => s.SurfaceWater);
            Printresult(9, result);
        }

        public static void Opgave10()
        {
            //Lambda solution
            IEnumerable<Planet> result = Planets.Where(x => x.Diameter > 0 && x.Population > 0)
                .OrderBy(x => ((4 * 3.14 * Math.Pow(x.Diameter, 2)) / x.Population));
            Printresult(10, result);
        }

        public static void Opgave11()
        {
            //Lambda solution
            IEnumerable<Planet> planets_duplicate = Planets;
            IEnumerable<Planet> result = Planets.Except(planets_duplicate, new PlanetComparer());
            //Man kune bare have brugt en simpelt Where clause som nedstående.
            //IEnumerable<Planet> result = Planets.Where(x => x.RotationPeriod > 0);
            Printresult(11, result);
        }

        public static void Opgave12()
        {
            //Lambda solution
            IEnumerable<Planet> planets2 = Planets.Where(x => x.Name.ToLower().StartsWith("a") || x.Name.ToLower().EndsWith("s"));
            IEnumerable<Planet> planets3 = Planets.Where(x => x.Terrain != null && x.Terrain.Any(n => n.Contains("rainforests")));
            IEnumerable<Planet> result = planets2.Union(planets3);
            Printresult(12, result);
        }

        public static void Opgave13()
        {
            //Lambda solution
            IEnumerable<Planet> result = Planets.Where(x => x.Terrain != null && x.Terrain.Contains("deserts"));
            Printresult(13, result);
        }

        public static void Opgave14()
        {
            //Lambda solution
            IEnumerable<Planet> result = Planets.Where(x => x.Terrain != null && x.Terrain.Contains("swamps"))
                .OrderBy(r => r.RotationPeriod).ThenBy(n => n.Name);
            Printresult(14, result);
        }

        public static void Opgave15()
        {
            //Lambda solution
            IEnumerable<Planet> result = Planets.Where(x => Regex.IsMatch(x.Name, @"(aa|ee|ii|oo|uu)"));
            Printresult(15, result);
        }

        public static void Opgave16()
        {
            //Lambda solution
            IEnumerable<Planet> result = Planets.Where(x => Regex.IsMatch(x.Name, @"(kk|ll|rr|nn)"))
                .OrderByDescending(n => n.Name);
            Printresult(16, result);
        }


        private static void Printresult(int opg, IEnumerable<Planet> result)
        {
            Console.WriteLine("OPGAVE " + opg);
            Console.WriteLine(" Lambda:");
            foreach (Planet planet in result)
            {
                Console.WriteLine(" - " + planet.Name);
            }
            Console.WriteLine();
        }




        static List<Planet> LoadData()
        {
            List<Planet> planets = new List<Planet>()
            {
                new Planet { Name="Corellia", Terrain= new List<string>{ "plains", "urban", "hills", "forests" },RotationPeriod=25,SurfaceWater=70, Diameter=11000, Population=3000000000},
                new Planet { Name="Rodia", Terrain= new List<string>{ "jungles", "oceans", "urban", "swamps" },RotationPeriod=29,SurfaceWater=60, Diameter=7549, Population=1300000000},
                new Planet { Name="Nal Hutta", Terrain= new List<string>{ "urban", "oceans", "bogs", "swamps" },RotationPeriod=87, Diameter=12150, Population=7000000000},
                new Planet { Name="Dantooine",Terrain= new List<string>{ "savannas", "oceans", "mountains", "grasslands" },RotationPeriod=25, Diameter=9830,Population=1000},
                new Planet { Name="Bestine IV",Terrain= new List<string>{ "rocky islands", "oceans" },RotationPeriod=26,SurfaceWater=98, Diameter=6400,Population=62000000},
                new Planet { Name="Ord Mantell",Terrain= new List<string>{ "plains", "seas","mesas" },RotationPeriod=26,SurfaceWater=10, Diameter=14050, Population=4000000000},
                new Planet { Name="Trandosha",Terrain= new List<string>{ "mountains", "seas","grasslands" ,"deserts"},RotationPeriod=25, Diameter=0, Population=42000000},
                new Planet { Name="Socorro", Terrain= new List<string>{ "mountains", "deserts"},RotationPeriod=20, Population=300000000},
                new Planet { Name="Mon Cala",Terrain= new List<string>{ "oceans", "reefs","islands"},RotationPeriod=21,SurfaceWater=100,Diameter=11030,Population=27000000000},
                new Planet { Name="Chandrila", Terrain= new List<string>{ "plains", "forests"},RotationPeriod=20,SurfaceWater=40,Diameter=13500,Population=1200000000},
                new Planet { Name="Sullust", Terrain= new List<string>{ "mountains", "volcanoes","rocky deserts"},RotationPeriod=20,SurfaceWater=5, Diameter=12780, Population=18500000000},
                new Planet { Name="Toydaria", Terrain= new List<string>{ "swamps", "lakes"},RotationPeriod=21, Diameter=7900, Population=11000000},
                new Planet { Name="Malastare",Terrain= new List<string>{ "swamps", "deserts","jungles","mountains"},RotationPeriod=26, Diameter=18880, Population=2000000000},
                new Planet { Name="Dathomir",Terrain= new List<string>{ "forests", "deserts","savannas"},RotationPeriod=24, Diameter=10480, Population=5200},
                new Planet { Name="Ryloth",Terrain= new List<string>{ "mountains", "valleys","deserts","tundra"},RotationPeriod=30,SurfaceWater=5,Diameter=10600, Population=1500000000 },
                new Planet { Name="Aleen Minor"},
                new Planet { Name="Vulpter",Terrain= new List<string>{ "urban", "barren"} ,RotationPeriod=22, Diameter=14900, Population=421000000},
                new Planet { Name="Troiken",Terrain= new List<string>{ "desert", "tundra","rainforests","mountains"} },
                new Planet { Name="Tund",Terrain= new List<string>{ "barren", "ash"} ,RotationPeriod=48, Diameter=12190},
                new Planet { Name="Haruun Kal",Terrain= new List<string>{ "toxic cloudsea", "plateaus","volcanoes"},RotationPeriod=25,Diameter=10120,Population=705300},
                new Planet { Name="Cerea",Terrain= new List<string>{ "verdant"},RotationPeriod=27,SurfaceWater=20,Population=450000000},
                new Planet { Name="Glee Anselm",Terrain= new List<string>{ "islands","lakes","swamps", "seas"},RotationPeriod=33,SurfaceWater=80, Diameter=15600,Population=500000000},
                new Planet { Name="Iridonia",Terrain= new List<string>{ "rocky canyons","acid pools"},RotationPeriod=29},
                new Planet { Name="Tholoth"},
                new Planet { Name="Iktotch",Terrain= new List<string>{ "rocky"},RotationPeriod=22},
                new Planet { Name="Quermia",},
                new Planet { Name="Dorin",RotationPeriod=22, Diameter=13400},
                new Planet { Name="Champala",Terrain= new List<string>{ "oceans","rainforests","plateaus"},RotationPeriod=27, Population=3500000000},
                new Planet { Name="Mirial",Terrain= new List<string>{ "deserts"}},
                new Planet { Name="Serenno",Terrain= new List<string>{ "rivers","rainforests","mountains"}},
                new Planet { Name="Concord Dawn",Terrain= new List<string>{ "jungles","forests","deserts"}},
                new Planet { Name="Zolan" },
                new Planet { Name="Ojom",Terrain= new List<string>{ "oceans","glaciers"},SurfaceWater=100, Population=500000000},
                new Planet { Name="Skako", Terrain = new List<string>{ "urban","vines"},RotationPeriod=27, Population=500000000000},
                new Planet { Name="Muunilinst",Terrain= new List<string>{ "plains","forests","hills","mountains"} ,RotationPeriod=28,SurfaceWater=25, Diameter=13800, Population=5000000000},
                new Planet { Name="Shili",Terrain= new List<string>{ "cities","savannahs","seas","plains"}},
                new Planet { Name="Kalee",Terrain= new List<string>{ "rainforests","cliffs","seas","canyons"},RotationPeriod=23, Diameter=13850, Population=4000000000},
                new Planet { Name="Umbara"},
                new Planet { Name="Tatooine",Terrain= new List<string>{ "deserts"},RotationPeriod=23,SurfaceWater=1, Diameter=10465, Population=200000 },
                new Planet { Name="Jakku",Terrain= new List<string>{ "deserts"}},
                new Planet { Name="Alderaan",Terrain= new List<string>{ "grasslands","mountains"},RotationPeriod=24,SurfaceWater=40, Diameter=12500, Population= 2000000000},
                new Planet { Name="Yavin IV", Terrain= new List<string>{ "rainforests","jungle"},RotationPeriod=24,SurfaceWater=8,Diameter=10200,Population=     1000},
                new Planet { Name="Hoth", Terrain= new List<string>{ "tundra","ice caves","mountain ranges"},RotationPeriod=23,SurfaceWater=100},
                new Planet { Name="Dagobah",Terrain= new List<string>{ "swamp","jungles"},RotationPeriod=23,SurfaceWater=8},
                new Planet { Name="Bespin",Terrain= new List<string>{ "gas giant"},RotationPeriod=12, Diameter=118000,Population=  6000000},
                new Planet { Name="Endor",Terrain= new List<string>{ "forests","mountains","lakes"},RotationPeriod=18,SurfaceWater=8, Diameter=4900, Population= 30000000},
                new Planet { Name="Naboo",Terrain= new List<string>{ "grassy hills","swamps","forests","mountains"},RotationPeriod=26,SurfaceWater=12, Diameter=12120, Population=  4500000000},
                new Planet { Name="Coruscant",Terrain= new List<string>{ "cityscape","mountains"},RotationPeriod=24,Diameter=12240,Population=1000000000000},
                new Planet { Name="Kamino",Terrain= new List<string>{ "ocean"},RotationPeriod=27,SurfaceWater=100,Diameter=19720, Population=1000000000},
                new Planet { Name="Geonosis",Terrain= new List<string>{ "rock","desert","mountain","barren"},RotationPeriod=30,SurfaceWater=5,Diameter=11370, Population=100000000000},
                new Planet { Name="Utapau",Terrain= new List<string>{ "scrublands","savanna","canyons","sinkholes"},RotationPeriod=27,SurfaceWater=0.9f,Diameter=12900,Population=  95000000},
                new Planet { Name="Mustafar",Terrain= new List<string>{ "volcanoes","lava rivers","mountains","caves"},RotationPeriod=36,  Diameter=4200, Population=20000},
                new Planet { Name="Kashyyyk",Terrain= new List<string>{ "jungle","forests","lakes","rivers"},RotationPeriod=26 ,SurfaceWater=60,Diameter=12765, Population=45000000},
                new Planet { Name="Polis Massa",Terrain= new List<string>{ "airless","asteroid"},RotationPeriod=24, Diameter=0, Population=1000000},
                new Planet { Name="Mygeeto",Terrain= new List<string>{ "glaciers","mountains","ice canyons"},RotationPeriod=12, Diameter=10088, Population=  19000000},
                new Planet { Name="Felucia",Terrain= new List<string>{ "fungus","forests"},RotationPeriod=34, Diameter=9100,Population=8500000},
                new Planet { Name="Cato Neimoidia",Terrain= new List<string>{ "mountains","fields","forests","rock arches"},RotationPeriod=25, Population=10000000},
                new Planet { Name="Saleucami",Terrain= new List<string>{ "caves", "deserts","mountains","volcanoes"},RotationPeriod=26, Population=1400000000, Diameter=14920},
                new Planet { Name="Stewjon",Terrain= new List<string>{ "grass"}},
                new Planet { Name="Eriadu",Terrain= new List<string>{ "cityscape"},RotationPeriod=24, Diameter=13490  , Population= 22000000000},
             };
          return planets;
        }
    }

    public class PlanetComparer : IEqualityComparer<Planet>
    {
        public bool Equals(Planet x, Planet y)
        {
            if (x.RotationPeriod > 0)
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(Planet obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}
