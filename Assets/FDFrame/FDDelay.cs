using UnityEngine;
using System.Collections;
public class FDDelay:MonoBehaviour{
	public static FDDelay Create(float theWaitTime,DelayDelegate theDelayEnvent,bool theIsDontDestroyOnLoad=false){
		FDDelay returnDelayC=new GameObject("FDDelay").AddComponent<FDDelay>();
		returnDelayC.DelayEnvent+=theDelayEnvent;
		returnDelayC.obj=null;
		returnDelayC.startWaitTime=Time.time;
		returnDelayC.targetWaitTime=Time.time+theWaitTime;
		returnDelayC.isEver=(theWaitTime==-1f);
		if(theIsDontDestroyOnLoad){
			DontDestroyOnLoad(returnDelayC.gameObject);
		}
		return returnDelayC;
	}
	public static FDDelay Create(float theWaitTime,object theObj,DelayObjDelegate theDelayObjEnvent,bool theIsDontDestroyOnLoad=false){
		FDDelay returnDelayC=new GameObject("FDDelay").AddComponent<FDDelay>();
		returnDelayC.DelayObjEnvent+=theDelayObjEnvent;
		returnDelayC.obj=theObj;
		returnDelayC.startWaitTime=Time.time;
		returnDelayC.targetWaitTime=Time.time+theWaitTime;
		returnDelayC.isEver=(theWaitTime==-1f);
		if(theIsDontDestroyOnLoad){
			DontDestroyOnLoad(returnDelayC.gameObject);
		}
		return returnDelayC;
	}
	public delegate void DelayDelegate();
	public event DelayDelegate DelayEnvent;
	public delegate void DelayObjDelegate(object theObj);
	public event DelayObjDelegate DelayObjEnvent;
	public object obj;
	public float startWaitTime;
	public float targetWaitTime;
	public bool isEver;
	private void Awake(){
		DelayEnvent+=delegate(){};
		DelayObjEnvent+=delegate(object theObj){};
	}
	private void Update(){
		if(isEver)return;
		if(Time.time>=targetWaitTime){
			Stop();
		}
	}
	public void Stop(){
		DelayEnvent();
		DelayObjEnvent(obj);
		Destroy(this.gameObject);
	}
}
