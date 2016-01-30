using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class DanceMovePrefab
{
    public List<Command> requiredCommands;
    public Texture2D texture;
    public int difficulty;

    public void Read(XmlNode node)
    {
        requiredCommands = new List<Command>();
        for (int i = 0; i < 3; i++)
        {
            requiredCommands.Add(new Command());
        }
        
        XmlNode commandsNode = node.FirstChild;
        XmlNode commandNode = commandsNode.FirstChild;
        while (commandNode != null)
        {
            int id = int.Parse(commandNode.Attributes["id"].Value);
            requiredCommands[id] = requiredCommands[id] | GameManager.GetCommandFromString(commandNode.Attributes["name"].Value);
            commandNode = commandNode.NextSibling;
        }

        string textureName = node.Attributes["textureName"].Value;
        texture = Resources.Load<Texture2D>("Textures/" + textureName);

        difficulty = int.Parse(node.Attributes["difficulty"].Value);
    }
}

public class DanceMove 
{
    public float remainingTime;
    public DanceMovePrefab prefab;

    public DanceMove(DanceMovePrefab prefab)
    {
        remainingTime = 8.0f;
        this.prefab = prefab;
    }
}
