using UnityEngine;
using UnityEngine.UI;

public class HealthEnemy : MonoBehaviour
{
    public Slider Slider;
    public float HealthE = 100f;

    public int ExpMin = 1;
    public int ExpMax = 5;

    public int CoinMin = 10;
    public int CoinMax = 20;

    private int Exp;
    private int Coin;

    private GameObject Res;

    private Animator animator; // Tambahkan variabel Animator
    private bool isDead = false; // Tambahkan flag untuk status kematian

    void Start()
    {
        Exp = Random.Range(ExpMin, ExpMax);
        Coin = Random.Range(CoinMin, CoinMax);
        Slider.maxValue = HealthE;
        Res = GameObject.Find("Main Camera");
        animator = GetComponent<Animator>(); // Inisialisasi Animator
    }

    void Update()
    {
        Main();
    }

    void Main()
    {
        Slider.value = HealthE;

        if (HealthE <= 0 && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true; // Set flag isDead menjadi true
        animator.SetTrigger("Death"); // Memainkan animasi death

        // Tambahkan delay sebelum menghancurkan GameObject
        if (Res.GetComponent<ResourcesCastle>() != null)
        {
            Res.GetComponent<ResourcesCastle>().Experience += Exp;
            Res.GetComponent<ResourcesCastle>().Coins += Coin;
        }

        Destroy(gameObject, 1f); // Delay 2 detik agar animasi sempat diputar
    }
}
