using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopperBot : MonoBehaviour
{
    private Transform startCoordinates;
    private Transform endCoordinates;
    private Transform patrolObject;
    private GameObject item;
    private Animator anim;
    public Transform player;

    private Enemy script;
    public GameObject explosion;

    private bool selfDestruct = false;

    public float moveSpeed = 10;
    public bool shoot = false;

    private Vector3 currentTarget;

    public AudioSource explodeSound;
    public AudioSource shootSound;
    void Start()
    {
        item = gameObject.transform.Find("Item").gameObject;
        anim = item.GetComponent<Animator>();
        script = item.GetComponent<Enemy>();
        patrolObject = item.transform;
        startCoordinates = gameObject.transform.Find("Point2").transform;
        endCoordinates = gameObject.transform.Find("Point1").transform;

        currentTarget = endCoordinates.position;
    }

    void Update()
    {
        checkIfDead();
        shootBehavior();
        patrolBehavior();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shoot = true;
            anim.SetBool("terrorize", true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            anim.SetBool("terrorize", false);
            shoot = false;
        }
    }

    void patrolBehavior ()
    {
        if (shoot == false)
        {
            patrolObject.position = Vector3.MoveTowards(patrolObject.position, currentTarget, moveSpeed * Time.deltaTime);

            if (patrolObject.position == endCoordinates.position)
            {
                currentTarget = startCoordinates.position;
                patrolObject.localScale = new Vector3(patrolObject.localScale.x * (-1), patrolObject.localScale.y, patrolObject.localScale.y);
            }

            if (patrolObject.position == startCoordinates.position)
            {
                currentTarget = endCoordinates.position;
                patrolObject.localScale = new Vector3(patrolObject.localScale.x * (-1), patrolObject.localScale.y, patrolObject.localScale.y);
            }
        }
    }

    void checkIfDead()
    {
        if (script.isDeadNow() && selfDestruct == false)
        {
            explodeSound.Play();
            item.SetActive(false);
            selfDestruct = true;
            Instantiate(explosion, item.transform.position, item.transform.rotation);
            Destroy(gameObject, 1f);
        }
    }

    void shootBehavior()
    {
        if (shoot == true)
        {
            if (player.position.x > patrolObject.position.x)
            {
                patrolObject.localScale = new Vector3(Mathf.Abs(patrolObject.localScale.x) * (-1), patrolObject.localScale.y, patrolObject.localScale.y);
            }
            else
            {
                patrolObject.localScale = new Vector3(Mathf.Abs(patrolObject.localScale.x), patrolObject.localScale.y, patrolObject.localScale.y);
            }
        }
    }
}
