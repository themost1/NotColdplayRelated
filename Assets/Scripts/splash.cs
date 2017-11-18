using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class splash : MonoBehaviour {

    public AudioSource mainmusic;
    public AudioSource winmusic;
    public bool musicplaying;

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(mainmusic);
        DontDestroyOnLoad(winmusic);
        mainmusic.Play();

        SceneManager.LoadScene(1);
	}
	
	// Update is called once per frame
	void Update () {
        if(mainmusic.isPlaying == true)
        {
            musicplaying = true;
        }
	}
}
