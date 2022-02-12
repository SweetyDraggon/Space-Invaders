using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooletControl : MonoBehaviour
{
    public Vector3 direction =new Vector3(0,2,0);
    float speed = 5f;

    void Update()
    {//движение пули игрока
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }
}
