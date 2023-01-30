// See https://aka.ms/new-console-template for more information

using Graph;

var g = new DirectedGraph(4);

g.AddEdge(0, 1);
g.AddEdge(0, 2);
g.AddEdge(0, 3);
g.AddEdge(2, 3);


g.Print();

var _ = g.FindShortestPath(0, 3);


return 0;