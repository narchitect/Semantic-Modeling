using VDS.RDF;
using VDS.RDF.Parsing;

namespace Exercise02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();

            //load RDF file
            NTriplesParser nTriplesParser = new NTriplesParser();
            nTriplesParser.Load(graph, "TUMgraph.nt");

            Console.ReadKey();
        }
    }
}
