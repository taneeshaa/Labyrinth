using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    //[SerializeField] private AudioSource deathSoundEffect;

    public Healthbar healthbar;

    void Awake()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth/100);
    }

}
