using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour 
{
	public Text scoreText;			//The Text component that will display the score
    public static GameUI gameUI;
	public GameObject gameOverScreen;	//The game over screen game object
	public Text gameOverScoreText;	//The Text component that will display the score when the player lost
    public Text highScoreText;

    private void Start()
    {
        gameUI = this;
        highScoreText.text = "<b>High Score</b>: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void ScoreUpdate(int score)
    {
        scoreText.text = "<b>SCORE</b>: " + score.ToString();
    }

    public void UpdateHighScore()
    {
        highScoreText.text = "<b>High Score</b>: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
	//Called when the game is over
	public void SetGameOver (int score)
	{
		gameOverScreen.SetActive(true);
		gameOverScoreText.text = "<b>YOU ACHIEVED A SCORE OF</b>\n" + score;	//Sets the gameOverScoreText to display the words 'YOU ACHIEVED A SCORE OF' in bold and then the score value on a new line which is located in the GameManager class
	}

	//Called when the 'TRY AGAIN' button is pressed
	public void TryAgainButton ()
	{
        gameOverScreen.SetActive(false);
        GameManager.manager.StartGame();
	}

	//Called when the 'MENU' button is pressed
	public void MenuButton ()
	{
        SceneManager.LoadScene(0);
	}
}
