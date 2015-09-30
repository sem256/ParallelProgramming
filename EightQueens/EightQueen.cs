using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EightQueens
{
    class EightQueen
    {
        public int Number { get; set; }
        public EightQueen(int size)
        {
            this.Number = size;
        }
        public int GetSolution()
        {
            int line = 0, pos = -1, count = 0;
            int[] positions = new int[Number];

            for (int m = 0; m < positions.Length; m++)
                positions[m] = -1;
            while (true)
            {
                for (pos = positions[line] + 1; pos < Number; pos++)
                {
                    int i = 0;
                    for (i = 0; i < line; i++)
                    {
                        int dis = line - i;
                        if (positions[i] == pos || positions[i] == pos + dis || positions[i] == pos - dis)
                            break;
                    }
                    if (i == line)
                    {
                        positions[line] = pos;
                        line++;
                        if (line == Number)
                        {
                            count++;
                            line--;
                        }
                        else
                            break;
                    }
                }
                if (pos == Number)
                {
                    if (line == 0)
                        break;
                    else
                    {
                        positions[line] = -1;
                        line--;
                    }
                }
            }
            return count;
        }
    }
}
