using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dijxtra
{
    public class Cell
    {
        public int i { get; set; }/*מקור*/
        public int j { get; set; }/*יעד*/
        public double distance { get; set; }
        public int Parent { get; set; }/*צריך לבדוק איך האבא הגיע ליעד, משנים את המקור*/
    }
    // A ure to represent a node in adjacency list 
    public class AdjListNode
    {
        public int dest;
        public double weight;
        public AdjListNode next;

        public AdjListNode()
        {
        }
        // A utility function to create a new adjacency list node 
        public AdjListNode(int dest, double weight)
        {
            this.dest = dest;
            this.weight = weight;
            this.next = null;
        }
    }

    // A ure to represent an adjacency list 
    public class AdjList
    {
        // pointer to head node of list 
        public AdjListNode head { get; set; }
        public AdjList() { }
        public int SetHead() { head = null; return 1; }
    }

    // A ure to represent a graph. A graph is an array of adjacency lists. 
    // Size of array will be V (number of vertices in graph) 
    public class Graph
    {
        public int v;
        public AdjList[] array;
        public Graph() { }
        // A utility function that creates a graph of V vertices 
        public Graph(int v)
        {
            this.v = v;
            // Create an array of adjacency lists.  Size of array will be V 
            this.array = new AdjList[v];
            // Initialize each adjacency list as empty by making head as NULL 
            for (int i = 0; i < v; ++i)
                this.array[i] = new AdjList() { head = null };
        }

        public void addEdge(int src, int dest, double weight)
        {
            // Add an edge from src to dest.  A new node is added to the adjacency 
            // list of src.  The node is added at the beginning 
            AdjListNode newNode = new AdjListNode(dest, weight);
            newNode.next = this.array[src].head;
            this.array[src].head = newNode;

            // Since graph is undirected, add an edge from dest to src also 
            newNode = new AdjListNode(src, weight);
            newNode.next = this.array[dest].head;
            this.array[dest].head = newNode;
        }
    }

    // ure to represent a min heap node 
    public class MinHeapNode
    {
        public int v;
        public double dist;

        public MinHeapNode(int v, double dist)
        {
            this.v = v;
            this.dist = dist;
        }
    }

    // ure to represent a min heap 
    public class MinHeap
    {
        public int size;      // Number of heap nodes present currently 
        public int capacity;  // Capacity of min heap 
        public int[] pos;     // This is needed for decreaseKey() 
        public MinHeapNode[] array;

        public MinHeap(int capacity)
        {
            this.pos = new int[capacity];
            this.size = 0;
            this.capacity = capacity;
            this.array = new MinHeapNode[capacity];
        }
        public void swapMinHeapNodeProblem(MinHeapNode a, MinHeapNode b, out MinHeapNode aa, out MinHeapNode bb)
        {
            aa = b;
            bb = a;
        }

        public void minHeapify(int idx)
        {
            int smallest, left, right;
            smallest = idx;
            left = 2 * idx + 1;
            right = 2 * idx + 2;

            if (left < this.size &&
               this.array[left].dist < this.array[smallest].dist)
                smallest = left;

            if (right < this.size &&
                this.array[right].dist < this.array[smallest].dist)
                smallest = right;

            if (smallest != idx)
            {
                // The nodes to be swapped in min heap 
                MinHeapNode smallestNode = this.array[smallest];
                MinHeapNode idxNode = this.array[idx];

                // Swap positions 
                this.pos[smallestNode.v] = idx;
                this.pos[idxNode.v] = smallest;

                // Swap nodes 
                MinHeapNode temp = this.array[smallest];
                this.array[smallest] = this.array[idx];
                this.array[idx] = temp;
                minHeapify(smallest);
            }
        }

        // A utility function to check if the given minHeap is ampty or not 
        public bool isEmpty()
        {
            return this.size == 0;
        }

        // Standard function to extract minimum node from heap 
        public MinHeapNode extractMin()
        {
            if (this.isEmpty())
                return null;

            // Store the root node 
            MinHeapNode root = this.array[0];

            // Replace root node with last node 
            MinHeapNode lastNode = this.array[this.size - 1];
            this.array[0] = lastNode;

            // Update position of last node 
            this.pos[root.v] = this.size - 1;
            this.pos[lastNode.v] = 0;

            // Reduce heap size and heapify root 
            --this.size;
            minHeapify(0);

            return root;
        }

        // Function to decreasy dist value of a given vertex v. This function 
        // uses pos[] of min heap to get the current index of node in min heap 
        public void decreaseKey(int v, double dist)
        {
            // Get the index of v in  heap array 
            int i = this.pos[v];

            // Get the node and update its dist value 
            this.array[i].dist = dist;

            // Travel up while the complete tree is not hepified. 
            // This is a O(Logn) loop 
            while (i != 0 && this.array[i].dist < this.array[(i - 1) / 2].dist)
            {
                // Swap this node with its parent 
                this.pos[this.array[i].v] = (i - 1) / 2;
                this.pos[this.array[(i - 1) / 2].v] = i;
                //swap( this.array[i], this.array[(i - 1) / 2]);
                MinHeapNode temp;
                //swapMinHeapNode(this.array[i], this.array[(i - 1) / 2], out   aa, out  bb);
                temp = this.array[i];
                this.array[i] = this.array[(i - 1) / 2];
                this.array[(i - 1) / 2] = temp;
                // move to parent index 
                i = (i - 1) / 2;
            }
        }

        // A utility function to check if a given vertex 
        // 'v' is in min heap or not 
        public bool isInMinHeap(int v)
        {
            if (this.pos[v] < this.size)
                return true;
            return false;
        }

    }



}

