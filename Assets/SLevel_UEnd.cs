using System;
using UnityEngine;
using System.Collections;

public class SLevel_UEnd : MonoBehaviour {
	public static SLevel_UEnd thisC;
	private float waitTime;

	public Boolean isWin = false;
	private void Awake(){
		thisC = this;
		waitTime = 6.2f;
	}
	private void Start(){
		this.gameObject.SetActive (false);
	}
	private void Update(){
		if((int)waitTime!=(int)(waitTime-0.02f)){
			this.transform.Find("Text").GetComponent<UnityEngine.UI.Text>().text=((int)waitTime).ToString();
		}
		waitTime -= 0.02f;
		if(waitTime<=0f){
			Time.timeScale=1f;
			Application.LoadLevel("SMainMenu");
		}
	}
	public void Open(){
		isWin = true;
		Time.timeScale = 0f;
		this.gameObject.SetActive (true);
	}
}
