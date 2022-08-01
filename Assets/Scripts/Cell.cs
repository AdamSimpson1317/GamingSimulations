using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool IsAlive;
    public readonly List<Cell> neighbours = new List<Cell>();

    private bool IsAliveNext;

    public void DetermineNextLiveState()
    {
        //Alive cells with 1 or 0 neighbours die.
        //Alive cells with 4 or more neighbours die.
        //Dead cells with three live neighbours become alive.

        //int LiveNeighbours = neighbours.Where(x => x.IsAlive).Count();

        if (IsAlive)
        {
            //IsAliveNext = LiveNeighbours == 2 || LiveNeighbours == 3;
        }
        else
        {
            //IsAliveNext = LiveNeighbours == 3;
        }
    }

    public void AdvanceTime()
    {
        IsAlive = IsAliveNext;
    }
}
