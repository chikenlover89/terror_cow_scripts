using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private GameObject item;
    private Enemy script;
    private bool selfDestruct = false;
    public GameObject explosion;
    public AudioSource explodeSound;
    void Start()
    {
        item = gameObject.transform.Find("Item").gameObject;
        script = item.GetComponent<Enemy>();
    }

    void Update()
    {
        if (script.isDeadNow() && selfDestruct == false)
        {
            item.SetActive(false);
            selfDestruct = true;
            Instantiate(explosion, item.transform.position, item.transform.rotation);
            explodeSound.Play();
            Destroy(gameObject, 1f);
        }
    }
}
