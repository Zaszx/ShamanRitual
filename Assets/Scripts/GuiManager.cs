using UnityEngine;
using System.Collections;

public class GuiManager
{
    public GameManager gameManager;
    public GUIText scoreText;
    public GUIText godAngerText;

    public GuiManager(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public void Render()
    {
        GUIStyle centerAlignment = new GUIStyle();
        centerAlignment.alignment = TextAnchor.MiddleCenter;
        GUI.TextArea(new Rect(0, 0, Screen.width, 20), "Score: " + (int)gameManager.score, centerAlignment);
        GUI.TextArea(new Rect(0, 20, Screen.width, 20), "Anger: " + (int)gameManager.godAnger, centerAlignment);

        gameManager.danceMoveManager.Render();
    }
}
