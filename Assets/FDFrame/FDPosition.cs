using UnityEngine;
using System.Collections;
public static class FDPosition{
	public static Vector3 Keep(this Vector3 thePos,int theCount){
		float tempNum=Mathf.Pow(10f,theCount);
		return new Vector3((int)(thePos.x*tempNum),(int)(thePos.y*tempNum),(int)(thePos.z*tempNum))/tempNum;
	}
	public static string ToStr(this Vector3 thePos){
		return thePos.x+","+thePos.y+","+thePos.z;
	}
	public static string ToStr(this Vector3 thePos,int theKeepCount){
		thePos=thePos.Keep(theKeepCount);
		return thePos.x+","+thePos.y+","+thePos.z;
	}
	public static Vector3 ToPos(this string thePosStr){
		string[] tempPosInfoStrs=thePosStr.Split(',');
		return new Vector3(float.Parse(tempPosInfoStrs[0]),float.Parse(tempPosInfoStrs[1]),float.Parse(tempPosInfoStrs[2]));
	}
	public static Vector2 Keep(this Vector2 thePos,int theCount){
		float tempNum=Mathf.Pow(10f,theCount);
		return new Vector2((int)(thePos.x*tempNum),(int)(thePos.y*tempNum))/tempNum;
	}
	public static string ToStr(this Vector2 thePos){
		return thePos.x+","+thePos.y;
	}
	public static string ToStr(this Vector2 thePos,int theKeepCount){
		thePos=thePos.Keep(theKeepCount);
		return thePos.x+","+thePos.y;
	}
	public static Vector2 ToPos2D(this string thePosStr){
		string[] tempPosInfoStrs=thePosStr.Split(',');
		return new Vector2(float.Parse(tempPosInfoStrs[0]),float.Parse(tempPosInfoStrs[1]));
	}
	public static Color Keep(this Color thePos,int theCount){
		float tempNum=Mathf.Pow(10f,theCount);
		return new Color((int)(thePos.r*tempNum),(int)(thePos.g*tempNum),(int)(thePos.b*tempNum),(int)(thePos.a*tempNum))/tempNum;
	}
	public static string ToStr(this Color thePos){
		return thePos.r+","+thePos.g+","+thePos.b+","+thePos.a;
	}
	public static string ToStr(this Color thePos,int theKeepCount){
		thePos=thePos.Keep(theKeepCount);
		return thePos.r+","+thePos.g+","+thePos.b+","+thePos.a;
	}
	public static Color ToColor(this string thePosStr){
		string[] tempPosInfoStrs=thePosStr.Split(',');
		return new Color(float.Parse(tempPosInfoStrs[0]),float.Parse(tempPosInfoStrs[1]),float.Parse(tempPosInfoStrs[2]),float.Parse(tempPosInfoStrs[3]));
	}
}
