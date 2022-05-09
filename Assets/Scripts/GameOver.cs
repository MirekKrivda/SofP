using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private DeathCountHandler deathCounter;
    [SerializeField] private GameObject gameOverPanel;

    // Trigger for game over window
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            ShowGameOver();
        }
    }

    // Edits text in game over scene and sets the window active
    private void ShowGameOver()
    {

        text.text = "Vicorty!\n" + "Deaths: " + deathCounter.Count;
        gameOverPanel.SetActive(true);
        Time.timeScale= 0f;
    }
}
