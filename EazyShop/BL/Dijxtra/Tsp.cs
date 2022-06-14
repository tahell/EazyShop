using DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dijxtra
{
    class Tsp /*TSP_Annealing_Program*/
    {
        
      //      static void Main(string[] args)
      //      {
      //          Console.WriteLine("\nBegin TSP simulated annealing C# ");
      //      List<Nodes> nodes = new List<Nodes>();
      //          int numNodes = nodes.Count();
      //          Console.WriteLine("\nSetting num_cities = " + numNodes);
      //          Console.WriteLine("\nOptimal solution is 0, 1, 2, . . " +
      //            (numNodes - 1));
      //          Console.WriteLine("Optimal soln has total distance = " +
      //            (numNodes - 1));
      //          Random rnd = new Random(2);
      //          int maxIter = 25000;
      //          double startTemperature = 10000.0;
      //          double alpha = 0.98;

      //          Console.WriteLine("\nSettings: ");
      //          Console.WriteLine("max_iter = " + maxIter);
      //          Console.WriteLine("start_temperature = " +
      //            startTemperature.ToString("F1"));
      //          Console.WriteLine("alpha = " + alpha);

      //          Console.WriteLine("\nStarting solve() ");
      //          int[] soln = Solve(numNodes, rnd, maxIter,
      //            startTemperature, alpha);
      //          Console.WriteLine("Finished solve() ");

      //          Console.WriteLine("\nBest solution found: ");
      //          ShowArray(soln);
      //          double dist = TotalDist(soln);
      //          Console.WriteLine("\nTotal distance = " +
      //            dist.ToString("F1"));

      //          Console.WriteLine("\nEnd demo ");
      //          Console.ReadLine();
      //      }  // Main()

      //      static double TotalDist(int[] route)
      //      {
      //          double d = 0.0;  // total distance between cities
      //          int n = route.Length;
      //          for (int i = 0; i "lt" n - 1; ++i)
      //{
      //              if (route[i] "lt" route[i + 1])
      //    d += (route[i + 1] - route[i]) * 1.0;
      //  else
      //    d += (route[i] - route[i + 1]) * 1.5;
      //          }
      //          return d;
      //      }

      //      static double Error(int[] route)
      //      {
      //          int n = route.Length;
      //          double d = TotalDist(route);
      //          double minDist = n - 1;
      //          return d - minDist;
      //      }

      //      static int[] Adjacent(int[] route, Random rnd)
      //      {
      //          int n = route.Length;
      //          int[] result = (int[])route.Clone();  // shallow is OK
      //          int i = rnd.Next(0, n); int j = rnd.Next(0, n);
      //          int tmp = result[i];
      //          result[i] = result[j]; result[j] = tmp;
      //          return result;
      //      }

      //      static void Shuffle(int[] route, Random rnd)
      //      {
      //          // Fisher-Yates algorithm
      //          int n = route.Length;
      //          for (int i = 0; i "lt" n; ++i)
      //{
      //              int rIndx = rnd.Next(i, n);
      //              int tmp = route[rIndx];
      //              route[rIndx] = route[i];
      //              route[i] = tmp;
      //          }
      //      }

      //      static void ShowArray(int[] arr)
      //      {
      //          int n = arr.Length;
      //          Console.Write("[ ");
      //          for (int i = 0; i "lt" n; ++i)
      //  Console.Write(arr[i].ToString().PadLeft(2) + " ");
      //          Console.WriteLine(" ]");
      //      }

      //      static int[] Solve(int nCities, Random rnd, int maxIter,
      //        double startTemperature, double alpha)
      //      {
      //          double currTemperature = startTemperature;
      //          int[] soln = new int[nCities];
      //          for (int i = 0; i "lt" nCities; ++i) { soln[i] = i; }
      //          Shuffle(soln, rnd);
      //          Console.WriteLine("Initial guess: ");
      //          ShowArray(soln);

      //          double err = Error(soln);
      //          int iteration = 0;
      //          while (iteration "lt" maxIter && err "gt" 0.0)
      //{
      //              int[] adjRoute = Adjacent(soln, rnd);
      //              double adjErr = Error(adjRoute);
      //              if (adjErr "lt" err)  // better route 
      //  {
      //                  soln = adjRoute; err = adjErr;
      //              }
      //  else
      //  {
      //                  double acceptProb =
      //                    Math.Exp((err - adjErr) / currTemperature);
      //                  double p = rnd.NextDouble(); // corrected
      //                  if (p "lt" acceptProb)  // accept anyway
      //    {
      //                      soln = adjRoute; err = adjErr;
      //                  }
      //              }

      //              if (currTemperature "lt" 0.00001)
      //    currTemperature = 0.00001;
      //  else
      //    currTemperature *= alpha;
      //              ++iteration;
      //          }  // while

      //          return soln;
      //      }  // Solve()

        }  // Program class
    }  // ns


