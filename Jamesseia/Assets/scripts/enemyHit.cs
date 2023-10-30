using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHit : MonoBehaviour
{
    public float saladaDamage;

    projectileController myPC;
    public AudioClip hitSound;

    public GameObject explosionEffect;
    // Start is called before the first frame update
    void Start()
    {
        myPC = GetComponentInParent<projectileController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerC"))
        {
            myPC.removeForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            PlayHitSound();
            Destroy(gameObject);
            if (other.tag == "Player")
            {
                playerHealth hurtPlayer = other.gameObject.GetComponent<playerHealth>();
                hurtPlayer.addDamage(saladaDamage);
            }
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerC"))
        {
            myPC.removeForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            PlayHitSound();
            Destroy(gameObject);
            if (other.tag == "Player")
            {
                playerHealth hurtPlayer = other.gameObject.GetComponent<playerHealth>();
                hurtPlayer.addDamage(saladaDamage);
            }
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
