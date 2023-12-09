using UnityEngine;
using System.Collections;

public class FDEventSystem : MonoBehaviour {
	private void Awake(){
		DontDestroyOnLoad (this.gameObject);
	}
	private void Start(){
		StartCoroutine(ResetEventSystemIEnumerator());
	}
	private IEnumerator ResetEventSystemIEnumerator(){
		while(true){
			yield return new WaitForEndOfFrame();
			if(!Input.GetMouseButton(0)){
				UnityEngine.EventSystems.EventSystem tempEventSystem=UnityEngine.EventSystems.EventSystem.current;
				if(tempEventSystem!=null){
					if(tempEventSystem.currentSelectedGameObject!=null
					   &&tempEventSystem.currentSelectedGameObject.GetComponent<UnityEngine.UI.InputField>()==null){
						tempEventSystem.SetSelectedGameObject(null);
					}
				}
			}
		}
	}
}
