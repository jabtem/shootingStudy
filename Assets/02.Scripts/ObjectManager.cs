using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager oinstance;
    public GameObject bullet;
    public GameObject enemy;
    List<GameObject> bullets = new List<GameObject>();
    List<GameObject> enemys = new List<GameObject>();

    void Awake()
    {
        if(ObjectManager.oinstance == null)
        {
            ObjectManager.oinstance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        CreateBullets(5);
        CreateEnemys(5);
    }

    // Update is called once per frame
    void CreateBullets(int bulletcnt)
    {
        for(int i=0; i< bulletcnt;i++)
        {
            GameObject bulletObject = Instantiate(bullet) as GameObject;
            bulletObject.transform.parent = transform;
            bulletObject.SetActive(false);
            bullets.Add(bulletObject);
        }
    }

    void CreateEnemys(int enemycnt)
    {
        for (int i = 0; i < enemycnt; i++)
        {
            GameObject enemytObject = Instantiate(enemy) as GameObject;
            enemytObject.transform.parent = transform;
            enemytObject.SetActive(false);
            enemys.Add(enemytObject);
        }
    }
    public GameObject GetBullet(Vector3 pos)
    {
        GameObject reqBullet = null;

        for (int i= 0;i<bullets.Count; i++)
        {
            if(bullets[i].activeSelf==false)
            {
                reqBullet = bullets[i];
                break;
            }
        }
        //초기설정 탄환수보다 부족할경우 오브젝트 추가생성
        if (reqBullet == null)
        {
            GameObject newBullet = Instantiate(bullet) as GameObject;
            newBullet.transform.parent = transform;
            bullets.Add(newBullet);
            reqBullet = newBullet;
        }

        reqBullet.SetActive(true);
        reqBullet.transform.position = pos;


        return reqBullet;
    }

    public GameObject GetEnemy(Vector3 pos)
    {
        GameObject reqEnemy = null;

        for (int i = 0; i < enemys.Count; i++)
        {
            if (enemys[i].activeSelf == false)
            {
                reqEnemy = enemys[i];
                break;
            }
        }
        //초기설정 탄환수보다 부족할경우 오브젝트 추가생성
        if (reqEnemy == null)
        {
            GameObject newEnemy = Instantiate(enemy) as GameObject;
            newEnemy.transform.parent = transform;
            enemys.Add(newEnemy);
            reqEnemy = newEnemy;
        }

        reqEnemy.SetActive(true);
        reqEnemy.transform.position = pos;


        return reqEnemy;
    }


    public void Clearbullets()
    {
        for(int i = 0; i<bullets.Count; i++)
        {
            bullets[i].SetActive(false);
        }
    }

    public void Clearenemys()
    {
        for (int i = 0; i < enemys.Count; i++)
        {
            enemys[i].SetActive(false);
        }
    }
}
