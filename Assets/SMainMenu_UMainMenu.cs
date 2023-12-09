using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SMainMenu_UMainMenu : MonoBehaviour {
	public AudioClip mainMenuAudioClip;
	private void Start(){
		Camera.main.transform.PlayMusic2D (mainMenuAudioClip,true);
		Screen.lockCursor = false;
	}
	private void LateUpdate(){
		GameObject tempClick = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
		if(tempClick!=null&&tempClick.transform.IsChildOf(this.transform)){
			if(Input.GetMouseButtonUp(0)){
				if(tempClick.name=="StartButton1"){
					this.transform.Find("Image").gameObject.SetActive(true);
					FDDelay.Create(0.5f,delegate(){
						SceneManager.LoadScene("SLevel");
					});
				}
				else if(tempClick.name=="StartButton2"){
					this.transform.Find("Image").gameObject.SetActive(true);
					FDDelay.Create(0.5f,delegate(){
						SceneManager.LoadScene("SLevel 1");
					});
				}
				else if(tempClick.name=="QuitButton"){
					this.transform.Find("Image").gameObject.SetActive(true);
					FDDelay.Create(0.5f,delegate(){
						Application.Quit();
					});
				}
			}
		}
	}
}
