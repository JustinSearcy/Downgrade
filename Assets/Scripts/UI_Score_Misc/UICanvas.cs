using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UICanvas : MonoBehaviour
{
    [Header("UI Text")]
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI experienceText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI scoreMultiplierText;

    [Header("UI Other")]
    [SerializeField] Slider experienceBar;
    [SerializeField] GameObject scoreMultiplier;
    [SerializeField] GameObject controls;

    PlayerHealth playerHealth;
    LevelSystem levelSystem;
    ScoreTimer scoreTimer;

    bool hasStarted = false;

    void Start()
    {
        Time.timeScale = 0f;
        scoreTimer = FindObjectOfType<ScoreTimer>();
        levelSystem = FindObjectOfType<LevelSystem>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        DisplayText();
    }

    private void DisplayText()
    {
        healthText.text = "Health: " + playerHealth.GetHealth();
        experienceBar.value = levelSystem.CurrentExperience();
        experienceText.text = "Experience: " + levelSystem.CurrentExperience() + "/" + levelSystem.GetMaxExperience();
        levelText.text = "Lv: " + levelSystem.CurrentLevel();
        scoreText.text = "Score: 0";
    }

    private void Update()
    {
        if (!hasStarted)
        {
            if (Input.anyKey)
            {
                controls.SetActive(false);
                Time.timeScale = 1f;
                hasStarted = true;
            }
        }
        if (scoreTimer.MultiplierIsActive())
        {
            scoreMultiplier.SetActive(true);
            scoreMultiplierText.text = scoreTimer.GetScoreMultiplierTimer().ToString();
        }
        else
        {
            scoreMultiplier.SetActive(false);
        }
    }

    public void UpdateHealth()
    {
        healthText.text = "Health: " + playerHealth.GetHealth();
    }

    public void UpdateExperienceAndLevel(int experience, int level)
    {
        experienceText.text = "Experience: " + experience + "/" + levelSystem.GetMaxExperience();
        levelText.text = "Lv: " + level;
        experienceBar.value = experience;
    }

    public void UpdateExperience(int experience)
    {
        experienceText.text = "Experience: " + experience + "/" + levelSystem.GetMaxExperience();
        experienceBar.value = experience;
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }
}
