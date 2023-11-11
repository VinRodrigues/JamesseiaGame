using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthLoot : MonoBehaviour
{
    public float healthAmount;
    public AudioClip hitSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayHitSound();
            playerHealth Health = other.gameObject.GetComponent<playerHealth>();
            Health.addHealth(healthAmount);
            Destroy(gameObject);
        }
    }
    private void PlayHitSound()
    {
        if (hitSound != null)
        {
            AudioSource.PlayClipAtPoint(hitSound, transform.position);
        }
    }
}
