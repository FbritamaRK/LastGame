using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public AudioClip backgroundSound; // Reference to the background sound
    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
        
        // Load the background sound from Resources if not assigned in Inspector
        if (backgroundSound == null)
        {
            backgroundSound = Resources.Load<AudioClip>("homesnd"); // Ensure 'homesnd' is in Resources folder
        }

        PlayBackgroundSound();
    }

    void PlayBackgroundSound()
    {
        if (backgroundSound != null && !audioSource.isPlaying)
        {
            audioSource.clip = backgroundSound; // Assign the clip
            audioSource.loop = true; // Set to loop
            audioSource.Play(); // Play the background sound
        }
    }

    public void StartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}