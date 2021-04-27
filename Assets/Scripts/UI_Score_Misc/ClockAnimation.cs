using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockAnimation : MonoBehaviour 
{
    [SerializeField] AudioSource clockAudioSource;

    private void Start()
    {
        clockAudioSource = GetComponent<AudioSource>();
    }

    public void SetGameSpeed(float speed)
    {
        Time.timeScale = speed;
        GetComponent<Animator>().SetTrigger("normal");
    }

    public void PlayClockAudio()
    {
        clockAudioSource.Play();
    }

    public void StopClockAudio()
    {
        clockAudioSource.Stop();
    }
}