// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.SceneManagement;
// using System.Collections;

// public class CastleHealth : MonoBehaviour {

//     public Slider Sliders;
//     public float HealthCastle = 1000f;
//     public GameObject YouLose;
	
//     void Start()
//     {
//         Sliders.maxValue = HealthCastle;
//     }

// 	void Update () {

//         Sliders.value = HealthCastle;

//         StartCoroutine(HealthNull());

// 	}
//     IEnumerator HealthNull()
//     {
//         if (HealthCastle <= 0)
//         {
//             if (Input.GetKeyUp(KeyCode.Escape))
//             {
//                 Time.timeScale = 1;
//             }

//             YouLose.SetActive(true);           
//             yield return new WaitForSeconds(5);
//             SceneManager.LoadScene(0);
//         }
//     }
// }

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CastleHealth : MonoBehaviour {

    public Slider Sliders;
    public float HealthCastle = 1000f;
    public GameObject YouLose;
    public AudioClip scream; // Reference to the scream sound
    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        Sliders.maxValue = HealthCastle;
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
    }

    void Update () 
    {
        Sliders.value = HealthCastle;

        StartCoroutine(HealthNull());

        // Check if health is below 5 and play scream sound if not already played
        if (HealthCastle < 5 && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(scream);
        }
    }

    IEnumerator HealthNull()
    {
        if (HealthCastle <= 0)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                Time.timeScale = 5;
            }

            YouLose.SetActive(true);           
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene(0);
        }
    }
}