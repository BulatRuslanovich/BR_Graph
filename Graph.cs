namespace BR_Graph {
    public class Graph {
		private List<Vertex> Vertexes = new List<Vertex>();
		private List<Edge> Edges = new List<Edge>();
		public int VertexCount => Vertexes.Count;
        public int EdgeCount => Edges.Count;

		public void AddVertex(Vertex vertex) {
			Vertexes.Add(vertex);
		}
		public void AddEdge(Vertex from, Vertex to) {
			var edge = new Edge(from, to);
			Edges.Add(edge);
		}



		public int[,] GetMatrix() {
			var matrix = new int[VertexCount, VertexCount];

			foreach (var edge in Edges) {
				var row = edge.From.Number - 1;
				var col = edge.To.Number - 1;

				matrix[row, col] = edge.Weight;
			}

			return matrix;
		}

		public List<Vertex> GetVertexLists(Vertex vertex) {
			var result = new List<Vertex>();

			foreach (var edge in Edges)
			{
				if (edge.From == vertex) {
					result.Add(edge.To);
				}
			}

			return result;
		}

		public bool Wave(Vertex start, Vertex finish) {
			var list = new List<Vertex>
			{
				start
			};

			for (int i = 0; i < list.Count; i++)
			{
				var vertex = list[i];

				foreach (var v in GetVertexLists(vertex))
				{
					if (!list.Contains(v)) {
						list.Add(v);
					}
				}
			}

			return list.Contains(finish);
		}
    }
}