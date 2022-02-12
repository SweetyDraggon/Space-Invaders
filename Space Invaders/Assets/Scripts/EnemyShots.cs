using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShots : MonoBehaviour
{
    int RandTimeShot, SectionTime=0;
    public GameObject Bullet;

    void Update()
    {
        SectionTime++;
        if (SectionTime % 200 == 0 && Time.timeScale != 0)
            EnemyShoot();
    }

    private void EnemyShoot()
    {//рандом до 1 что бы враги стреяли вразнобой
        RandTimeShot = Random.Range(0, 10);
        if (RandTimeShot == 1)
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
        }
    }
}
