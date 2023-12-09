using UnityEngine;
using System.Collections;

public partial class Player : MonoBehaviour {
	public GameObject ene1Po;
	public GameObject ene2Po;
	public GameObject ene3Po;
	public Enemy ene1;
	public Enemy ene2;
	public Enemy ene3;
	private Transform diamondDirTra;
	private Transform diamondNearbyTra;
	public AudioClip[] diamondAudioClips;
	public AudioClip diamondLevelUpAudioClip;
	public AudioClip gameEndAudioClip;
	public AudioClip monkeyPursueAudioClip;
	public AudioClip monkeyRageAudioClip;
	
	private void Awake(){
		diamondDirTra = this.transform.Find ("MapPoint/DiamondDir");
		diamondDirTra.gameObject.SetActive (false);
		ene1Po.SetActive (false);
		ene2Po.SetActive (false);
		ene3Po.SetActive (false);
		diamondNearbyTra = null;
		AwakeAni ();
		AwakeAct ();
	}
	private void Update(){
		UpdateAni ();
		UpdateAct ();
		if(Time.frameCount%30==0){
			//如果收集物宝石的子物体数量为零，即全部收集完，此时diamondNearbyTra变量指示为终点
			if(DiamondSave.thisC.transform.childCount==0){
				if(diamondNearbyTra==null){
					diamondNearbyTra=Destination.thisC.transform;
				}
			}
			//如果剩下的宝石小于等于50个时，tempDiamondNearbyTra的值为最近的宝石的transform
			else if(DiamondSave.thisC.transform.childCount<=50){
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
				if(DiamondSave.thisC.transform.childCount==21||DiamondSave.thisC.transform.childCount==1){
					Camera.main.transform.PlaySound2D(diamondLevelUpAudioClip);
					SLevel_ULevelUp.thisC.Open();
					if(DiamondSave.thisC.transform.childCount==21){
						Camera.main.transform.PlaySound2D(monkeyPursueAudioClip);
					}
					else if(DiamondSave.thisC.transform.childCount==1){
						Camera.main.transform.PlaySound2D(monkeyRageAudioClip);
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
				Camera.main.GetComponent<AudioSource>().Stop();
				Camera.main.transform.StopMusic();
				Camera.main.transform.PlaySound2D(gameEndAudioClip);
				SLevel_ULevel.thisC.isGameOver=true;
			}
		}
		else if(theCol.GetComponent<Enemy>()!=null){
			theCol.GetComponent<Enemy>().attackC.catchPlayerC=this;
			SLevel_ULevel.thisC.isGameOver=true;
			EnterAct("Death");
			SLevel_UGameOver.thisC.Open();
		}
	}
	private IEnumerator EnterRedIEnumerator(){
		ene1Po.SetActive (true);
		ene2Po.SetActive (true);
		ene3Po.SetActive (true);
		yield return new WaitForSeconds(20f);
		ene1Po.SetActive (false);
		ene2Po.SetActive (false);
		ene3Po.SetActive (false);

	}
	/*private IEnumerator EnterYellowIEnumerator(){
		ene1.EnterAni("Idle") ;
		ene2.EnterAni("Idle") ;
		ene3.EnterAni("Idle") ;
		yield return new WaitForSeconds(15f);

	}*/
}
