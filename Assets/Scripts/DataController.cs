using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using SimpleJSON;

public class DataController : MonoBehaviour {

	public GameObject picture;
	public GameObject[] UI;
	public Text buttonOneText;
	public Text buttonTwoText;
	public Text speakerText;
	public Text winText;
	public TextAsset asset;
	public bool isHot;
	public string nextScene;
	private GameData data;
	private GameData currentNode;
    public AudioSource victorysong;
    public bool winplaying;

	private void SetCurrentNode(GameData newNode)
	{
		currentNode = newNode;
		if (currentNode.isLoss || currentNode.isVictory) {
			if (currentNode.text != null) {
				speakerText.text = currentNode.text;
			}
			EndGame (currentNode.isVictory);
		} else {
			buttonOneText.text = currentNode.opt1Data.value;
			buttonTwoText.text = currentNode.opt2Data.value;
			speakerText.text = currentNode.text;
		}
	}

	public void EndGame(bool inWon)
	{
		picture.SetActive (true);
		foreach (GameObject g in UI)
		{
			g.SetActive (false);
		}
		if (inWon) {
			if (isHot) {
				winText.text = "You just had sex with one of the hottest people ever, congrats!";
			}
			else {
				winText.text = "You dodged a bullet there. Good job avoiding that loser.";
			}
            victorysong.Play();
		}
		else {
			if (isHot) {
				winText.text = "You missed out on a shot with one of the hottest people ever. You will have eternal regret.";
			}
			else {
				winText.text = "You just had sex with a loser. Your SS goes down :(";
			}
		}
		winText.gameObject.SetActive (true);
        StartCoroutine("EndScene");
	}

	public void ScrewYou()
	{
		speakerText.gameObject.SetActive (false);
		EndGame (!isHot);
	}

	public void ClickButtonOne()
	{
		SetCurrentNode (currentNode.opt1Data);
	}

	public void ClickButtonTwo()
	{
		SetCurrentNode (currentNode.opt2Data);
	}

	public void Start()
	{
		string text = asset.text;
		JSONNode node = JSON.Parse (text);
		data = LoadGameData (node);
		SetCurrentNode (data);
		//SceneManager.LoadScene("MainMenu");
	}

	private GameData LoadGameData(JSONNode node)
	{
		GameData data = new GameData ();
		if (node["Text"] != null)
			data.text = node ["Text"].Value;
		if (node ["Lose"] != null)
			data.isLoss = node ["Lose"].AsBool;
		if (node ["Win"] != null)
			data.isVictory = node ["Win"].AsBool;
		if (node ["Value"] != null)
			data.value = node ["Value"].Value;
		if (node ["choice1"] != null)
			data.opt1Data = LoadGameData (node ["choice1"]);
		if (node ["choice2"] != null)
			data.opt2Data = LoadGameData (node ["choice2"]);
		return data;
	}

	private class GameData
	{
		public string value = "";
		public string text = "";
		public bool isLoss = false;
		public bool isVictory = false;
		public GameData opt1Data = null;
		public GameData opt2Data = null;
	}

     IEnumerator EndScene()
    {
        yield return new WaitForSeconds(5);
        nextscene.setNextScene(nextScene);
        SceneManager.LoadScene(9);
    }

    private void Update()
    {
        if (victorysong.isPlaying == true)
        {
            winplaying = true;
        }
    }
}

