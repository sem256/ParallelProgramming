﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EightQueens
{
    class Program
    {
        static void Main(string[] args)
        {
            myThread t = new myThread();
            ArrayList rezult = t.func();
            //foreach(var i in array)
            //{
            //    foreach (var j in i)
            //        Console.WriteLine(j.Key + " " + j.Value);
            //}
            Console.ReadKey();
        }

        class myThread
        {
            int[,] chessBoard = new int[8, 8];
            Dictionary<int, int> queue = new Dictionary<int, int>();
            ArrayList rezult1 = new ArrayList();

            public ArrayList func()
            {
                //for (int i = 0; i <= 7; i++)
                //{
                int i = 2;
                //for (int j = 0; j <= 7; j++)
                //{
                int j = 4;
                queue.Clear();
                queue.Add(i, j);
                fillChessBoard(i, j, 1);
                queueFuction();
                //}
                //}
                return rezult1;
            }

            void queueFuction()
            {
                bool flag = false;
                if (queue.Count != 8)
                {
                    for (int i = 0; i <= 7; i++)
                        for (int j = 0; j <= 7; j++)
                        {
                            if (chessBoard[i, j] == 0)
                            {
                                flag = true;
                                queue.Add(i, j);
                                fillChessBoard(i, j, 1);
                                queueFuction();
                            }
                        }
                    if (flag == false)
                    {
                        if (queue.Keys.Last() == 8)
                        {
                            Console.WriteLine("first");
                        }
                        fillChessBoard(queue.Keys.Last(), queue.Values.Last(), 0);
                        queue.Remove(queue.Keys.Last());
                        foreach (var element in queue)
                        {
                            fillChessBoard(element.Key, element.Value, 1);
                        }
                        //Console.WriteLine();
                    }
                }
                else
                {
                    foreach (var element in queue)
                        Console.WriteLine(element.Key + "  " + element.Value);

                    rezult1.Add(queue);
                    Console.WriteLine("find");
                }
            }

            void fillChessBoard(int row, int column, int element)
            {
                for (int i = 0; i <= 7; i++)
                {
                    chessBoard[row, i] = element;
                    chessBoard[i, column] = element;
                }

                fillDiagonal(row, column, element, -1, -1, row, column);
                fillDiagonal(row, 7 - column, element, -1, 1, row, column);
                fillDiagonal(7 - row, column, element, 1, -1, row, column);
                fillDiagonal(7 - row, 7 - column, element, 1, 1, row, column);

                for (int i = 0; i < 8; i++)
                {
                    Console.WriteLine();
                    for (int j = 0; j < 8; j++)
                        Console.Write(chessBoard[i, j]);
                }
                Console.WriteLine();

                using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"E:\уроки\5-Semester\ParallelProgramming\WriteLines2.txt", true))
                {
                    for (int i = 0; i < 8; i++)
                    {
                        file.WriteLine();
                        for (int j = 0; j < 8; j++)
                            file.Write(chessBoard[i, j]);
                    }
                    file.WriteLine();
                    if (queue.Count != 0)
                        foreach (var i in queue)
                            file.Write(i.Value + " " + i.Key + "; ");
                    file.WriteLine(" ");
                }

            }

            void fillDiagonal(int rowNumber, int columnNumver, int element, int signRow, int signColumn, int row, int column)
            {
                int rib;
                if (rowNumber >= columnNumver)
                    rib = columnNumver;
                else
                    rib = rowNumber;

                if (rib != 0)
                {
                    for (int i = 0; i <= rib; i++)
                        chessBoard[row + i * signRow, column + i * signColumn] = element;
                }
            }

        }
    }
}