using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
    public List<Tribeman> tribemans = new List<Tribeman>();
    public int tribemanCount = 3;

    public int godAnger = 0;
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
	}

    void CheckInput()
    {

    }

    void CheckDanceMove()
    {

    }
}
