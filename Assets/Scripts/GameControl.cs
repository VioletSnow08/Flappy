using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
	public static GameControl instance;
    public GameObject gameOverText;
    public Text ScoreText;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;
    private int score = 0;
	private int HighestScore = 0;
	public Text HighestScoreText;
	void Awake() // Before Start
    {
	    if (instance == null)
	    {
		    instance = this;
	    } else if (instance != this)
	    {
		    Destroy(gameObject);
	    }

	    if (PlayerPrefs.HasKey("HighScore"))
	    {
		    HighestScore = PlayerPrefs.GetInt("HighScore");
		    HighestScoreText.text = "Highest Score: " + HighestScore;
	    }
	    else
	    {
			PlayerPrefs.SetInt("HighScore", score);
	    }
    }

    // Update is called once per frame
    void Update()
    {
	    if (gameOver == true && Input.GetMouseButtonDown(0))
	    {
		    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

	    }
    }

    public void BirdScored()
    {
	    if (gameOver)
	    {
		    PlayerPrefs.Save();
		    return;
	    }
	    else
	    {
		    score++;
		    ScoreText.text = "Score: " + score.ToString();
		    if (score > HighestScore)
		    {
			    HighestScore = score;
				PlayerPrefs.SetInt("HighScore", HighestScore);
				Debug.Log(HighestScore);
			    HighestScoreText.text = "Highest Score: " + HighestScore.ToString();
		    }
	    }
    }
    public void BirdDied()
    {
	    gameOverText.SetActive(true);
	    gameOver = true;
    }
}
