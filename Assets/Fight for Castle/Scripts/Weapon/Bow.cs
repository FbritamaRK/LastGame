// using UnityEngine;

// public class Bow : MonoBehaviour {

//     public GameObject Arrow;
//     public Transform SpawnArrow;
//     public float Force;
//     public float RateOfFire = 0.5F;

//     private float nextFire = 0.5F;
//     private float myTime = 0.0F;
	
// 	void FixedUpdate () {

//         myTime = myTime + Time.deltaTime;

//         if (Input.GetButtonUp("Fire1") && myTime > nextFire)
//         {
//             nextFire = myTime + RateOfFire;
//             GameObject NewArrow = Instantiate(Arrow, SpawnArrow.transform.position, transform.rotation);
//             NewArrow.transform.localScale = new Vector2(0.4f, 0.4f);
//             NewArrow.GetComponent<Rigidbody2D>().AddForce(NewArrow.transform.right * Force);
//             nextFire = nextFire - myTime;
//             myTime = 0.0F;
//         }
//     }
// }


using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject Arrow; // Prefab panah
    public Transform SpawnArrow; // Titik spawn panah
    public float Force; // Gaya tembakan
    public float RateOfFire = 0.5F; // Kecepatan tembakan

    private float nextFire = 0.5F; // Waktu berikutnya bisa menembak
    private float myTime = 0.0F; // Timer untuk tembakan
    private AudioSource audioSource; // Komponen AudioSource
    public AudioClip bowSound; // Suara saat menembak

    void Start()
    {
        // Menambahkan komponen AudioSource jika belum ada
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = bowSound; // Mengatur clip suara
    }

    void FixedUpdate()
    {
        myTime += Time.deltaTime;

        if (Input.GetButtonUp("Fire1") && myTime > nextFire)
        {
            nextFire = myTime + RateOfFire;

            // Membuat panah baru
            GameObject NewArrow = Instantiate(Arrow, SpawnArrow.position, transform.rotation);
            NewArrow.transform.localScale = new Vector2(0.4f, 0.4f);
            NewArrow.GetComponent<Rigidbody2D>().AddForce(NewArrow.transform.right * Force);

            // Memainkan suara saat menembak
            audioSource.Play();

            nextFire -= myTime;
            myTime = 0.0F;
        }
    }
}