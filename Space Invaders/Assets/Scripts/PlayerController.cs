using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] KeyCode leftMoveKey;
    [SerializeField] KeyCode rightMoveKey;
    public GameObject[] Health;
    public GameObject  bullet;
    public int healthCount = 2;
    float speed = 3;
    int sootCounter;
    enum sideOfMove
    {
        LeftSide,
        RightSide,
        NotMove
    }
    sideOfMove side =sideOfMove.NotMove;

    private void Start()
    {
        Time.timeScale = 1f;
    }
    void Update()
    {//время перезарядки стрельбы игрока
        sootCounter++;
        if (sootCounter % 100 == 0 && Time.timeScale != 0)
            SootBullet();
    }

    private void SootBullet()
    {//спаве пули
        Instantiate(bullet, transform.position, Quaternion.identity);
    }

    void FixedUpdate()
    {//управление игроком
        if (side ==sideOfMove.LeftSide)
        {
            this.transform.position += Vector3.left * this.speed * Time.deltaTime;
        }
        if (side == sideOfMove.RightSide)
        {
            this.transform.position += Vector3.right * this.speed * Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {//при пересечении с вржеской пулей отнимает хп
        if (collision.gameObject.name == "EnemyBullet(Clone)")
        {
            Destroy(Health[healthCount]);
            Destroy(collision.gameObject);
            healthCount-=1;   
        }
    }
    public void Ledtbutton()
    {//пока кнопка зажата игрок движется
        side = sideOfMove.LeftSide;
    }
    public void Rightbutton()
    {
        side = sideOfMove.RightSide;
    }
    public void Upbutton() //не зажата ни одна кнопка
    {
        side = sideOfMove.NotMove;
    }
}
