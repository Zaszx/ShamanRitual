using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class DanceMoveManager
{
    List<DanceMove> danceMoves = new List<DanceMove>();
    List<DanceMovePrefab> danceMovePrefabs = new List<DanceMovePrefab>();
    float timeSinceLastSpawn = 0;
    public DanceMoveManager()
    {
        ReadPrefabs();
    }

    public void ReadPrefabs()
    {
        XmlDocument d = new XmlDocument();
        string xmlFilePath = Application.dataPath + "/DanceMovePrefabs.xml";
        d.Load(xmlFilePath);
        XmlNode prefabsNode = d.FirstChild;
        XmlNode prefabNode = prefabsNode.FirstChild;
        while (prefabNode != null)
        {
            DanceMovePrefab newPrefab = new DanceMovePrefab();
            newPrefab.Read(prefabNode);

            danceMovePrefabs.Add(newPrefab);
            prefabNode = prefabNode.NextSibling;
        }
    }

    public void Render()
    {
        for (int i = 0; i < danceMoves.Count; i++)
        {
            DanceMove currentMove = danceMoves[i];
            float danceMoveX = (currentMove.remainingTime / 8.0f) * Screen.width + 20;
            GUI.DrawTexture(new Rect(danceMoveX, 30, 128, 64), currentMove.prefab.texture);
        }
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
        if (timeSinceLastSpawn > 6.0f && Random.value > 0.0005f)
        {
            spawnRequired = true;
        }

        if (spawnRequired)
        {
            timeSinceLastSpawn = 0;
            int prefabIndex = Random.Range(0, danceMovePrefabs.Count - 1);
            DanceMove newDanceMove = new DanceMove(danceMovePrefabs[prefabIndex]);
            danceMoves.Add(newDanceMove);
            Debug.Log("Spawned!");
        }
    }

    public List<Command> GetCurrentMoveRequirements()
    {
        for (int i = 0; i < danceMoves.Count; i++)
        {
            if (danceMoves[i].remainingTime < 0.01f && danceMoves[i].remainingTime > 0)
            {
                return danceMoves[i].prefab.requiredCommands;
            }
        }
        return null;
    }
}
