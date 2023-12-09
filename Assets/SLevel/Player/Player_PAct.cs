using UnityEngine;
using System.Collections;

public partial class Player {
	public string actNameStr{ get; set;}
	public Transform cameraTra{ get; set;}
	public void AwakeAct(){
		actNameStr="Idle";
		cameraTra = this.transform.Find ("Camera");
		cameraTra.SetParent (modelAni.transform);
	}
	public void EnterAct(string theActNameStr){
		actNameStr = theActNameStr;
		if(actNameStr=="Idle"){
			EnterAni("Idle");
		}
		else if(actNameStr=="Run"){
			EnterAni("Run");
		}
		else if(actNameStr=="Death"){
			EnterAni("Idle");
		}
	}
	//状态的判断与改变
	public void UpdateAct(){
		if(actNameStr=="Idle"){
			Vector3 tempMoveDir=Input.GetAxis("Vertical")*this.transform.forward+Input.GetAxis("Horizontal")*this.transform.right;
			if(tempMoveDir!=Vector3.zero){
				EnterAct("Run");
			}
		}
		else if(actNameStr=="Run"){
			Vector3 tempMoveDir=Input.GetAxis("Vertical")*this.transform.forward+Input.GetAxis("Horizontal")*this.transform.right;
			if(tempMoveDir!=Vector3.zero){
				this.transform.position+=tempMoveDir*Time.deltaTime*6f;
			}
			else{
				EnterAct("Idle");
			}
		}
		else if(actNameStr=="Death"){
			SLevel_UGetCaught.thisC.Open();
			goto ifEnd;
		}
		this.transform.Rotate(Vector3.up*Input.GetAxis("Mouse X")*1.2f);
		ifEnd:;
	}
}
