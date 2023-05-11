using GeometryGym.Ifc;
using System.Linq;
using System.Reflection;

namespace GettingStarted
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //open an exisiting IFC Model, Leave argument empty to create a new IFC model
            var db = new DatabaseIfc(@"C:\Users\Anwender\Documents\GitHub\Semantic-Modeling\Exercise01\IFC sample models-20230511\Duplex_A_20110907.ifc");
            //access all entitiy instances stored in the IFC model
            var allEntities = db.ToList();
            //access and show an instance
            Console.WriteLine(allEntities[0]);

            //long LINQ notation
            var allWalls =
                from elem in db.ToList()
                where elem.GetType() == typeof(IfcWall)
                select elem;

            //sort form using lamda noataion
            var allWalls_lambda = db.OfType<IfcWall>().ToList();

            //allWalls[0] -> impossible, because IEnumerable<T> doesn't have any order in that collection
            //So IEnumerable<T> should be accessed by iteration statements. like foreach, Linq FristOrDefault(), ElementAt()
            foreach (BaseClassIfc item in allWalls)
            {
                Console.WriteLine(item.ToString());
            }

            foreach (IfcWall wall in allWalls_lambda)
            {
                string wallName = wall.Name;
                Console.WriteLine(wallName);
            }

            var allProducts =
                from elem in db.ToList()
                where elem is IfcProduct
                select elem;

            Console.WriteLine(allProducts.Count()); //295
            Console.WriteLine(allWalls_lambda.Count()); //57

            //products list cotains objects of different derived types, while the ifcwall limited to ifcwall objects only.

            var allopening_lambda = db.OfType<IfcOpeningElement>().ToList();

            foreach (var opening in allopening_lambda)
            {
                var fillings = opening.HasFillings.Select(f => f.RelatedBuildingElement).ToList();

                foreach(var filling in fillings)
                {
                    Console.WriteLine(opening.Name.ToString());
                    Console.WriteLine(filling.Name.ToString());
                }
            }

           


           


        }
    }
}

