using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
    public GameManager manager;      //The GameManager

    public Sprite[] spriteList;
    public int lives = 3;
    int score;

    void Start()
    {
        score = lives;
    }
    //Called whenever a trigger has entered this objects BoxCollider2D. The value 'col' is the Collider2D object that has interacted with this one
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {                                               //Is the tag of the colliding object 'Ball'
                                          //Increases the score value in the GameManager class by one
            lives--;
            SetColor();
            if (lives == 0)
            {
                GameManager.manager.IncrementScore(score);
                Destroy(gameObject);
            }

        }

    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Floor")
        {
            GameManager.manager.GameOver();
        }
}
    public void SetColor()
    {
        switch (lives)
        {
            case 1:
                gameObject.GetComponent<SpriteRenderer>().sprite = spriteList[0];
                break;
            case 2:
                gameObject.GetComponent<SpriteRenderer>().sprite = spriteList[1];
                break;
            case 3:
                gameObject.GetComponent<SpriteRenderer>().sprite = spriteList[2];
                break;
        }
    }
}