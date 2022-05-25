using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dijxtra
{




    public class DijkstraFunction
    {

        //public static void printArr(Cell[] dist, int n)
        //{
        //    Console.WriteLine("\n\n Vertex \t\t  Distance from Source \t\t parent \n");
        //    for (int i = 0; i < n; ++i)
        //        Console.WriteLine("\n" + i + "  \t\t " + dist[i].distance + " \t\t" + dist[i].Parent);
        //}

        // The main function that calulates distances of shortest paths from src to all 
        // vertices. It is a O(ELogV) function 
        public static Cell[] Dijkstra(Graph graph, int src)
        {
            int vv = graph.v;// Get the number of vertices in graph 
            Cell[] dist = new Cell[vv];      // dist values used to pick minimum weight edge in cut 
            for (int i = 0; i < vv; i++)
            {
                dist[i] = new Cell();
                dist[i].i = src;
                dist[i].j = i;
                dist[i].Parent = 0;
                dist[i].distance = int.MaxValue;
            }
            // minHeap represents set E 
            MinHeap minHeap = new MinHeap(vv);

            // Initialize min heap with all vertices. dist value of all vertices  
            for (int v = 0; v < vv; ++v)
            {
                dist[v].distance = int.MaxValue;
                minHeap.array[v] = new MinHeapNode(v, dist[v].distance);
                minHeap.pos[v] = v;
            }
            // Make dist value of src vertex as 0 so that it is extracted first 
            minHeap.array[src] = new MinHeapNode(src, dist[src].distance);
            minHeap.pos[src] = src;
            dist[src].distance = 0;
            minHeap.decreaseKey(src, dist[src].distance);
            // Initially size of min heap is equal to V 
            minHeap.size = vv;

            // In the followin loop, min heap contains all nodes 
            // whose shortest distance is not yet finalized. 
            while (!minHeap.isEmpty())
            {
                // Extract the vertex with minimum distance value 
                MinHeapNode minHeapNode = minHeap.extractMin();
                int u = minHeapNode.v; // Store the extracted vertex number 

                // Traverse through all adjacent vertices of u (the extracted 
                // vertex) and update their distance values 
                AdjListNode pCrawl = graph.array[u].head;
                while (pCrawl != null)
                {
                    int v = pCrawl.dest;

                    // If shortest distance to v is not finalized yet, and distance to v 
                    // through u is less than its previously calculated distance 
                    if (minHeap.isInMinHeap(v) && dist[u].distance != int.MaxValue &&
                                                  pCrawl.weight + dist[u].distance < dist[v].distance)
                    {
                        dist[v].distance = dist[u].distance + pCrawl.weight;
                        dist[v].Parent = u;
                        // update distance value in min heap also 
                        minHeap.decreaseKey(v, dist[v].distance);
                    }
                    pCrawl = pCrawl.next;
                }
            }

            // print the calculated shortest distances 
            //printArr(dist, vv);
            return dist;
        }

        public static Cell[,] ComputeDikjstra(List<Nodes> nodes, List<Route> connections)
        {
            int numNodes = nodes.Count() ;
            List_iCode list_ICode = new List_iCode(nodes);

            Graph graph = computeGraph(nodes, connections, list_ICode);
            //מטריצת המרחקים שתוחזר 
            Cell[,] mat = new Cell[numNodes, numNodes];
            //משתנה עזר המקבל תוצאת דייקסטרה ומועתק למטריצה
            Cell[] arr = new Cell[numNodes];
            foreach (var item in nodes)
            {
                int i = list_ICode.getI(item.Node_Kod);
                arr = Dijkstra(graph,i);
                for (int j = 1; j < numNodes; j++)
                    mat[i, j] = arr[j];
            }
            return mat;
        }
        public static Graph computeGraph(List<Nodes> nodes, List<Route> connections, List_iCode list_ICode)
        {

            //המרת קשתות וקודקודים לרשימת סמיכויות
            int V = nodes.Count() + 1;
            Graph graph = new Graph(V);


            foreach (var item in connections)
            {
                int src = Convert.ToInt32(item.source);
                int dest = Convert.ToInt32(item.destination);
                int Isrc = list_ICode.getI(src);
                int Idest = list_ICode.getI(dest);
                double distance = item.value;
                graph.addEdge(Isrc, Idest, distance);

            }
            return graph;
        }


       public class I_Code
        {
            public int code { get; set; }
            public int i { get; set; }

        }
        public class List_iCode
        {
            public List<I_Code> list = new List<I_Code>();
            public List_iCode(List<Nodes> nodes)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    list.Add(new I_Code() { i = i, code = nodes[i].Node_Kod });
                }
            }

            public int getI(int code)
            {
                int i = list.Find(x => x.code == code).i;
                return i;
            }

            public int getCode(int i)
            {
                int code= list.Find(x => x.i == i).code;
                return code;
            }

        }
    }
}
