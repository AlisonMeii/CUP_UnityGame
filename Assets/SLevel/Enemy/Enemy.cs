using UnityEngine;
using System.Collections;

public partial class Enemy : MonoBehaviour {
	public AudioClip monkeyAttackAudioClip;

	private void Awake(){
		AwakeAni ();
		AwakeAct ();
	}
	private void Start(){
	}
	private void Update(){
		UpdateAni ();
		UpdateAct ();
	}
}
