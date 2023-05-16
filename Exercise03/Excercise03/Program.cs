using VDS.RDF;
using VDS.RDF.Parsing;
using VDS.RDF.Writing;
namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            TurtleParser ttlparser = new TurtleParser(); ttlparser.Load(graph, "AC20-FZK-Haus_LBD.ttl");
            

            //Find all windows
            IUriNode element = graph.GetUriNode(new Uri("https://w3id.org/bot#Element"));
            IUriNode hasSubElement = graph.GetUriNode(new Uri("https://w3id.org/bot#hasSubElement"));
            IUriNode type = graph.GetUriNode(new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#type"));
            IEnumerable<Triple> subElements = graph.GetTriplesWithPredicateObject(type, element);
            List<INode> windows = new List<INode>();

            foreach (Triple t in subElements)
            {
                if (t.Subject.ToString().Contains("window"))
                {
                    windows.Add(t.Subject);
                }
            }

            INode smartBlind = graph.CreateUriNode(UriFactory.Create("https://example.org/smartBlind"));
            INode hasSmartBlind = graph.CreateUriNode(UriFactory.Create("https://example.org/hasSmartBlind"));
            int count = 1;
            foreach(INode window in windows)
            {
                INode smartBilndInstance = graph.CreateUriNode(UriFactory.Create("https://example.org/smartBlind_" + count.ToString()));
                graph.Assert(new Triple(window, hasSmartBlind, smartBilndInstance));
                graph.Assert(new Triple(smartBilndInstance, type, smartBlind));
                count++;
            }

            CompressingTurtleWriter ttlwriter = new CompressingTurtleWriter();
            ttlwriter.Save(graph, "AC20-FZK-Haus_LBD_test.ttl");


            Console.ReadKey();
        }
    }
}
