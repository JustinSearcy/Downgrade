using UnityEngine;
using System.Collections;
using TMPro;

public class GameOverCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI sessionScore;
    [SerializeField] TextMeshProUGUI highScore;

    [SerializeField] GameObject highScoreObject;

    [SerializeField] AudioClip canvasSlide;
    [SerializeField] float canvasSlideVolume = 0.8f;

    private void Start()
    {
        AudioSource.PlayClipAtPoint(canvasSlide, transform.position, canvasSlideVolume);
    }
    public void DisplayScore()
    {
        sessionScore.text = FindObjectOfType<SessionScore>().GetScore().ToString();
        highScore.text = PlayerPrefsController.GetHighScore().ToString();
    }

    public void HighScoreActive()
    {
        highScoreObject.SetActive(true);
    }
}
