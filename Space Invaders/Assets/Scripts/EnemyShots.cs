using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShots : MonoBehaviour
{
    int randTimeShot, sectionTime=0;
    public GameObject bullet;

    void Update()
    {
        sectionTime++;
        if (sectionTime % 200 == 0 && Time.timeScale != 0)
            EnemyShoot();
    }

    private void EnemyShoot()
    {//рандом до 1 что бы враги стреяли вразнобой
        randTimeShot = Random.Range(0, 10);
        if (randTimeShot == 1)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
}
