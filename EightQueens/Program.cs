using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EightQueens
{
    class Program
    {
        static void Main(string[] args)
        {
            myThread t = new myThread(8, 8);
            ArrayList rezult = t.func();
            Console.WriteLine(rezult.Count);

            Console.ReadKey();
        }

        class myThread
        {
            int globalI;
            int globalJ;
            int[,] chessBoard;// = new int[8, 8];
            Dictionary<int, int> queue = new Dictionary<int, int>();
            ArrayList rezult1 = new ArrayList();

            public myThread(int globalI, int globalJ)
            {
                this.chessBoard = new int[globalI, globalJ];
                this.globalI = globalI;
                this.globalJ = globalJ;
            }

            public ArrayList func()
            {
                for (int i = 0; i < globalI; i++)
                    for (int j = 0; j < globalJ; j++)
                    {
                        queue.Clear();
                        queue.Add(i, j);
                        fillChessBoard(i, j, 1);
                        queueFuction();
                    }
                return rezult1;
            }

            bool checkQueue()
            {
                int count = 0;
                if ((queue.Count() > 0) && (rezult1.Count > 0))
                {
                    foreach (var dictionatyRezult in rezult1)
                    {
                        Dictionary<int, int> copy = (Dictionary<int, int>)dictionatyRezult;
                        foreach (var queueElement in queue)
                            foreach (var copyElement in copy)
                                if ((queueElement.Value == copyElement.Value) && (queueElement.Key == copyElement.Key))
                                    count += 1;

                        if (count == queue.Count())
                            return false;
                        count = 0;
                    }
                }
                return true;
            }

            void queueFuction()
            {
                for (int i = 0; i < globalI; i++)
                    for (int j = 0; j < globalJ; j++)
                    {
                        if (chessBoard[i, j] == 0)
                        {
                            queue.Add(i, j);
                            fillChessBoard(i, j, 1);

                            if (checkQueue() && (queue.Count <= 8))
                            {
                                queueFuction();
                                if (queue.Count == 8)
                                {
                                    var copy = new Dictionary<int, int>(queue);
                                    rezult1.Add(copy);
                                }
                            }
                            fillChessBoard(queue.Keys.Last(), queue.Values.Last(), 0);
                            queue.Remove(queue.Keys.Last());
                            foreach (var element in queue)
                                fillChessBoard(element.Key, element.Value, 1);
                        }
                    }
            }

            void fillChessBoard(int row, int column, int element)
            {
                for (int i = 0; i < globalI; i++)
                {
                    chessBoard[row, i] = element;
                    chessBoard[i, column] = element;
                }

                fillDiagonal(row, column, element, -1, -1, row, column);
                fillDiagonal(row, globalI - 1 - column, element, -1, 1, row, column);
                fillDiagonal(globalI - 1 - row, column, element, 1, -1, row, column);
                fillDiagonal(globalI - 1 - row, globalI - 1 - column, element, 1, 1, row, column);

                //for (int i = 0; i < 8; i++)
                //{
                //    Console.WriteLine();
                //    for (int j = 0; j < 8; j++)
                //        Console.Write(chessBoard[i, j]);
                //}
                //Console.WriteLine();

                //    using (System.IO.StreamWriter file =
                //new System.IO.StreamWriter(@"E:\уроки\5-Semester\ParallelProgramming\WriteLines2.txt", true))
                //    {
                //        for (int i = 0; i < 8; i++)
                //        {
                //            file.WriteLine();
                //            for (int j = 0; j < 8; j++)
                //                file.Write(chessBoard[i, j]);
                //        }
                //        file.WriteLine();
                //        if (queue.Count != 0)
                //            foreach (var i in queue)
                //                file.Write(i.Value + " " + i.Key + "; ");
                //        file.WriteLine(" ");
                //    }

            }

            void fillDiagonal(int rowNumber, int columnNumver, int element, int signRow, int signColumn, int row, int column)
            {
                int rib;
                if (rowNumber >= columnNumver)
                    rib = columnNumver;
                else
                    rib = rowNumber;

                if (rib != 0)
                    for (int i = 0; i <= rib; i++)
                        chessBoard[row + i * signRow, column + i * signColumn] = element;
            }

        }
    }
}
