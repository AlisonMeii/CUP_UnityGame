using UnityEngine;
using System.Collections;

public partial class Enemy2 {
	public string aniNameStr{ get; set;}
	public Transform modelTra{ get; set;}
	public Animator modelAni{ get; set;}
	public void AwakeAni(){
		aniNameStr="Idle";
		modelTra = this.transform.Find ("Model");
		modelAni=modelTra.GetChild(0).GetComponent<Animator>();
	}
	public void EnterAni(string theAniNameStr){
		modelAni.ResetTrigger (aniNameStr);
		modelAni.Update (0);
		modelAni.SetTrigger (theAniNameStr);
		aniNameStr = theAniNameStr;
	}
	public void UpdateAni(){
		
	}
}
