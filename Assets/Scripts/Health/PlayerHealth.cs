using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    //[SerializeField] private AudioSource deathSoundEffect;

    //public Healthbar healthbar;

    void Awake()
    {
        Debug.Log("initialized healthj");
        currentHealth = maxHealth;
        //healthbar.SetMaxHealth(maxHealth);
    }
}
