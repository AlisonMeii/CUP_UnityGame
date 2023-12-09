using UnityEngine;
using System.Collections;

public class SLevel_UGameOver : MonoBehaviour {
	public static SLevel_UGameOver thisC;
	public bool isOpen;
	public UnityEngine.UI.Image image;
	private void Awake(){
		thisC = this;
		isOpen = false;
		image = this.transform.Find ("Image").GetComponent<UnityEngine.UI.Image> ();
	}
	private void Update(){
		if(!isOpen)return;
		if(image.color.a>=0.9f){
			Application.LoadLevel("SMainMenu");
			return;
		}
		Color tempColor = image.color;
		tempColor.a += 0.006f;
		image.color = tempColor;
	}
	public void Open(){
		isOpen = true;
	}
}
