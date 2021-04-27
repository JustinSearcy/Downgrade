using UnityEngine;
using System.Collections;

public class ScoreTimer : MonoBehaviour
{
    [SerializeField] float multiplierTimeIncrease = 10f;

    float multiplierTime = 0f;

    bool multiplierActive = false;

    void Update()
    {
        if(multiplierTime > 0)
        {
            multiplierActive = true;
        }

        if(multiplierTime <= 0)
        {
            multiplierActive = false;
            multiplierTime = 0;
        }
        multiplierTime -= Time.deltaTime;
    }

    public void IncreaseTime()
    {
        multiplierTime += multiplierTimeIncrease;
    }

    public bool MultiplierIsActive() { return multiplierActive; }

    public int GetScoreMultiplierTimer() { return (int)multiplierTime; }
}
