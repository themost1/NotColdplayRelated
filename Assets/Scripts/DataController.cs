using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using SimpleJSON;

public class DataController : MonoBehaviour {

	public TextAsset asset;
	private GameData data;

	void Start()
	{
		Debug.Log (asset);
		string text = asset.text;
		JSONNode node = JSON.Parse (text);
		data = LoadGameData (node);
		Debug.Log (data.opt1Data.opt2Data.text);

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
}

