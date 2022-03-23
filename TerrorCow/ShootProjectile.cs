using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public GameObject projectile;
    public GameObject startCoordinates;
    public TerrorCow terrorCow;
    public AudioSource shootSound;
    void Start()
    {
        startCoordinates = gameObject.transform.Find("ProjectileSpot").gameObject;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject clone = Instantiate(projectile, startCoordinates.transform.position, startCoordinates.transform.rotation);
            Projectile script = clone.GetComponent<Projectile>();
            script.setDirection(1);
            if(!terrorCow.isFacingRight())
            {
                script.setDirection(-1);
            }
            script.shoot();
            shootSound.Play();
        }
    }
}
