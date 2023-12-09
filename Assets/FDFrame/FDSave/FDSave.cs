using UnityEngine;
using System.Collections;

public class FDSave : MonoBehaviour {
	public static FDSave thisC;
	private string saveNameStr;
	public LitJson.JsonData gameData;
	private void Awake(){
		thisC = this;
		saveNameStr = "gameData";
		gameData = new LitJson.JsonData ();
		DontDestroyOnLoad (this.gameObject);
	}
	private void Start(){
		StartCoroutine (EndFrameIEnumerator());
	}
	private IEnumerator EndFrameIEnumerator(){
		yield return new WaitForEndOfFrame ();
		CoverGame ();
	}
	public void SaveGame(){
		PlayerPrefs.SetString (saveNameStr,gameData.ToJson());
	}
	public void CoverGame(){
		string tempGameDataStr = PlayerPrefs.GetString (saveNameStr);
		if(tempGameDataStr!=""){
			LitJson.JsonData tempGameData=tempGameDataStr.ToJsonData();
			gameData=gameData.OldCoverNew(tempGameData);
		}
	}
}
