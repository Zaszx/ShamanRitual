using UnityEngine;
using System.Collections;
using System;

[Flags]
public enum Command : int
{
    LeftLegUp   = 0x00000001,
    RightLegUp  = 0x00000002,
    LeftHandUp  = 0x00000004,
    RightHandUp = 0x00000008,
}

public class Tribeman
{
    public GameObject gameObject;
    public bool selected = false;
    public Command bodyStatus;
    public Tribeman(GameObject gameObject)
    {
        this.gameObject = gameObject;
    }
	
	public void Tick () 
    {
	    
	}

    public void ReceiveCommand(Command command)
    {
        bodyStatus = bodyStatus ^ command;
        UpdateAnimation();
    }

    public void UpdateAnimation()
    {

    }
}
