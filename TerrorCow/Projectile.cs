using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float m_Speed = 10f;   // this is the projectile's speed
    public float m_Lifespan = 3f; // this is the projectile's lifespan (in seconds)
    private int direction = 1;

    private Rigidbody2D m_Rigidbody;

    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    public void setDirection(int dir)
    {
        direction = dir;
    }
    public void shoot()
    {
        m_Rigidbody.AddForce(transform.right * m_Speed * direction);
        Destroy(gameObject, m_Lifespan);
    }
}
