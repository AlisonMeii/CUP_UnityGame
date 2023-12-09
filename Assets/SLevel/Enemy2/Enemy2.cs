using UnityEngine;
using System.Collections;

public partial class Enemy2 : MonoBehaviour {
	public AudioClip KnightAttackAudioClip;
	//public AudioClip monkeyRunAudioClip;
	private void Awake(){
		AwakeAni ();
		AwakeAct ();
	}
	private void Start(){
		//this.transform.PlayMusic3D (monkeyRunAudioClip,true);
	}
	private void Update(){
		UpdateAni ();
		UpdateAct ();
	}
}
