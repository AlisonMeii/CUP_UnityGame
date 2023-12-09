using UnityEngine;
using System.Collections;

public class GGlobal : MonoBehaviour {
	public static GGlobal thisC;
	private void Awake(){
		thisC = this;
		DontDestroyOnLoad (this.gameObject);
	}
	private void Start(){
		FDSave.thisC.gameData["musicValue"]="1";
		FDSave.thisC.gameData["soundValue"]="1";
	}
}
