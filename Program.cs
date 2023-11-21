using System.Runtime.Intrinsics;

namespace BR_Graph;
class Program {
    static void Main(string[] args) {
        Console.WriteLine("Hello, Graph!");
        var Graph = new Graph();

        var v = new Vertex(1);
        var v2 = new Vertex(2);
        var v3 = new Vertex(3);
        var v4 = new Vertex(4);
        var v5 = new Vertex(5);
        var v6 = new Vertex(6);
        var v7 = new Vertex(6);

        Graph.AddVertex(v);
        Graph.AddVertex(v6);
        Graph.AddVertex(v2);
        Graph.AddVertex(v3);
        Graph.AddVertex(v4);
        Graph.AddVertex(v5);
        Graph.AddVertex(v7);

        Graph.AddEdge(v, v2);
        Graph.AddEdge(v, v3);
        Graph.AddEdge(v3, v4);
        Graph.AddEdge(v3, v5);
        Graph.AddEdge(v5, v6);
        Graph.AddEdge(v6, v);
        Graph.AddEdge(v6, v2);

        DrawGraphMatrix(Graph);
        DrawVertex(Graph, v);
        DrawVertex(Graph, v2);
        DrawVertex(Graph, v3);
        DrawVertex(Graph, v4);
        DrawVertex(Graph, v5);
        DrawVertex(Graph, v6);

        System.Console.WriteLine(Graph.Wave(v, v3));
        System.Console.WriteLine(Graph.Wave(v4, v6));
    }

    private static void DrawVertex(Graph graph, Vertex vertex) {
        System.Console.Write(vertex.Number + ": ");

        foreach (var ver in graph.GetVertexLists(vertex)) {
            System.Console.Write(ver.Number + ", ");
        }

        System.Console.WriteLine();
    }

    private static void DrawGraphMatrix(Graph graph) {
        var matrix = graph.GetMatrix();

        for (int i = 0; i < graph.VertexCount; i++) {
            System.Console.Write($"{i + 1} | ");
            for (int j = 0; j < graph.VertexCount; j++) {
                System.Console.Write(matrix[i, j] + " | ");
            }
            System.Console.WriteLine();
        }

        for (int i = 2; i < graph.VertexCount * 4 + 5; i++) {
            if (i % 4 == 0) {
                System.Console.Write('+');
            } else {
                System.Console.Write('-');
            }
        }

        System.Console.Write("\n  | ");
        for (int j = 0; j < graph.VertexCount; j++) {
            System.Console.Write(j + 1 + " | ");
        }

        System.Console.WriteLine();
    }
}
