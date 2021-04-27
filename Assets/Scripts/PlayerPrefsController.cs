using UnityEngine;
using System.Collections;

public class PlayerPrefsController : MonoBehaviour
{
    const string HIGH_SCORE = ("high score");

    public static void InitializeHighScore()
    {
        if(!PlayerPrefs.HasKey(HIGH_SCORE))
        {
            PlayerPrefs.SetInt(HIGH_SCORE, 0);
        }
        else
        {
            return;
        }
    }

    public static void SetHighScore(int score)
    {
        PlayerPrefs.SetInt(HIGH_SCORE, score);
    }

    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE);
    }
}
