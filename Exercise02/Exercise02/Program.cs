using VDS.RDF;
using VDS.RDF.Parsing;
using VDS.RDF.Writing;

namespace Exercise02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();

            //create nodes
            IUriNode everest = graph.CreateUriNode(UriFactory.Create("https://example.org/MountEverest"));
            IUriNode hasElevation = graph.CreateUriNode(UriFactory.Create("https://example.org/hasElevation"));
        
            IUriNode firstAscentBy= graph.CreateUriNode(UriFactory.Create("https://example.org/firstAscentBy"));
            IUriNode hillary = graph.CreateUriNode(UriFactory.Create("https://example.org/edmundHillary"));
            IUriNode bornln = graph.CreateUriNode(UriFactory.Create("https://example.org/bornln"));
            IUriNode newZealand = graph.CreateUriNode(UriFactory.Create("https://example.org/newZealand"));
            IUriNode tenzingNorgay = graph.CreateUriNode(UriFactory.Create("https://example.org/tenzingNorgay"));
            IUriNode tibet = graph.CreateUriNode(UriFactory.Create("https://example.org/tibet"));
            IUriNode isLocatedIn = graph.CreateUriNode(UriFactory.Create("https://example.org/isLocatedIn"));
            IUriNode china = graph.CreateUriNode(UriFactory.Create("https://example.org/china"));
            IUriNode nepal = graph.CreateUriNode(UriFactory.Create("https://example.org/nepal"));
            ILiteralNode elevation = (8848).ToLiteral(graph);
            ILiteralNode date = ("29.05.1953").ToLiteral(graph);



            graph.Assert(new Triple(everest, hasElevation, elevation));
            graph.Assert(new Triple(everest, firstAscentBy, hillary));
            graph.Assert(new Triple(everest, firstAscentBy, tenzingNorgay));
            graph.Assert(new Triple(everest, isLocatedIn, china));
            graph.Assert(new Triple(everest, isLocatedIn, nepal));
            graph.Assert(new Triple(everest, firstAscentBy, date));
            graph.Assert(new Triple(tenzingNorgay, bornln, tibet));
            graph.Assert(new Triple(hillary, bornln, newZealand));

            NTriplesWriter ntwriter = new NTriplesWriter();
            ntwriter.Save(graph, "everest.nt");

            //load RDF file
            NTriplesParser nTriplesParser = new NTriplesParser();
            nTriplesParser.Load(graph, "everest.nt");

            foreach (Triple t in graph.Triples)
            {
                Console.WriteLine(t.ToString());
            }

            Console.ReadKey();
        }
    }
}
