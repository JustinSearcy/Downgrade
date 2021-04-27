using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] float timeBeforeGameOver = 3f;
    [SerializeField] GameObject uiCanvas;
    [SerializeField] GameObject gameOverCanvas;

    public void Die()
    {
        StartCoroutine(DisplayGameOver());
    }

    IEnumerator DisplayGameOver()
    {
        yield return new WaitForSeconds(timeBeforeGameOver);
        Time.timeScale = 0f;
        uiCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        if (FindObjectOfType<SessionScore>().GetScore() >= PlayerPrefsController.GetHighScore())
        {
            PlayerPrefsController.SetHighScore(FindObjectOfType<SessionScore>().GetScore());
            FindObjectOfType<GameOverCanvas>().HighScoreActive();
        }
        FindObjectOfType<GameOverCanvas>().DisplayScore();
    }
}
