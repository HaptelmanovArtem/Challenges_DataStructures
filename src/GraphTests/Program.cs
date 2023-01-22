// See https://aka.ms/new-console-template for more information

using Graph;

var g = new DirectedGraph(4);

g.AddEdge(0, 1);
g.AddEdge(1, 2);
g.AddEdge(3, 0);
g.AddEdge(3, 1);

g.Print();

var _ = g.GetMotherVertex();


return 0;