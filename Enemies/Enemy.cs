using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int lives = 10;
    private bool hurt = false;
    private SpriteRenderer sprite;
    private float hurtDelay = 0f;
    public bool isDead = false;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        getHurt();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
        {
            hurt = true;
        }
    }

    private void getHurt()
    {

        if (hurt == true && hurtDelay <= 0)
        {
            hurtDelay = 0.5f;
            sprite.color = new Color(1, 0.5f, 0.5f, 1);
        }
        if (hurtDelay > 0f)
        {
            hurtDelay -= Time.deltaTime;
        }
        else
        {
            sprite.color = new Color(1, 1, 1, 1);
        }

        if (hurt == true)
        {
            lives--;

            hurt = false;
        }

        if(lives < 1)
        {
            isDead = true;
        }
    }

    public bool isDeadNow()
    {
        return isDead;
    }
}