//   ManagerTsp ma = new ManagerTsp()


//RoutingIndexManager(data.DistanceMatrix.GetLength(0), data.VehicleNumber, data.Depot);
//   RoutingModel routing = new RoutingModel(manager);

//        private static int ManagerandomTsp(Cell[,] matrixToTsp, int lenMatrix, int
//                            startIndex, int dest, int[] randomyWay, int[] BestRandomWay)
//        {
//            int ans = int.MaxValue, temp;
//            stopwatch.Restart();
//            while (stopwatch.Elapsed.Seconds < 10)
//            {
//                temp = RandomTsp(matrixToTsp, lenMatrix, startIndex, dest, randomyWay);
//                if (temp < ans)
//                {
//                    ans = temp;
//                    for (int i = 0; i < randomyWay.Length; i++)
//                    {
//                        BestRandomWay[i] = randomyWay[i];
//                    }
//                }
//            }
//            return ans;

//        }

//        private static int RandomTsp(Cell[,] matrixToTsp, int lenMatrix, int startIndex, int
//                                                                   dest, int[] randomyWay)
//        {
//            for (int i = 0; i < dest + 1; i++)
//            {
//                randomyWay[i] = -1;
//            }
//            int ans = 0;
//            Random rnd = new Random();
//            int matrixIndex = 1;
//            randomyWay[0] = startIndex;
//            int randomIndex = startIndex, prev;
//            for (int i = 1; i < dest; i++)
//            {
//                prev = randomIndex;
//                while (randomyWay[randomIndex] != -1)
//                    randomIndex = rnd.Next(1, dest);
//                randomyWay[randomIndex] = matrixIndex++;
//                ans += Convert.ToInt32(matrixToTsp[prev, randomIndex].distance);
//            }

//            // לבחור נקודת סיום אופטימלית
//            int iMin = BestCash(dest, lenMatrix, randomIndex, matrixToTsp);
//            randomyWay[dest] = iMin;
//            ans += Convert.ToInt32(matrixToTsp[randomIndex, iMin].distance);
//            return ans;
//        }

//        private static int ApproximatelyTsp(Cell[,] matrixToTsp, bool[] visited, int currPos,
//                  int lenMatrix, int count, int cost, int ans, int[] arr, int
//                                      startIndex, int[] approximatelyWay,int dest)
//        {
//            ans = OurTsp(matrixToTsp, visited, currPos, lenMatrix, count, cost, ans, arr, approximatelyWay, true, lenMatrix - 1);
//            return ans;
//        }


//        public static int Greedytsp(Cell[,] matrixToTsp, int lenMatrix, int startIndex, int[]
//                                                               resultIndex, int dest)
//        {
//            int lenResult = dest + 1;
//            int[] Moved = new int[lenResult];
//            Moved[startIndex] = 1;
//            int Path = 0;
//            int currentIndex = startIndex;
//            int min = 0;
//            int minIndex = -1;
//            resultIndex[0] = startIndex;
//            for (int j = 0; j < dest - 1; j++)
//            {
//                min = int.MaxValue;
//                for (int i = 0; i < dest; i++)
//                {
//                    if (Moved[i] != 1 && matrixToTsp[currentIndex, i].distance != 0)
//                        if (min > matrixToTsp[currentIndex, i].distance)
//                        {
//                            min = Convert.ToInt32(matrixToTsp[currentIndex, i].distance);
//                            minIndex = i;
//                        }
//                }
//                resultIndex[j + 1] = minIndex;
//                currentIndex = minIndex;
//                Moved[currentIndex] = 1;
//                Path += min;
//            }
//            //TODO: לבחור נקודת סיום אופטימלית
//            int iMin = BestCash(dest, lenMatrix, currentIndex, matrixToTsp);
//            resultIndex[dest] = iMin;
//            Path += Convert.ToInt32(matrixToTsp[currentIndex, iMin].distance);
//            return Path;
//        }

//        public static int BestCash(int dest, int lenMatrix, int beforeIndex, Cell[,] matrixToTsp)
//        {
//            int sumMin = int.MaxValue, iMin = 0;
//            for (int k = dest; k < lenMatrix; k++)
//            {
//                if (matrixToTsp[beforeIndex, dest].distance < sumMin)
//                { iMin = k; sumMin = Convert.ToInt32(matrixToTsp[beforeIndex, dest].distance);
//                }
//            }
//            return iMin;
//        }


