using UnityEngine;
using System.Collections;

public static class FDLitJson {
	public static LitJson.JsonData SetType(this LitJson.JsonData theData, LitJson.JsonType theJsonType){
		theData.SetJsonType(theJsonType);
		return theData;
	}
	public static LitJson.JsonData ToClone(this LitJson.JsonData theData){
		LitJson.JsonData returnData=new LitJson.JsonData();
		returnData=LitJson.JsonMapper.ToObject(theData.ToJson());
		return returnData;
	}
	public static LitJson.JsonData OldCoverNew(this LitJson.JsonData theData,LitJson.JsonData theOldData){
		LitJson.JsonData returnGameData=theData;
		if(theOldData.GetJsonType()==LitJson.JsonType.Object){
			foreach(string loopKeyStr in theOldData.Keys){
				if(returnGameData.Keys.Contains(loopKeyStr)){
					returnGameData[loopKeyStr]=theOldData[loopKeyStr];
				}
			}
		}
		return returnGameData;
	}
	public static LitJson.JsonData ToJsonData(this string theJsonStr){
		LitJson.JsonData returnData=new LitJson.JsonData();
		returnData=LitJson.JsonMapper.ToObject(theJsonStr);
		return returnData;
	}
	public static LitJson.JsonData ToJsonDataCsv(this string theCsvStr){
		LitJson.JsonData returnData=new LitJson.JsonData();
		theCsvStr=theCsvStr.Replace("\uFEFF","").Replace("\r","");
		string[] tempStrs=theCsvStr.Split('\n');
		string[] tempKeyStrs=tempStrs[0].Split(',');
		if(tempKeyStrs[0]!="Name"){
			string[] tempValueStrs=tempStrs[1].Split(',');
			int tempI=0;
			foreach(string loopKeyStr in tempKeyStrs){
				returnData[loopKeyStr]=tempValueStrs[tempI];
				tempI+=1;
			}
		}
		else{
			int tempI=0;
			foreach(string loopStr in tempStrs){
				if(tempI==0||tempI==tempStrs.Length-1)goto ifEnd;
				LitJson.JsonData tempData=new LitJson.JsonData();
				string[] tempValueStrs=loopStr.Split(',');
				int tempI2=0;
				foreach(string loopKeyStr in tempKeyStrs){
					tempData[loopKeyStr]=tempValueStrs[tempI2];
					tempI2+=1;
				}
				returnData[tempValueStrs[0]]=tempData;
			ifEnd:;
				tempI+=1;
			}
		}
		return returnData;
	}
	public static LitJson.JsonData ToJsonData(this string[] theStrs){
		LitJson.JsonData returnData=new LitJson.JsonData().SetType(LitJson.JsonType.Array);
		if(theStrs.Length>=2||(theStrs.Length==1&&theStrs[0]!="")){
			foreach(string loopStr in theStrs){
				returnData.Add(loopStr);
			}
		}
		return returnData;
	}
	public static string ToJson(this object theObj){
		return LitJson.JsonMapper.ToJson(theObj);
	}
	public static int ToInt(this LitJson.JsonData theData){
		return int.Parse(theData.ToString());
	}
	public static float ToFloat(this LitJson.JsonData theData){
		return float.Parse(theData.ToString());
	}
	public static string[] GetKeyStrs(this LitJson.JsonData theData){
		string[] tempKeyStrs=new string[theData.Keys.Count];
		int tempI=0;
		foreach(string loopKeyStr in theData.Keys){
			tempKeyStrs[tempI]=loopKeyStr;
			tempI+=1;
		}
		return tempKeyStrs;
	}
	public static int FindIndex(this LitJson.JsonData theData,string theKeyStr){
		int returnIndex=-1;
		if(theData.GetJsonType()==LitJson.JsonType.Array){
			int tempI=0;
			while(tempI<=theData.Count-1){
				if(theData[tempI].ToString()==theKeyStr){
					returnIndex=tempI;
					break;
				}
				tempI+=1;
			}
		}
		else{
			int tempI=0;
			foreach(string loopKeyStr in theData.Keys){
				if(loopKeyStr==theKeyStr){
					returnIndex=tempI;
					break;
				}
				tempI+=1;
			}
		}
		return returnIndex;
	}
	public static int FindIndex(this LitJson.JsonData theData,LitJson.JsonData theValue){
		int returnIndex=-1;
		if(theData.GetJsonType()==LitJson.JsonType.Array){
			int tempI=0;
			while(tempI<=theData.Count-1){
				if(theData[tempI]==theValue){
					returnIndex=tempI;
					break;
				}
				tempI+=1;
			}
		}
		else{
			int tempI=0;
			foreach(string loopKeyStr in theData.Keys){
				if(theData[loopKeyStr]==theValue){
					returnIndex=tempI;
					break;
				}
				tempI+=1;
			}
		}
		return returnIndex;
	}
	public static bool ContainsValue(this LitJson.JsonData theData,string theValueStr){
		bool returnBool=false;
		if(theData.GetJsonType()==LitJson.JsonType.Array){
			int tempI=0;
			while(tempI<=theData.Count-1){
				if(theValueStr==theData[tempI].ToString()){
					returnBool=true;
					break;
				}
				tempI+=1;
			}
		}
		else{
			foreach(string loopKeyStr in theData.Keys){
				if(theValueStr==theData[loopKeyStr].ToString()){
					returnBool=true;
					break;
				}
			}
		}
		return returnBool;
	}
	public static void Remove(this LitJson.JsonData theData,string theKeyStr){
		LitJson.JsonData tempData=theData.ToClone();
		theData.Clear();
		theData.SetJsonType(tempData.GetJsonType());
		if(tempData.GetJsonType()==LitJson.JsonType.Array){
			int tempI=0;
			while(tempI<=tempData.Count-1){
				if(tempData[tempI].ToString()!=theKeyStr){
					theData.Add(tempData[tempI]);
				}
				tempI+=1;
			}
		}
		else{
			foreach(string loopKeyStr in tempData.Keys){
				if(loopKeyStr!=theKeyStr){
					theData[loopKeyStr]=tempData[loopKeyStr];
				}
			}
		}
	}
	public static void Remove(this LitJson.JsonData theData,int theKeyIndex){
		LitJson.JsonData tempData=theData.ToClone();
		theData.Clear();
		theData.SetJsonType(tempData.GetJsonType());
		if(tempData.GetJsonType()==LitJson.JsonType.Array){
			int tempI=0;
			while(tempI<=tempData.Count-1){
				if(tempI!=theKeyIndex){
					theData.Add(tempData[tempI]);
				}
				tempI+=1;
			}
		}
		else{
			int tempI=0;
			foreach(string loopKeyStr in tempData.Keys){
				if(tempI!=theKeyIndex){
					theData[loopKeyStr]=tempData[loopKeyStr];
				}
				tempI+=1;
			}
		}
	}
}
