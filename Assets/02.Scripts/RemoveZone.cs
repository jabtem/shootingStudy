using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            //Destroy(col.gameObject);
            col.gameObject.SetActive(false);
        }
    }
}
