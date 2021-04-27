using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationStuff : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 300;
        PlayerPrefsController.InitializeHighScore();
    }
}
