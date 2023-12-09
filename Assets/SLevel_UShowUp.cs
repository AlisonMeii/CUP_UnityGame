﻿using UnityEngine;
using System.Collections;

public class SLevel_UShowUp : MonoBehaviour {
	public static SLevel_UShowUp thisC;

	private void Awake(){
		thisC = this;
	}
	private void Start(){
		this.gameObject.SetActive (false);
	}
	public void Open(){
		this.gameObject.SetActive (true);
		StartCoroutine (EnterIEnumerator());

	}
	private IEnumerator EnterIEnumerator(){
		this.transform.GetComponent<Animator>().SetTrigger("Enter");
		yield return new WaitForSeconds(4f);
		this.gameObject.SetActive (false);

	}
}
