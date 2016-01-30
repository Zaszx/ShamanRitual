using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class GameManager : MonoBehaviour 
{
    public List<Tribeman> tribemans = new List<Tribeman>();
    public float godAnger = 0;
    public int score = 0;

    public GuiManager guiManager;
    public DanceMoveManager danceMoveManager;

    public static Command GetCommandFromString(string s)
    {
        if (s == "LeftHandUp")
        {
            return Command.LeftHandUp;
        }
        else if (s == "LeftLegUp")
        {
            return Command.LeftLegUp;
        }
        else if (s == "RightHandUp")
        {
            return Command.RightHandUp;
        }
        else if (s == "RightLegUp")
        {
            return Command.RightLegUp;
        }
        return Command.None;
    }

	void Start () 
    {
        guiManager = new GuiManager(this);
        danceMoveManager = new DanceMoveManager();

        for (int i = 0; i < 3; i++)
        {
            GameObject tribemanObject = GameObject.Find("Tribeman_" + i);
            Tribeman newTribeman = new Tribeman(tribemanObject);
            tribemans.Add(newTribeman);
        }
	}

    void OnGUI()
    {
        guiManager.Render();
    }

    void Update() 
    {
        danceMoveManager.Tick();
        foreach (Tribeman tribeman in tribemans)
        {
            tribeman.Tick();
        }
        CheckInput();
        CheckDanceMove();

        godAnger = godAnger - Time.deltaTime;
        godAnger = Mathf.Max(0, godAnger);
	}

    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            tribemans[0].selected = !tribemans[0].selected;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            tribemans[1].selected = !tribemans[1].selected;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            tribemans[2].selected = !tribemans[2].selected;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            foreach (Tribeman man in tribemans)
            {
                man.selected = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            foreach (Tribeman man in tribemans)
            {
                man.selected = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            foreach (Tribeman man in tribemans)
            {
                man.ReceiveCommand(Command.LeftHandUp);
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            foreach (Tribeman man in tribemans)
            {
                man.ReceiveCommand(Command.RightHandUp);
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (Tribeman man in tribemans)
            {
                man.ReceiveCommand(Command.LeftLegUp);
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            foreach (Tribeman man in tribemans)
            {
                man.ReceiveCommand(Command.RightLegUp);
            }
        }
    }

    void CheckDanceMove()
    {
        List<Command> requiredCommands = danceMoveManager.GetCurrentMoveRequirements();
        if (requiredCommands != null)
        {
            bool success = true;
            for (int i = 0; i < tribemans.Count; i++)
            {
                if (tribemans[i].bodyStatus != requiredCommands[i])
                {
                    success = false;
                }
            }

            if (success)
            {
                score = score + 100;
            }
            else
            {
                godAnger = godAnger + 50;
            }
        }
    }
}
