using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DeathCountHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text counterText;
    [SerializeField] private GameObject pussyGras;
    [SerializeField] private GameObject pussyFlower;

    public int Count { get; set; }


    void Start()
    {
        Count = 0;
    }

    // Adds one death to the global Deathcounter
    public void AddDeathToCount()
    {
        Count++;
        if (Count > 1)
        {
            counterText.text = Count + "\nDeaths";
        }
        else
        {
            counterText.text = Count + "\nDeath";
        }
        if (Count==100)
        {
            pussyGras.SetActive(true);
            pussyFlower.SetActive(true);
        }
    }
}
