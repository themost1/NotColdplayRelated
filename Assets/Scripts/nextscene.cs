using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextscene : MonoBehaviour {

	public static string nextScene;

	public static void setNextScene(string inScene)
	{
		nextScene = inScene;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine("PostPirateScene");
	}

    IEnumerator PostPirateScene()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(nextScene);
    }
}
