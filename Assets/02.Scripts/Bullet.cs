using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 0.45f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveY = bulletSpeed * Time.deltaTime;
        transform.Translate(0, moveY, 0);
    }

    void OnBecameInvisible()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
