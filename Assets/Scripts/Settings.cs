using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;

    // Handles volume of selected audio source
    public void UpdateSoundVolume()
    {
        musicSource.volume = GetComponent<Slider>().value;
    }
}
