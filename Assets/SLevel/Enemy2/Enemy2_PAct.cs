using System;
using UnityEngine;
using System.Collections;

public partial class Enemy2 {
	private Boolean isFirst = true;
	public string actNameStr{ get; set;}
	public UnityEngine.AI.NavMeshAgent navMeshAgent{ get; set;}
	public Patrol patrolC=new Patrol();
	public Attack attackC=new Attack();
	public Pursue pursueC=new Pursue();
	public AudioClip KnightMov;
	public void AwakeAct(){
		actNameStr="Idle";
		navMeshAgent=this.transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
	}
	public void EnterAct(string theActNameStr){
		actNameStr = theActNameStr;
		print(actNameStr);
		if(actNameStr=="Idle"){
			this.gameObject.GetComponent<AudioSource>().Pause();
			navMeshAgent.speed=0;
			navMeshAgent.acceleration=999;
			//EnterAni("Idle");
		}
		else if(actNameStr=="Patrol"){
			this.gameObject.GetComponent<AudioSource>().Play();
			pursueC.pursuePlayerC=this.transform.parent.Find("Player").GetComponent<Player2>();
			patrolC.enemyPatrolPointTra=EnemyPatrolPoint.thisC.GetPatrolPoint();
			navMeshAgent.speed=10;
			navMeshAgent.acceleration=5;
			navMeshAgent.SetDestination(patrolC.enemyPatrolPointTra.position);
			//EnterAni("Run");
		}
		else if(actNameStr=="Attack"){
			this.transform.LookAt(attackC.catchPlayerC.transform.position);
			attackC.targetRotTime=Time.time+2f;
			Camera.main.transform.PlaySound2D(KnightAttackAudioClip);
			EnterAni("Attack");
		}
		else if(actNameStr=="GameOver"){
			//EnterAni("Idle");
		}
		else if(actNameStr=="Pursue"){
			this.gameObject.GetComponent<AudioSource>().Play();
			pursueC.pursuePlayerC=this.transform.parent.Find("Player").GetComponent<Player2>();
		}
	}
	public void UpdateAct(){
		//Boolean bl = this.transform.Find("Monkey").GetComponent<Enemy2_IsV>().IsVis;
		//print(actNameStr);
		if(actNameStr=="Idle"){
			if(IsVisableInCamera()&&!isFirst){
				if(SLevel_ULevel.thisC.isGameOver){
				this.transform.StopMusic();
				navMeshAgent.Stop();
				navMeshAgent.enabled=false;
				if(attackC.catchPlayerC!=null){
					EnterAct("Attack");
				}
				else{
					EnterAct("GameOver");
				}
				return;
			}
				EnterAct("Idle");
			}else{
				if(SLevel_ULevel.thisC.isGameOver){
				this.transform.StopMusic();
				navMeshAgent.Stop();
				navMeshAgent.enabled=false;
				if(attackC.catchPlayerC!=null){
					EnterAct("Attack");
				}
				else{
					EnterAct("GameOver");
				}
				return;
			}
				EnterAct("Patrol");
				isFirst = false;
			}
		}
		else if(actNameStr=="Patrol"){
			if(SLevel_ULevel.thisC.isGameOver){
				this.transform.StopMusic();
				navMeshAgent.Stop();
				navMeshAgent.enabled=false;
				if(attackC.catchPlayerC!=null){
					EnterAct("Attack");
				}
				else{
					EnterAct("GameOver");
				}
				return;
			}
			if(IsVisableInCamera()){
				EnterAct("Idle");
			}else{
				float PlayerDis=Vector3.Distance(this.transform.position,pursueC.pursuePlayerC.transform.position);
				if(PlayerDis<=8f){
					EnterAct("Pursue");
				}else{
					float tempDis=Vector3.Distance(this.transform.position,patrolC.enemyPatrolPointTra.position);
				if(tempDis<=1f){
					EnemyPatrolPoint.thisC.RemovePatrolPoint(patrolC.enemyPatrolPointTra);
					patrolC.enemyPatrolPointTra=EnemyPatrolPoint.thisC.GetPatrolPoint();
					navMeshAgent.SetDestination(patrolC.enemyPatrolPointTra.position);
			}
			}
			}
			
		}
		else if(actNameStr=="Attack"){
			if(Time.time<=attackC.targetRotTime){
				attackC.catchPlayerC.transform.rotation=Quaternion.Lerp(attackC.catchPlayerC.transform.rotation,Quaternion.LookRotation(-this.transform.forward),5f);
			}
		}
		else if(actNameStr=="Pursue"){
			if(SLevel_ULevel.thisC.isGameOver){
				this.transform.StopMusic();
				navMeshAgent.Stop();
				navMeshAgent.enabled=false;
				if(attackC.catchPlayerC!=null){
					EnterAct("Attack");
				}
				else{
					EnterAct("GameOver");
				}
				return;
			}
			if(IsVisableInCamera()){
				EnterAct("Idle");
			}else{
				float PlayerDis=Vector3.Distance(this.transform.position,pursueC.pursuePlayerC.transform.position);
				if(PlayerDis<=8f){
					Vector3 toTarget = pursueC.pursuePlayerC.transform.position - this.transform.position;
					float turnAngle = Vector3.Angle(this.transform.forward,toTarget);
					this.navMeshAgent.acceleration = turnAngle * navMeshAgent.speed;
					this.navMeshAgent.speed=8f;
					navMeshAgent.SetDestination(pursueC.pursuePlayerC.transform.position);
				}
				else{
					EnterAct("Patrol");
				}
			}
		}
	}
	public Boolean IsVisableInCamera(){
		Camera mCamera = Camera.main;
		Vector3 pos = this.transform.position;
		Vector3 viewPos = mCamera.WorldToViewportPoint(pos);
            if (viewPos.z < 0) return false;
            if (viewPos.z > mCamera.farClipPlane)
                return false;
            if (viewPos.x < -1 || viewPos.y < -1 || viewPos.x > 2 || viewPos.y > 2) return false;
            return true;
	}

	
	public class Patrol{
		public Transform enemyPatrolPointTra;
	}
	public class Attack{
		public Player2 catchPlayerC;
		public float targetRotTime;
	}
	public class Pursue{
		public Player2 pursuePlayerC;
	}

}
