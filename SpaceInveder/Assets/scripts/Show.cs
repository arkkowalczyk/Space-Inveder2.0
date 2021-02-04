using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Show : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] text = new TextMeshProUGUI[10];
    [SerializeField] TextMeshProUGUI gp;
    [SerializeField] GameObject game, gameover;
    
    public void Points()
    {
        bool onlyOne = true;
        Scors scors = HIghScors.Load();
        gp.text = "Games Played: " + scors.gamesPlayed;
        for (int i = 0; i < 10; i++)
        {
            text[i].text = (i + 1) + ": " + scors.hs[i];
            if (scors.hs[i]==Handler.ScoreCount && onlyOne) {
                text[i].color = new Color32(255, 128, 0, 255);
                text[i].fontWeight = FontWeight.Bold;
                onlyOne = false;
            }
        }
    }
    public void Change()
    {
        game.SetActive(false);
        gameover.SetActive(true);
    }
    public void Back()
    {
        SceneManager.LoadScene("Menu");
        Handler.GState = Handler.GameState.menu;
    }
}
