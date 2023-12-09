using UnityEngine;
using System.Collections;

public class DiamondSave : MonoBehaviour {
	public static DiamondSave thisC;
	private void Awake(){
		thisC = this;
	}
}
