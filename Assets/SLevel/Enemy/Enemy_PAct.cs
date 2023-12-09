using UnityEngine;
using System.Collections;

public partial class Enemy {
	public string actNameStr{ get; set;}
	public UnityEngine.AI.NavMeshAgent navMeshAgent{ get; set;}
	public Patrol patrolC=new Patrol();
	public Attack attackC=new Attack();
	public Pursue pursueC=new Pursue();
	public void AwakeAct(){
		actNameStr="Idle";
		navMeshAgent=this.transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
	}
	public void EnterAct(string theActNameStr){
		actNameStr = theActNameStr;
		//print(actNameStr);
		if(actNameStr=="Idle"){
			EnterAni("Idle");
		}
		else if(actNameStr=="Patrol"){
			pursueC.pursuePlayerC=this.transform.parent.Find("Player").GetComponent<Player>();
			patrolC.enemyPatrolPointTra=EnemyPatrolPoint.thisC.GetPatrolPoint();
			navMeshAgent.SetDestination(patrolC.enemyPatrolPointTra.position);
			EnterAni("Run");
		}
		else if(actNameStr=="Attack"){
			this.transform.LookAt(attackC.catchPlayerC.transform.position);
			attackC.targetRotTime=Time.time+1f;
			Camera.main.transform.PlaySound2D(monkeyAttackAudioClip);
			EnterAni("Attack");
		}
		else if(actNameStr=="GameOver"){
			EnterAni("Idle");
		}
		else if(actNameStr=="Pursue"){
			this.gameObject.GetComponent<AudioSource>().Play();
			print("playlingsheng ");
			pursueC.pursuePlayerC=this.transform.parent.Find("Player").GetComponent<Player>();
		}
	}
	public void UpdateAct(){
		if(actNameStr=="Idle"){
			EnterAct("Patrol");
		}
		else if(actNameStr=="Patrol"){
			if(DiamondSave.thisC.transform.childCount<=20){
				EnterAct("Pursue");
			}
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
			float PlayerDis=Vector3.Distance(this.transform.position,pursueC.pursuePlayerC.transform.position);
			if(PlayerDis<=12f){
				EnterAct("Pursue");
			}else{
				float tempDis=Vector3.Distance(this.transform.position,patrolC.enemyPatrolPointTra.position);
			if(tempDis<=0.1f){
				EnemyPatrolPoint.thisC.RemovePatrolPoint(patrolC.enemyPatrolPointTra);
				patrolC.enemyPatrolPointTra=EnemyPatrolPoint.thisC.GetPatrolPoint();
				navMeshAgent.SetDestination(patrolC.enemyPatrolPointTra.position);
			}
			}
		}
		else if(actNameStr=="Attack"){
			if(Time.time<=attackC.targetRotTime){
				attackC.catchPlayerC.transform.rotation=Quaternion.Lerp(attackC.catchPlayerC.transform.rotation,Quaternion.LookRotation(-this.transform.forward),2f);
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
			if(DiamondSave.thisC.transform.childCount<=20){
				this.navMeshAgent.speed=6.5f;
				navMeshAgent.SetDestination(pursueC.pursuePlayerC.transform.position);
				EnterAct("Pursue");
			}else{
				float PlayerDis=Vector3.Distance(this.transform.position,pursueC.pursuePlayerC.transform.position);
			if(PlayerDis<=12f){
				/*Vector3 toTarget = pursueC.pursuePlayerC.transform.position - this.transform.position;
				float turnAngle = Vector3.Angle(this.transform.forward,toTarget);
				this.navMeshAgent.acceleration = turnAngle * navMeshAgent.speed;*/
				StartCoroutine(EnterIEnumerator());
			}
			else{
				EnterAct("Patrol");
			}
			}
		}
	}
	public class Patrol{
		public Transform enemyPatrolPointTra;
	}
	public class Attack{
		public Player catchPlayerC;
		public float targetRotTime;
	}
	public class Pursue{
		public Player pursuePlayerC;
	}
	private IEnumerator EnterIEnumerator(){
		this.navMeshAgent.speed=7f;
		navMeshAgent.SetDestination(pursueC.pursuePlayerC.transform.position);
		yield return new WaitForSeconds(1f);
		this.navMeshAgent.speed=5f;
		navMeshAgent.SetDestination(pursueC.pursuePlayerC.transform.position);
	}
}
