using UnityEngine;
using System.Collections;

public partial class Player2 : MonoBehaviour {
	public GameObject[] enemyPos;
	private Transform diamondDirTra;
	private Transform diamondNearbyTra;
	public AudioClip[] diamondAudioClips;

	public AudioClip[] BGMAudioClips;
	public AudioClip diamondLevelUpAudioClip;
	public AudioClip gameEndAudioClip;
	public AudioClip KnightPursueAudioClip;
	public AudioClip KnightRageAudioClip;
	
	private void Awake(){
		diamondDirTra = this.transform.Find ("MapPoint/DiamondDir");
		diamondDirTra.gameObject.SetActive (false);
		foreach(GameObject enemypos in enemyPos){
			enemypos.SetActive (false);
		}
		diamondNearbyTra = null;
		this.GetComponent<AudioSource>().clip = BGMAudioClips[0];
        this.GetComponent<AudioSource>().loop = true;
        this.GetComponent<AudioSource>().Play();
		print("play 1");
		AwakeAni ();
		AwakeAct ();
	}
	private void Update(){
		UpdateAni ();
		UpdateAct ();
		if(DiamondSave.thisC.transform.childCount==0 && !SLevel_UEnd.thisC.isWin ){
			this.GetComponent<AudioSource>().Pause();
            this.GetComponent<AudioSource>().clip = BGMAudioClips[1];
            this.GetComponent<AudioSource>().loop = true;
            this.GetComponent<AudioSource>().Play();
		}
		if(Time.frameCount%30==0){
			//如果收集物宝石的子物体数量为零，即全部收集完，此时diamondNearbyTra变量指示为终点
			if(DiamondSave.thisC.transform.childCount==0){
				if(diamondNearbyTra==null){
					diamondNearbyTra=Destination.thisC.transform;
				}
			}
			//如果剩下的宝石小于等于20个时，tempDiamondNearbyTra的值为最近的宝石的transform
			else if(DiamondSave.thisC.transform.childCount<=20){
				Transform tempDiamondNearbyTra=null;
				float tempMinDis=-1f;
				foreach(Transform loopDiamondTra in DiamondSave.thisC.transform){
					float tempDis=Vector3.Distance(this.transform.position,loopDiamondTra.position);
					if(tempMinDis==-1f||tempDis<=tempMinDis){
						tempMinDis=tempDis;
						tempDiamondNearbyTra=loopDiamondTra;
					}
				}
				if(diamondNearbyTra==null||diamondNearbyTra!=tempDiamondNearbyTra){
					diamondNearbyTra=tempDiamondNearbyTra;
					diamondDirTra.gameObject.SetActive (true);
				}
			}
		}
		if(Time.frameCount%10==0){
			if(diamondNearbyTra!=null){
				diamondDirTra.forward=diamondNearbyTra.position-this.transform.position;
				diamondDirTra.eulerAngles=new Vector3(0f,diamondDirTra.eulerAngles.y,0f);
			}
		}
	}
	private void OnTriggerEnter(Collider theCol){
		if(theCol.transform.parent.name=="DiamondSave"){
			theCol.enabled=false;
			Destroy(theCol.gameObject);
			SLevel_ULevel.thisC.Load();
			if(theCol.name=="RedDiamond"){
				SLevel_UShowUp.thisC.Open();
				StartCoroutine(EnterRedIEnumerator());
			}
			/*if(theCol.name=="YellowDiamond"){
				SLevel_UStunned.thisC.Open();
				StartCoroutine(EnterYellowIEnumerator());
			}*/
			if(diamondAudioClips.Length>=1){
				if(DiamondSave.thisC.transform.childCount==1){
					Camera.main.transform.PlaySound2D(diamondLevelUpAudioClip);
					SLevel_ULevelUp.thisC.Open();
					if(DiamondSave.thisC.transform.childCount==21){
						Camera.main.transform.PlaySound2D(KnightPursueAudioClip);
					}
					else if(DiamondSave.thisC.transform.childCount==1){
						Camera.main.transform.PlaySound2D(KnightRageAudioClip);
					}
				}
				else{
					Camera.main.transform.PlaySound2D(diamondAudioClips[Random.Range(0,diamondAudioClips.Length)]);
				}
			}
		}
		else if(theCol.name=="Destination"){
			if(DiamondSave.thisC.transform.childCount<=0){
				if(!SLevel_UEnd.thisC.gameObject.activeSelf){
					SLevel_UEnd.thisC.Open();
				}
				this.gameObject.GetComponent<AudioSource>().Stop();
				Camera.main.transform.StopMusic();
				Camera.main.transform.PlaySound2D(gameEndAudioClip);
				SLevel_ULevel.thisC.isGameOver=true;
			}
		}
		else if(theCol.GetComponent<Enemy2>()!=null){
			theCol.GetComponent<Enemy2>().attackC.catchPlayerC=this;
			SLevel_ULevel.thisC.isGameOver=true;
			EnterAct("Death");
			SLevel_UGameOver.thisC.Open();
		}
	}
	private IEnumerator EnterRedIEnumerator(){
		foreach(GameObject enemypos in enemyPos){
			enemypos.SetActive (true);
		}
		yield return new WaitForSeconds(20f);
		foreach(GameObject enemypos in enemyPos){
			enemypos.SetActive (false);
		}

	}
	/*private IEnumerator EnterYellowIEnumerator(){
		ene1.EnterAni("Idle") ;
		ene2.EnterAni("Idle") ;
		ene3.EnterAni("Idle") ;
		ene4.EnterAni("Idle") ;
		yield return new WaitForSeconds(15f);

	}*/
}
