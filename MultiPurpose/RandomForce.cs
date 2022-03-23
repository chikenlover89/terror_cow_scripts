using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomForce : MonoBehaviour
{
    
    void Start()
    {
        Rigidbody2D thisRigidBody = GetComponent<Rigidbody2D>();
        thisRigidBody.velocity = new Vector3(Random.Range(-10,10), Random.Range(-10, 10), 0f);
    }

}
