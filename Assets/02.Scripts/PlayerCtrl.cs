using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float moveSpeed = 0.5f;

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
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
}
