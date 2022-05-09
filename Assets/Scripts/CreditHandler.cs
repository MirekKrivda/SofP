using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditHandler : MonoBehaviour
{
    [SerializeField] private SceneHandler sh;

    private float timeToEndDefault = 109;
    private float timeToEnd;

    void Start()
    {
        timeToEnd = timeToEndDefault;
    }

    // Update is called once per frame
    void Update()
    {
        timeToEnd -= Time.deltaTime;
        if (timeToEnd<0)
        {
            sh.LoadScene("MainMenue");
        }
    }
}
