using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float fullHealth;
    public GameObject DeathEffect;
    float currentHealth;

    playerController controlMovement;

    //HUD 
    public Slider healthSlider;
    public Image damageScreen;
    bool damaged = false;
    Color damagedColour = new Color(255f, 0f, 0f, 1.0f);
    float smoothColour = 5f;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = fullHealth;

        controlMovement = GetComponent<playerController>();

        //HUD
        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;
        damaged = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged)
        {
            damageScreen.color = damagedColour;
        }else
        {
            damageScreen.color= Color.Lerp(damageScreen.color, Color.clear, smoothColour*Time.deltaTime);

        }
        damaged = false;
    }

    public void addDamage(float damage)
    {
        if (damage <= 0) return;

        currentHealth -= damage;
        damaged = true;
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            makeDead();
        }
    }
    public void addHealth(float healthAmount)
    {
        

        currentHealth += healthAmount;
        if (currentHealth > fullHealth) currentHealth = fullHealth;
        healthSlider.value = currentHealth;

        
    }

    public void makeDead()
    {
        Instantiate(DeathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
