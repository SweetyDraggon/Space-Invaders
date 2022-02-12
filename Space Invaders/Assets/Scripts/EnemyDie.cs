using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    public ScoreCounter Score;
    private void Start()
    {//поиск нужного скрипта
        GameObject go = GameObject.FindGameObjectWithTag("Canvas");
        Score = go.GetComponent<ScoreCounter>();
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Bullet 1(Clone)" && this.gameObject.tag == "FirstAlien")
        {
            Score.FirstAddToScore();
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.name == "Bullet 1(Clone)" && this.gameObject.tag == "SecondAlien")
        {
            Score.SecondAddToScore();
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
