using UnityEngine;
using System.Collections;

public class Destination : MonoBehaviour {
	//通关目的地
	public static Destination thisC;
	private void Awake(){
		thisC = this;
	}
}