//        //private static int ApproximatelyTsp(Cell[,] matrixToTsp, bool[] visited, int currPos,
//        //          int lenMatrix, int count, int cost, int ans, int[] arr, int
//        //                              startIndex, int[] approximatelyWay)
//        //{
//        //    ans = OurTsp(matrixToTsp, visited, currPos, lenMatrix, count, cost, ans, arr, approximatelyWay, true, lenMatrix - 1);
//        //    return ans;
//        //}
//        public static Stopwatch stopwatch = new Stopwatch();
//        public static int OurTsp(Cell[,] MatrixToTsp, bool[] visited, int currPos,
//                                        int lenMat, int count, int cost, int ans, int[] ResultIndexes, int[] arr, bool approx, int dest)
//        {
//            if (approx)
//            {
//                //if (currPos == 0)
//                //    stopwatch.Restart();
//                //else
//                if (stopwatch.Elapsed.Seconds >= 10)
//                    return ans;
//            }
//            //אם זה החוליה האחרונה וגם יש גישה לחולית היעד, החוליה הנתונה
//            if (count == dest && MatrixToTsp[currPos, dest].distance > 0)
//            {
//                //בוחר את היעד הכי קרוב [הקופה שהכי קרובה למיקום שנמצא בו
//                int iMin = BestCash(dest, lenMat, currPos, MatrixToTsp);
//                cost += Convert.ToInt32(MatrixToTsp[currPos, iMin].distance);
//                if (cost < ans)
//                {
//                    ans = cost;
//                    arr[dest] = iMin;
//                    //תעתיק את המערך למערך התוצאה
//                    for (int i = 0; i < dest + 1; i++)
//                    {
//                        ResultIndexes[i] = arr[i];
//                    }
//                }
//                return ans;
//            }


//            //תעבור על הטיולים של הרשימה הסמוכה לנקודה הנוכחית ותגדיל את המונה באחד ותתמחר עי גרף הסמיכויות
//            for (int i = 0; i <= dest; i++)
//            {
//                //אם זה לא החוליה הנוכחית וגם עוד לא עברו שם אז תעבור שם
//                if (i != dest && visited[i] == false && MatrixToTsp[currPos, i].distance > 0)
//                {
//                    visited[i] = true;
//                    arr[count] = i;
//                    ans = OurTsp(MatrixToTsp, visited, i, lenMat, count + 1,
//                        cost + Convert.ToInt32(MatrixToTsp[currPos, i].distance), ans, ResultIndexes, arr, approx, dest);
//                    // Mark ith node as unvisited
//                    visited[i] = false;
//                }
//            }
//            return ans;
//        }





//        //הפונקציה תפעיל סוכן נוסע מתאים
//public static int[] ManageTsp(Cell[,] matrixToTsp, int dest, int lenMat)
//{
//    int lenResult = dest + 1;
//    bool[] visited = new bool[lenResult];
//    the result array should be of type 'answer'.
//    int[] result = new int[dest + 1];
//    int[] arr = new int[lenResult];
//    for (int i = 0; i < lenResult; i++)
//    {
//        result[i] = 0;
//        arr[i] = 0;
//    }
//    Mark 0th node as visited
//    visited[0] = true;
//    int ans = int.MaxValue;
//    int curPos = 0, count = 1, cost = 0, startIndex = 0; bool aprox = false;
////    עבור מספר קטן
//    if (dest <= 10)
//    {
//        ans = OurTsp(matrixToTsp, visited, curPos, lenMat, count, cost, ans, result, arr, aprox, dest);
//        return result;
//    }
//    else
//    {


//        int[] greedyWay = new int[lenResult], approximatelyWay = new int[lenResult], randomWay = new int[lenResult], BestRandomWay = new int[lenResult];
//        ApproximatelyTsp(matrixToTsp, visited, curPos, lenMat, count, cost, ans, arr, startIndex, approximatelyWay, dest);
////        מקביליות
//        Task<int> greedyTask = Task<int>.Factory.StartNew(() => Greedytsp(matrixToTsp, lenMat, startIndex, greedyWay, dest));
//        Task<int> approximateTask = Task<int>.Factory.StartNew(() => ApproximatelyTsp(matrixToTsp, visited, curPos, lenMat, count, cost, ans, arr, startIndex, approximatelyWay, dest));
//        Task<int> randomtask = Task<int>.Factory.StartNew(() => ManagerandomTsp(matrixToTsp, lenMat, startIndex, dest, randomWay, BestRandomWay));
////        החזרת האופטימלי ביותר
//        if (randomtask.Result < approximateTask.Result && randomtask.Result < greedyTask.Result)
//            return BestRandomWay;
//        if (greedyTask.Result <= approximateTask.Result)
//            return greedyWay;
//        return approximatelyWay;
//    }





    //       }

