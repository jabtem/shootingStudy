using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public GameObject explosionPrefab;
    int killScore = 100;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }
    void MoveEnemy()
    {
        float yMove = moveSpeed * Time.deltaTime;
        transform.Translate(0, -yMove, 0);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
            SoundManager.sinstance.PlaySound();
            GameManager.ginstance.KillPlayer();
            //Destroy(col.gameObject);
            col.gameObject.SetActive(false);
            PlayerCtrl.canShot = false;
            //Destroy(gameObject);
            this.gameObject.SetActive(false);
        }
        else if(col.gameObject.tag == "Bullet")
        {
            Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
            SoundManager.sinstance.PlaySound();
            GameManager.ginstance.AddScore(killScore);
            //Destroy(col.gameObject);
            col.gameObject.SetActive(false);
            //Destroy(gameObject);
            this.gameObject.SetActive(false);
        }
    }
}
