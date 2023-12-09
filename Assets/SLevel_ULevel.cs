using UnityEngine;
using System.Collections;

public class SLevel_ULevel : MonoBehaviour {
	public static SLevel_ULevel thisC;
	public bool isGameOver;
	private void Awake(){
		thisC=this;
		isGameOver = false;
	}
	private void Start(){
		Load ();
		Screen.lockCursor = true;
	}
	private void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.LoadLevel("SMainMenu");
		}
	}
	public void Load(){
		StartCoroutine (RefreshIEnumerator());
	}
	private IEnumerator RefreshIEnumerator(){
		yield return new WaitForEndOfFrame ();
		this.transform.Find ("DiamondText").GetComponent<Animator> ().SetTrigger ("Add");
		this.transform.Find ("DiamondText").GetComponent<UnityEngine.UI.Text> ().text = DiamondSave.thisC.transform.childCount.ToString();
	}
}
