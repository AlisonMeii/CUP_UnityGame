using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour,IPointerEnterHandler,IPointerDownHandler,IPointerUpHandler {
	public AudioClip enterSound=null;
	public AudioClip downSound=null;
	public AudioClip upSound=null;
	public void OnPointerEnter (PointerEventData eventData){
		PlaySound2D(enterSound);
	}
	public void OnPointerDown (PointerEventData eventData){
		PlaySound2D(downSound);
	}
	public void OnPointerUp (PointerEventData eventData){
		PlaySound2D(upSound);
	}
	private void PlaySound2D(AudioClip theAudioClip){
		Camera.main.transform.PlaySound2D(theAudioClip);
	}
}
