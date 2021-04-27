using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    [SerializeField] int maxExperience = 100;
    [SerializeField] int maxLevel = 10;
    [SerializeField] GameObject clock;
    [SerializeField] GameObject levelUpParticles;

    int currentLevel;
    int currentExperience;

    UICanvas uiCanvas;
    PlayerStats stats;

    void Awake()
    {
        currentLevel = maxLevel;
        currentExperience = maxExperience;
        uiCanvas = FindObjectOfType<UICanvas>();
        stats = GetComponent<PlayerStats>();
    }
    public int GetMaxExperience() { return maxExperience; }

    public int CurrentExperience() { return currentExperience; }

    public int CurrentLevel() { return currentLevel; }

    public void UpdateExperience(int experience)
    {
        if((currentExperience - experience) <= 0 && currentLevel == 1)
        {
            currentExperience = 0;
            uiCanvas.UpdateExperience(currentExperience);
        }
        else
        {
            currentExperience -= experience;
            if (currentExperience <= 0)
            {
                LevelDown();
                currentExperience = maxExperience + currentExperience;
                uiCanvas.UpdateExperienceAndLevel(currentExperience, currentLevel);
                stats.LowerStats(currentLevel);
            }
            else { uiCanvas.UpdateExperience(currentExperience); }
        }
    }

    private void LevelDown()
    {
        if(currentLevel <= 1) { return; }
        else
        {
            currentLevel -= 1;
            GameObject effect = Instantiate(levelUpParticles, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            Time.timeScale = 0f;
            clock.GetComponent<Animator>().SetTrigger("levelDown");
        }
    }
}
