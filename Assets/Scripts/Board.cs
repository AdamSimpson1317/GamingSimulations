using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public readonly Cell[,] Cells;
    public readonly int CellSize;

    public int Columns {  get { return Cells.GetLength(0); }  }
    public int Rows { get { return Cells.GetLength(1); }  }
    public int Width { get { return CellSize * Columns; }  }
    public int Height { get { return CellSize * Rows; }  }

    public Board(int PassedWidth, int PassedHeight, int SizeOfCell, double LiveDensity = 0.1)
    {
        CellSize = SizeOfCell;
        Cells = new Cell[PassedWidth / CellSize, PassedHeight / CellSize];
        for(int i = 0; i < Columns; i++)
        {
            for(int j = 0; j < Rows; j++)
            {
                Cells[i, j] = new Cell();
            }
            //ConnectingNeighbours();
            //Randomize(liveDensity);
        }
    }

    //readonly Random random = new Random();

    public void Randomize(double LiveDensity)
    {
        foreach(var cell in Cells)
        {
            //cell.IsAlive = random.NextDouble() < LiveDensity;
        }
    }

    public void BoardAdvance()
    {
        foreach(var cell in Cells)
        {
            cell.DetermineNextLiveState();
        }
        foreach(var cell in Cells)
        {
            cell.AdvanceTime();
        }
    }

    private void ConnectingNeighbours()
    {
        for(int i = 0; i < Columns; i++)
        {
            for(int j = 0; j < Rows; j++)
            {
                //Determines the X value of the x cells (both left and right)
                int XNegative = (i > 0) ? i - 1: Columns - 1;
                int XPositive = (i < Columns - 1) ? i + 1: 0;

                //Determines the Y value of the y cells (both top and bottom)
                int YPositive = (j > 0) ? j - 1 : Rows - 1;
                int YNegative = (j < Rows - 1) ? j + 1 : 0;

                //Add the neighbours surrounding the current cell
                Cells[i, j].neighbours.Add(Cells[XNegative, YPositive]);
                Cells[i, j].neighbours.Add(Cells[i, YPositive]);
                Cells[i, j].neighbours.Add(Cells[XPositive, YPositive]);
                Cells[i, j].neighbours.Add(Cells[XNegative, j]);
                Cells[i, j].neighbours.Add(Cells[XPositive, j]);
                Cells[i, j].neighbours.Add(Cells[XNegative, YNegative]);
                Cells[i, j].neighbours.Add(Cells[i, YNegative]);
                Cells[i, j].neighbours.Add(Cells[XPositive, YNegative]);
            }
        }
    }
}
