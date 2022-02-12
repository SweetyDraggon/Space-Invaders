using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] KeyCode LeftMoveKey;
    [SerializeField] KeyCode RightMoveKey;
    public GameObject[] Health;
    public GameObject  bullet;
    public int HealthCount = 2;
    float speed = 3;
    int SootCounter;
    bool MovePlayer = false;
    int SideOfMove = 0; // если 1 - движение влево, если 2 - движение вправо, если 0 - движения нет

    private void Start()
    {
        Time.timeScale = 1f;
    }
    void Update()
    {//время перезарядки стрельбы игрока
        SootCounter++;
        if (SootCounter % 100 == 0 && Time.timeScale != 0)
            SootBullet();
    }

    private void SootBullet()
    {//спаве пули
        Instantiate(bullet, transform.position, Quaternion.identity);
    }

    void FixedUpdate()
    {//управление игроком
        if (MovePlayer==true && SideOfMove ==1)
        {
            this.transform.position += Vector3.left * this.speed * Time.deltaTime;
        }
        if (MovePlayer == true && SideOfMove == 2)
        {
            this.transform.position += Vector3.right * this.speed * Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {//при пересечении с вржеской пулей отнимает хп
        if (collision.gameObject.name == "EnemyBullet(Clone)")
        {
            Destroy(Health[HealthCount]);
            Destroy(collision.gameObject);
            HealthCount-=1;   
        }
    }
    public void Ledtbutton()
    {//пока кнопка зажата игрок движется
        MovePlayer = true;
        SideOfMove = 1;
    }
    public void Rightbutton()
    {
        MovePlayer = true;
        SideOfMove = 2;
    }
    public void Upbutton() //не зажата ни одна кнопка
    {
        SideOfMove = 0;
        MovePlayer = false;
    }
}
