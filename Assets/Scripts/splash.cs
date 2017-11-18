using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class splash : MonoBehaviour {

    public AudioSource mainmusic;
    public AudioSource winmusic;


    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(mainmusic);
        DontDestroyOnLoad(winmusic);
        mainmusic.Play();

        SceneManager.LoadScene(1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
