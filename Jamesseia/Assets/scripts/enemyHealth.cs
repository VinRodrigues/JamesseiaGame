using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    public float enemyMaxHealth;

    float currentHealth;
    public GameObject enemyDeath;

    public bool drops;
    public GameObject theDrop;

    //HUD
    public Slider enemyBar;

    void Start()
    {
        currentHealth = enemyMaxHealth;  
        enemyBar.maxValue = currentHealth;
        enemyBar.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void addDamage(float damage)
    {
        //enemyBar.gameObject.SetActive(true);
        currentHealth -= damage;
        enemyBar.value = currentHealth;
        if (currentHealth <= 0) makeDead();

    }

    void makeDead()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.concludeFase();

        Destroy(gameObject);
        Instantiate(enemyDeath, transform.position, transform.rotation);
        if (drops) Instantiate(theDrop, transform.position, transform.rotation);
    }
}
