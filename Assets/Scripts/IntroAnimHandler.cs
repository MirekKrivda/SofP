using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IntroAnimHandler : MonoBehaviour
{
    [SerializeField] Animator animPumpkin;

    [SerializeField] GameObject goPumpkin;
    [SerializeField] GameObject goFarmer;
    [SerializeField] GameObject goSoldier;
    [SerializeField] GameObject goMerlin;
    [SerializeField] GameObject bubbleLeft;
    [SerializeField] GameObject bubbleRight;

    [SerializeField] SceneHandler sh;

    [SerializeField] TMP_Text bubbleLeftText;
    [SerializeField] TMP_Text bubbleRightText;

    private int sceneNumber;


    private void Start()
    {
        sceneNumber = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sceneNumber++;
            StartScene(sceneNumber);
        }
    }

    private void StartScene(int sceneIndex)
    {
        switch (sceneIndex)
        {
            case 1:
                {
                    bubbleRightText.text = "The King wants to have only Potatoes next Year!";
                    bubbleRight.SetActive(true);
                    break;
                }
            case 2:
                {
                    bubbleRightText.text = "No one want your holey Pumpkins!";
                    animPumpkin.Play("Pumpkin_Surprised");
                    break;
                }
            case 3:
                {
                    bubbleLeftText.text = "But i love my holey Pumpkins!";
                    bubbleRight.SetActive(false);
                    bubbleLeft.SetActive(true);

                    break;
                }
            case 4:
                {
                    bubbleRightText.text = "You must follow the order or you'll die !!!";
                    bubbleRight.SetActive(true);
                    bubbleLeft.SetActive(false);
                    break;
                }
            case 5:
                {
                    animPumpkin.Play("PumpkinSad");
                    bubbleLeftText.text = "Okay... stupid Potatoes...";
                    bubbleRight.SetActive(false);
                    bubbleLeft.SetActive(true);
                    break;
                }
            case 6:
                {
                    bubbleLeft.SetActive(false);
                    animPumpkin.Play("PumpkinCry");
                    Destroy(goFarmer);
                    Destroy(goSoldier);
                    break;
                }
            case 7:
                {
                    goMerlin.SetActive(true);
                    break;
                }
            case 8:
                {
                    bubbleLeftText.text = "Don't be sad little Pumpkin!";
                    bubbleLeft.SetActive(true);
                    break;
                }
            case 9:
                {
                    animPumpkin.Play("Pumpkin_Surprised");
                    bubbleLeftText.text = "There is still hope for you and your Familie.";
                    break;
                }
            case 10:
                {
                    animPumpkin.Play("PimmkingHappy");
                    bubbleLeftText.text = "If you want to safe the Pumpkin's you need to become the King!";
                    break;
                }
            case 11:
                {
                    bubbleLeftText.text = "On top of the mountain is a sword named Excalibur.";
                    break;
                }
            case 12:
                {
                    animPumpkin.Play("Pumpkin_Surprised");
                    bubbleLeftText.text = "It's stuck in a stone and who ever can get it out becomes the King.";
                    break;
                }
            case 13:
                {
                    animPumpkin.Play("PimmkingHappy");
                    bubbleLeftText.text = "I'll give you feets to get to the sword but i must warn you...";
                    break;
                }
            case 14:
                {
                    bubbleLeftText.text = "...the King doesnt want anyone else to get to the sword...";
                    break;
                }
            case 15:
                {
                    animPumpkin.Play("Pumpkin_Surprised");
                    bubbleLeftText.text = "...the Path is full of Traps!";
                    break;
                }
            case 16:
                {
                    animPumpkin.Play("PimmkingHappy");
                    bubbleLeftText.text = "But i am sure you will get there!";
                    break;
                }
            case 17:
                {
                    sh.LoadScene("SampleScene");
                    break;
                }
            default:
                break;
        }
    }


}
