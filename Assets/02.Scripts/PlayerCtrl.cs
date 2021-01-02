using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    //public GameObject bullet;
    public static bool canShot = false;
    float shotDelay = 0.5f;
    float shotTimer = 0.0f;

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Shot();
    }
    void MovePlayer()
    {
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        transform.Translate(moveX, 0, 0);

        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x);
        Vector3 wordlPos = Camera.main.ViewportToWorldPoint(viewPos);
        transform.position = wordlPos;
    }

    void Shot()
    {
        if (canShot == true)
        {
            if (shotTimer > shotDelay)
            {
                ObjectManager.oinstance.GetBullet(transform.position);
                //Instantiate(bullet, transform.position, Quaternion.identity);
                shotTimer = 0.0f;
            }
            shotTimer += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            GameManager.ginstance.KillPlayer();
        }
    }
}
