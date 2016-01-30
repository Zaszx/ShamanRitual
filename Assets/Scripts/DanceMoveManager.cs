using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct DanceMove
{
    public List<Command> requiredBodyStatuses = new List<Command>();
    public Texture2D texture;
    public float remainingTime;
}

public class DanceMoveManager
{
    List<DanceMove> danceMoves = new List<DanceMove>();
    public DanceMoveManager()
    {

    }

    public void Tick()
    {
        for (int i = 0; i < danceMoves.Count; i++ )
        {
            DanceMove currentMove = danceMoves[i];
            currentMove.remainingTime -= Time.deltaTime;
            if (currentMove.remainingTime < -5)
            {
                danceMoves.RemoveAt(i);
                i--;
            }
        }
    }

    private void SpawnMove()
    {

    }

    public List<Command> GetCurrentMoveRequirements()
    {

        return null;
    }
}
