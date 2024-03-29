﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    Vector3[] positions = new Vector3[5];
    //public GameObject enemy;
    public static bool isSpawn = false;

    float spawnDelay = 1.5f;
    float spawnTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        CreatePosion();
    }

    void CreatePosion()
    {
        float viewPosY = 1.2f;

        float gapX = 1 / 6.0f;
        float viewPosX = 0.0f;

        for(int i= 0; i < positions.Length; i++)
        {
            viewPosX = gapX + gapX * i;
            Vector3 viewPos = new Vector3(viewPosX, viewPosY, 0);
            Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
            worldPos.z = 0.0f;

            positions[i] = worldPos;

            Debug.Log(positions[i]);
        }
    }

    void Update()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        if(isSpawn == true)
        {
            if(spawnTimer > spawnDelay)
            {
                int rand = Random.Range(0, positions.Length);
                ObjectManager.oinstance.GetEnemy(positions[rand]);
                //Instantiate(enemy, positions[rand], Quaternion.identity);
                spawnTimer = 0.0f;
            }
            spawnTimer += Time.deltaTime;
        }
    }
}
