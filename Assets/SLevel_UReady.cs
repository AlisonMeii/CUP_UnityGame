using UnityEngine;
using System.Collections;

public class SLevel_UReady : MonoBehaviour {
	private float waitTime;
	public AudioClip gameStartAudioClip;
	public AudioClip remindVocAudioClip;
	private void Awake(){
		waitTime = 0f;
	}
	private void Start(){
		Time.timeScale = 0f;
		Camera.main.transform.PlaySound2D(gameStartAudioClip);
		Camera.main.transform.PlaySound2D(remindVocAudioClip);
	}
	private void Update(){
		if((int)waitTime!=(int)(waitTime-0.02f)){
			this.transform.Find("Text").GetComponent<UnityEngine.UI.Text>().text=((int)waitTime).ToString();
		}
		waitTime -= 0.02f;
		if(waitTime<=0f){
			Time.timeScale=1f;
			Destroy(this.gameObject);
		}
	}
}
