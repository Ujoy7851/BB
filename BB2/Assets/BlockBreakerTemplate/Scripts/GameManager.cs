using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
    public static GameManager manager;
	private int score;              //The player's current score
                                    //	public int ballSpeedIncrement;	//The amount of speed the ball will increase by everytime it hits a brick
    public float width;
    public float height;
    public float startWidth;
    public float startHeight;
    public Ball ball;
    public Shooter shooter;    
	
    //Prefabs
	public GameObject brickPrefab;	//The prefab of the Brick game object which will be spawned

    public GameObject[] bricks;

	void Start ()
	{
        bricks = new GameObject[5];
        manager = this;
		StartGame(); //Starts the game by setting values and spawning bricks
	}

	//Called when the game starts
	public void StartGame ()
	{
		score = 0;
        ball.gameObject.SetActive(true);
        shooter.gameObject.SetActive(true);
		CreateBrickArray();
	}
    public void IncrementScore(int score)
    {
        this.score += score;
        GameUI.gameUI.ScoreUpdate(score);
    }
    public void NextLine()
    {
        shooter.BallReturns();
        CreateBrickArray();

        foreach (Bouncer bouncer in FindObjectsOfType<Bouncer>())
        {
            bouncer.shooted = false;
        }
    }

    //Spawns the bricks and sets their colours
    public void CreateBrickArray ()
    {
        foreach (Brick brick in FindObjectsOfType<Brick>())
        {
           brick.transform.position -= new Vector3(0, height, 0);
        }
        for (int i = 0; i<5; i++)
        {
            if(Random.Range(0, 2) == 1)
            {
                bricks[i] = Instantiate(brickPrefab, new Vector3 (startWidth + width/2 + width * i, startHeight, 0),  Quaternion.identity);
                bricks[i].GetComponent<Brick>().lives = Random.Range(1, 4);
                bricks[i].GetComponent<Brick>().SetColor();
            }
        }
	}
    public void GameOver()
    {
        SetHighScore();
        ball.gameObject.SetActive(false);
        shooter.gameObject.SetActive(false);
        GameUI.gameUI.SetGameOver(score);
    }
    void SetHighScore()
    {
        if(score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            GameUI.gameUI.UpdateHighScore();
        }
    }
}
