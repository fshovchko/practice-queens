using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queens
{
    class Program
    {
        static bool[,] HorizontandVertic(bool[,] Board, int [,] xy,int queen)
        {
            for (int i = 0;i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if(xy[0,queen]==j)
                    {
                        Board[i, j] = false;
                    }
                    if(xy[1,queen]==i)
                    {
                        Board[i, j] = false;
                    }
                }
            }
            return Board;
        }
        static bool[,] Diagonal(bool[,] Board, int[,] xy, int queen)
        {
            int xa = xy[0,queen];
            int ya = xy[1,queen];
            int xb = xa;
            int yb = ya;
            while (xa < 8 || ya > 0)
            {
                Board[ya, xa] = false;
                xa++;
                ya--;
            }
            while(xb > 0 || yb < 8)
            { 
                Board[yb, xb] = false;
                xb--;
                yb++;
            }
             xa = xy[0,queen];
             ya = xy[1,queen];
             xb = xa;
             yb = ya;
            while (xa < 8 || ya < 8)
            {
                Board[ya, xa] = false;
                xa++;
                ya++;
            }
            while(xb >1 || yb >1)
            {
                Board[yb, xb] = false;
                xb--;
                yb--;
            }
            return Board;
        }
        static int[,] Queen(bool[,] Board,int[,] xy, int queen)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Board[i, j] == true)
                    {
                        xy[0,queen] = j;
                        xy[1,queen] = i;
                        break;
                    }
                }
            }
            return xy;
        }
        static bool[,] Empty(bool[,] Board, int board)
        {
            for (int i = 0; i < board; i++)
            {
                for (int j = 0; j < board; j++)
                {
                    Board[i, j] = true;
                }
            }
            return Board;
        }
        static void Main(string[] args)
        {
            const int c = 19;
            int board = 8;
            int[,] xy = new int[2,c];
            int queen = 0;
            bool[,] Board = new bool[board, board];
            Board = Empty(Board, board) ;
            for(int j=0;j<c;j++)
            {
                xy= Queen(Board, xy, j);
                Board = HorizontandVertic(Board, xy, j);
                Board = Diagonal(Board, xy, j);
                queen++;
            }
            for(int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(xy[j, i].ToString());
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
