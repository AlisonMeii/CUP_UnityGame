using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public static class WallConfigEditor {
	private static Dictionary<string,string> dicPosAndWallName;
	[MenuItem("WallConfig/RecoverWall")]
	private static void RecoverWall(){
		GameObject tempGobj = Selection.activeGameObject;
		if(tempGobj!=null&&tempGobj.name=="WallConfig"&&tempGobj.isStatic){
			tempGobj.isStatic=false;
			dicPosAndWallName=new Dictionary<string, string>();
			Transform tempWallConfigTra=tempGobj.transform;
			while(tempWallConfigTra.childCount>=1){
				Transform tempWallTra=tempWallConfigTra.GetChild(tempWallConfigTra.childCount-1);
				dicPosAndWallName.Add(tempWallTra.position.ToStr(3),"WallPoint");
				GameObject.DestroyImmediate(tempWallTra.gameObject);
			}
			foreach(string loopKeyStr in dicPosAndWallName.Keys){
				Vector3 tempPos=loopKeyStr.ToPos();
				string tempWallNameStr=dicPosAndWallName[loopKeyStr];
				Transform tempWallPointPrefabTra=Resources.Load<Transform>("WallPoint/"+tempWallNameStr);
				tempPos.y+=tempWallPointPrefabTra.localScale.y;
				Transform tempWallTra=PrefabUtility.InstantiatePrefab(tempWallPointPrefabTra)as Transform;
				tempWallTra.SetParent(tempWallConfigTra);
				tempWallTra.position=tempPos;
			}
		}
	}
	[MenuItem("WallConfig/CreateWall")]
	private static void CreateWall(){
		GameObject tempGobj = Selection.activeGameObject;
		if(tempGobj!=null&&tempGobj.name=="WallConfig"&&!tempGobj.isStatic){
			tempGobj.isStatic=true;
			dicPosAndWallName=new Dictionary<string, string>();
			Transform tempWallConfigTra=tempGobj.transform;
			SetWall (tempWallConfigTra.GetChild(0).GetComponent<WallPoint>());
			while(tempWallConfigTra.childCount>=1){
				Transform tempWallTra=tempWallConfigTra.GetChild(tempWallConfigTra.childCount-1);
				GameObject.DestroyImmediate(tempWallTra.gameObject);
			}
			foreach(string loopKeyStr in dicPosAndWallName.Keys){
				Vector3 tempPos=loopKeyStr.ToPos();
				string tempWallNameStr=dicPosAndWallName[loopKeyStr];
				#region 排序字符命名
				string tempNewWallNameStr=SortWallName(tempWallNameStr,"","F");
				tempNewWallNameStr=SortWallName(tempWallNameStr,tempNewWallNameStr,"B");
				tempNewWallNameStr=SortWallName(tempWallNameStr,tempNewWallNameStr,"L");
				tempNewWallNameStr=SortWallName(tempWallNameStr,tempNewWallNameStr,"R");
				tempWallNameStr=tempNewWallNameStr;
				#endregion
				Transform tempWallConfigPrefabTra=Resources.Load<Transform>("WallConfig/"+tempWallNameStr);
				Transform tempWallTra=PrefabUtility.InstantiatePrefab(tempWallConfigPrefabTra)as Transform;
				tempWallTra.SetParent(tempWallConfigTra);
				tempWallTra.position=tempPos;
			}
		}
	}
	private static string SortWallName(string theWallNameStr,string theNewWallNameStr,string theCharStr){
		string returnWallNameStr = theNewWallNameStr;
		if(theWallNameStr.Contains(theCharStr)){
			if(theNewWallNameStr!=""){
				returnWallNameStr+="_";
			}
			returnWallNameStr+=theCharStr;
		}
		return returnWallNameStr;
	}
	private static void SetWall(WallPoint theWallPointC){
		if(theWallPointC==null)return;
		theWallPointC.isSet = true;//防止重复嵌套遍历
		Vector3 tempPos = theWallPointC.transform.position;
		tempPos.y -= theWallPointC.transform.localScale.y;
		string tempPosStr=tempPos.ToStr(3);
		string tempWallNameStr = "";
		//获取WallName
		Collider[] tempCols = Physics.OverlapSphere (theWallPointC.transform.position,theWallPointC.wallLength+0.2f);
		foreach(Collider theCol in tempCols){
			WallPoint tempTargetWallPointC=theCol.GetComponent<WallPoint>();
			if(tempTargetWallPointC!=null&&theWallPointC!=tempTargetWallPointC){
				Vector3 tempTargetPos = tempTargetWallPointC.transform.position;
				tempTargetPos.y -= tempTargetWallPointC.transform.localScale.y;
				string tempTargetPosStr=tempTargetPos.ToStr(3);
				if(!tempTargetWallPointC.isSet&&dicPosAndWallName.ContainsKey(tempTargetPosStr)){//去除重叠
					continue;
				}
				float tempXValue=tempTargetWallPointC.transform.position.x-theWallPointC.transform.position.x;
				float tempZValue=tempTargetWallPointC.transform.position.z-theWallPointC.transform.position.z;
				if(Mathf.Abs(tempXValue)>=theWallPointC.wallLength-0.2f&&Mathf.Abs(tempZValue)<=0.2f){
					if(tempXValue>0f){
						if(tempWallNameStr!=""){
							tempWallNameStr+="_";
						}
						tempWallNameStr+="R";
					}
					else if(tempXValue<0f){
						if(tempWallNameStr!=""){
							tempWallNameStr+="_";
						}
						tempWallNameStr+="L";
					}
				}
				if(Mathf.Abs(tempZValue)>=theWallPointC.wallLength-0.2f&&Mathf.Abs(tempXValue)<=0.2f){
					if(tempZValue>0f){
						if(tempWallNameStr!=""){
							tempWallNameStr+="_";
						}
						tempWallNameStr+="F";
					}
					else if(tempZValue<0f){
						if(tempWallNameStr!=""){
							tempWallNameStr+="_";
						}
						tempWallNameStr+="B";
					}
				}
			}
		}
		//加入到预创建字典
		if(!dicPosAndWallName.ContainsKey(tempPosStr)){
			dicPosAndWallName.Add(tempPosStr,tempWallNameStr);
		}
		//嵌套遍历
		foreach(Collider theCol in tempCols){
			WallPoint tempTargetWallPointC=theCol.GetComponent<WallPoint>();
			if(tempTargetWallPointC!=null&&theWallPointC!=tempTargetWallPointC){
				if(!tempTargetWallPointC.isSet){
					SetWall(tempTargetWallPointC);
				}
			}
		}
	}
}
