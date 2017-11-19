using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class splash : MonoBehaviour {

    public AudioSource mainmusic;
    public AudioSource winmusic;
    public DataController data;

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(mainmusic);
        DontDestroyOnLoad(winmusic);
        mainmusic.Play();

        SceneManager.LoadScene("MainMenu");
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name == "gameover")
        {
            mainmusic.Stop();
        }
        else if(SceneManager.GetActiveScene().name == "MainMenu" && !mainmusic.isPlaying)
        {
            mainmusic.Play();
        }
        GameObject controller = GameObject.FindWithTag("GameController");
        if (controller != null) {
            data = GameObject.FindWithTag("GameController").GetComponent<DataController>();
            if (data.winplaying == true)
            {
                mainmusic.Stop();
            }
            else if (!mainmusic.isPlaying)
            {
                mainmusic.Play();
            }
        }
	}
}
