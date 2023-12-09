using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class FDRefresh : MonoBehaviour {
	public static FDRefresh thisC;
	private Dictionary<string,List<UnityAction>> dicKeyAndListUnityAction;
	public List<UnityAction> listUnityAction;
	private void Awake(){
		thisC = this;
		dicKeyAndListUnityAction = new Dictionary<string, List<UnityAction>> ();
		listUnityAction = new List<UnityAction> ();
		DontDestroyOnLoad (this.gameObject);//切换场景不会被销毁
	}
	private void Start(){
		StartCoroutine (EndFrameRefreshIEnumerator());
	}
	public void Add(string theKeyStr,UnityAction theUnityAction){//添加到对应键值对，和委托列表
		if(!dicKeyAndListUnityAction.ContainsKey(theKeyStr)){
			dicKeyAndListUnityAction.Add(theKeyStr,new List<UnityAction>());
			dicKeyAndListUnityAction[theKeyStr].Add(theUnityAction);
		}
		else{
			if(!dicKeyAndListUnityAction[theKeyStr].Contains(theUnityAction)){
				dicKeyAndListUnityAction[theKeyStr].Add(theUnityAction);
			}
		}
	}
	public void Remove(string theKeyStr,UnityAction theUnityAction){//移除对应键值对，和委托列表
		if(dicKeyAndListUnityAction.ContainsKey(theKeyStr)){
			if(dicKeyAndListUnityAction[theKeyStr].Contains(theUnityAction)){
				dicKeyAndListUnityAction[theKeyStr].Remove(theUnityAction);
				if(dicKeyAndListUnityAction[theKeyStr].Count<=0){
					dicKeyAndListUnityAction.Remove(theKeyStr);
				}
			}
		}
	}
	public void Refresh(string theKeyStr){//通知准备刷新
		if(dicKeyAndListUnityAction.ContainsKey(theKeyStr)){
			foreach(UnityAction loopUnitAction in dicKeyAndListUnityAction[theKeyStr]){
				if(!listUnityAction.Contains(loopUnitAction)){//添加到临时列表
					listUnityAction.Add(loopUnitAction);
				}
			}
		}
	}
	private IEnumerator EndFrameRefreshIEnumerator(){//帧尾统一刷新，避免频繁刷新界面
		while(true){
			yield return new WaitForEndOfFrame();
			foreach(UnityAction loopUnitAction in listUnityAction){
				loopUnitAction.Invoke();
			}
			listUnityAction.Clear();//清空临时列表
		}
	}
	/*正确的使用方法(数据部分)
	public int roundInt{
		get{return roundIntOwn;}
		private set{roundIntOwn=value;FDRefresh.thisC.Refresh("SMap.roundInt");}
	}private int roundIntOwn;
	*/
	/*正确的使用方法(界面部分)
	public Dictionary<string,UnityEngine.Events.UnityAction> dicRefresh=new Dictionary<string, UnityEngine.Events.UnityAction>();
	private void Start(){
		//逐个储存刷新委托
		dicRefresh.Add ("SMap.roundInt",delegate(){
			this.transform.FindChild("RoundText").GetComponent<UnityEngine.UI.Text>().text=SMap.thisC.roundInt.ToString();
		});
		//统一添加到FDRefresh
		foreach(string loopKeyStr in dicRefresh.Keys){
			FDRefresh.thisC.Add(loopKeyStr,dicRefresh[loopKeyStr]);
		}
	}
	private void OnDestroy(){
		//统一从FDRefresh移除
		foreach(string loopKeyStr in dicRefresh.Keys){
			FDRefresh.thisC.Remove(loopKeyStr,dicRefresh[loopKeyStr]);
		}
	}*/
}
