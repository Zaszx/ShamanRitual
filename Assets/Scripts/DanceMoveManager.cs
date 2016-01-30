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
    float timeSinceLastSpawn = 0;
    public DanceMoveManager()
    {

    }

    public void Tick()
    {
        for (int i = 0; i < danceMoves.Count; i++ )
        {
            DanceMove currentMove = danceMoves[i];
            currentMove.remainingTime -= Time.deltaTime;
            if (currentMove.remainingTime < -0.3f)
            {
                danceMoves.RemoveAt(i);
                i--;
            }
        }

        timeSinceLastSpawn = timeSinceLastSpawn + Time.deltaTime;
        SpawnMove();
    }

    private void SpawnMove()
    {
        bool spawnRequired = false;
        if (danceMoves.Count == 0)
        {
            spawnRequired = true;
        }
        spawnRequired = (timeSinceLastSpawn - 1.5f) * Random.value > 0.5f;

        if (spawnRequired)
        {

        }
    }

    public List<Command> GetCurrentMoveRequirements()
    {

        return null;
    }
}
