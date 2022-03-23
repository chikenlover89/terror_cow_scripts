using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    public bool move = false;
    public Animator anim;
    public Transform endCoordinates;
    public float moveSpeed = 1;
    void Start()
    {
    }

    void Update()
    {
        standBehavior();
        moveBehavior();
    }

    void standBehavior()
    {
        if (!move)
        {
            if (anim.GetBool("isMoving") == true)
            {
                anim.SetBool("isMoving", false);
            }
        }
    }

    void moveBehavior()
    {
        if (move)
        {
            if (anim.GetBool("isMoving") == false)
            {
                anim.SetBool("isMoving", true);
            }
            if (transform.position != endCoordinates.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, endCoordinates.position, moveSpeed * Time.deltaTime);
            }
            else
            {
                move = false;
            }
        }
    }

    public void setMove(bool isMoving)
    {
        move = isMoving;
    }
}
