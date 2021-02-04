using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] Show show;
    public void Play()
    {
        SceneManager.LoadScene("Game");
        Handler.GState = Handler.GameState.play;
    }
    public void ShowScore()
    {
        show.Points();
    }
}
