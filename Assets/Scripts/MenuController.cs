using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public Button PlayNowButton;
    public Button MusicButton;
    public AudioSource MusicSource;
    public AudioSource ButtonAudioSource;
    public AudioClip ButtonAudioClip;
	public Button ShopButton;

	void Start()
    {
	    if (PlayerPrefs.GetInt("music") == 0)
	    {
		    MusicSource.mute = true;
	    }
	    
	    PlayNowButton.onClick.AddListener(playNow);
		MusicButton.onClick.AddListener(musicToggle);
		ShopButton.onClick.AddListener(shop);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void playNow()
    {
	    SceneManager.LoadScene("Easy");
    }

    void musicToggle()
    {
	    ButtonAudioSource.PlayOneShot(ButtonAudioClip);
	    if (PlayerPrefs.GetInt("music") == 1)
	    {
		    PlayerPrefs.SetInt("music", 0);
		    PlayerPrefs.Save();
		    MusicSource.mute = true;

	    }
	    else
	    {
		    PlayerPrefs.SetInt("music", 1);
		    MusicSource.mute = false;
	    }
    }

    void shop()
    {
	    SceneManager.LoadScene("Shop");
    }
}
