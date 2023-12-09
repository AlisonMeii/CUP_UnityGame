using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPatrolPoint : MonoBehaviour {
	public static EnemyPatrolPoint thisC;
	public List<Transform> listUsePatrolPointTra;

	public Player pl;

	private int num = 0;
	private void Awake(){
		thisC=this;
		listUsePatrolPointTra = new List<Transform> ();
		foreach(Transform loopTra in this.transform){
			loopTra.gameObject.SetActive(false);
		}
	}
	//怪物获得巡逻点，获取巡逻点的列表，并随机数其中一个
	public Transform GetPatrolPoint(){
		num = num + 1;
		Transform returnPatrolPointTra = null;
		List<Transform> tempListPatrolPointTra = new List<Transform> ();
		foreach(Transform loopTra in this.transform){
			if(!tempListPatrolPointTra.Contains(loopTra)){
				tempListPatrolPointTra.Add(loopTra);
			}
		}
		returnPatrolPointTra=tempListPatrolPointTra[Random.Range(0,tempListPatrolPointTra.Count)];
		listUsePatrolPointTra.Add (returnPatrolPointTra);
		print("already getp"+num);
		return returnPatrolPointTra;
	}
	//移除巡逻点函数
	public void RemovePatrolPoint(Transform thePatrolPointTra){
		if(listUsePatrolPointTra.Contains(thePatrolPointTra)){
			listUsePatrolPointTra.Remove(thePatrolPointTra);
		}
	}
}
