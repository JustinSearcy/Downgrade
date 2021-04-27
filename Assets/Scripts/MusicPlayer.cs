using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] float musicVolume = 0.5f;

    private void Awake() //Singleton pattern to only have one game session
    {
        int constantsCount = FindObjectsOfType<MusicPlayer>().Length;
        if (constantsCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = musicVolume;
    }
}
