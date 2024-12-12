using UnityEngine;

public class ArrowShooter : MonoBehaviour
{
    public AudioClip bowSound; // Suara yang akan diputar saat menembak
    private AudioSource audioSource; // Komponen AudioSource

    void Start()
    {
        // Menambahkan komponen AudioSource jika belum ada
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = bowSound; // Mengatur clip suara
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Jika tombol tembak ditekan (biasanya mouse kiri)
        {
            PlayBowSound(); // Memainkan suara saat menembak
        }
    }

    void PlayBowSound()
    {
        audioSource.Play(); // Memainkan suara
    }
}