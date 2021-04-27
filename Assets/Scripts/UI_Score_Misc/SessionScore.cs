using UnityEngine;
using System.Collections;

public class SessionScore : MonoBehaviour
{
    private int currentScore;

    UICanvas uiCanvas;

    void Start()
    {
        currentScore = 0;
        uiCanvas = FindObjectOfType<UICanvas>();
    }

    public void AddScore(int score)
    {
        currentScore += score;
        uiCanvas.UpdateScore(currentScore);
    }

    public int GetScore() { return currentScore; }
}
