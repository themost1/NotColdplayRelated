using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour {

	public string nextScene;
	public float delay;
	
	// Update is called once per frame
	void Update () {
        StartCoroutine("PostPirateScene");
	}

    IEnumerator PostPirateScene()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nextScene);
    }
}
