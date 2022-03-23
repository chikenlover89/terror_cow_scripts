using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPlus : MonoBehaviour
{
    private Transform startCoordinates;
    private Transform endCoordinates;
    private Transform patrolObject;

    public float moveSpeed = 10;

    private Vector3 currentTarget;
    void Start()
    {
        patrolObject = gameObject.transform.Find("Item").transform;
        startCoordinates = gameObject.transform.Find("Point2").transform;
        endCoordinates = gameObject.transform.Find("Point1").transform;

        currentTarget = endCoordinates.position;
    }

    void Update()
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
