using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
    public List<Tribeman> tribemans = new List<Tribeman>();
    public int tribemanCount = 3;

    public float godAnger = 0;
    public int score = 0;

    public GuiManager guiManager;
    public DanceMoveManager danceMoveManager;

	void Start () 
    {
        guiManager = new GuiManager(this);
        danceMoveManager = new DanceMoveManager();

        for (int i = 0; i < tribemanCount; i++)
        {
            GameObject tribemanObject = GameObject.Find("Tribaman_" + i);
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
        foreach (Tribeman tribeman in tribemans)
        {
            tribeman.Tick();
        }
        CheckInput();
        CheckDanceMove();

        godAnger = godAnger - Time.deltaTime;
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

    }
}
