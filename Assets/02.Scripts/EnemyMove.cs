using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float moveSpeed = 0.5f;
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
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
