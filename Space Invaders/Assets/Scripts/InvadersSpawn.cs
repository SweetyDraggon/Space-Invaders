using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvadersSpawn : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameObject shootingEnemy, secondShootingEnemy;
    public Vector3 initialPosition { get; private set; }
    public Vector3 direction = Vector2.right;
    public float speed = 0.01f;
    int bonuseRows = 10;
    int rows = 4, columns = 6, shootingEnemyCounter=0;
    GameObject invader;

    private void Awake()
    {
        initialPosition = transform.position;

        for (int i = 0; i < rows; i++)
        {
            float width = 0.5f * (columns - 1);

            float height = 0.5f * (rows - 2);

            Vector2 centerOffset = new Vector2(-width * 0.5f, -height * 0.5f);
            Vector3 rowPosition = new Vector3(centerOffset.x, (0.5f * i) + centerOffset.y, 0f);

            for (int j = 0; j < columns; j++)
            {
                invader = Instantiate(prefabs[i], transform);
                Vector3 position = rowPosition;
                position.x += 0.5f * j;
                invader.transform.localPosition = position;
            }
        }
    }

    private void Update()
    {
        this.transform.position += direction * this.speed * Time.deltaTime; 
        
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform invader in transform)
        {
            if (!invader.gameObject.activeInHierarchy)//пропуск если враг убит
            {
                continue;
            }

            //проверка стороны экрана которой коснулись враги
            if (direction == Vector3.right && invader.position.x >= (rightEdge.x - 0.1f))
            {
                AdvanceRow();
                break;
            }
            else if (direction == Vector3.left && invader.position.x <= (leftEdge.x + 0.1f))
            {
                AdvanceRow();
                break;
            }
        }
    }

    private void AdvanceRow()
    { 
        direction = new Vector3(-direction.x, 0f, 0f);
        //перенос всей врагов на строчку вниз по оси у
        Vector3 position = transform.position;
        position.y -= 0.5f;
        transform.position = position;

        BonuseRow();
    }

    void BonuseRow()
    {//спавн дополнительных рядов пртивников
        initialPosition = transform.position;

        for (int i = 0; i < 1; i++)
        {
            float width = 0.5f * (columns - 1);

            float height = 0.5f * (rows - bonuseRows);

            Vector2 centerOffset = new Vector2(-width * 0.5f, -height * 0.5f);
            Vector3 rowPosition = new Vector3(centerOffset.x, (0.5f * i) + centerOffset.y, 0f);

            for (int j = 0; j < 6; j++)
            {
                invader = Instantiate(shootingEnemy, transform);
                Vector3 position = rowPosition;
                position.x += 0.5f * j;

                invader.transform.localPosition = position;
            }
            bonuseRows+=2;
            shootingEnemyCounter++;//подсчет количесва рядов до смены типа врага
            if (shootingEnemyCounter == 4) {
                shootingEnemy = secondShootingEnemy;
            }
        }
    }
}
