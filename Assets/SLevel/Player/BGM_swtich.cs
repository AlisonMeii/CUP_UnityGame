using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_swtich : MonoBehaviour
{   
    public Enemy em1;
    public Enemy em2;
    public Enemy em3;
    public AudioClip[] BGMaudios;

    public Boolean isPursuing {get;set;}
    // Start is called before the first frame update
    void Start()
    {
        isPursuing = false;
        this.GetComponent<AudioSource>().clip = BGMaudios[1];
        this.GetComponent<AudioSource>().loop = true;
        this.GetComponent<AudioSource>().Play();
    }
    // Update is called once per frame
    void Update()
    {
        String str1 = em1.actNameStr;
        String str2 = em2.actNameStr;
        String str3 = em3.actNameStr;
        if(DiamondSave.thisC.transform.childCount>20){
            //print("true");
             if((str1=="Pursue"||str2=="Pursue"||str3=="Pursue") && (isPursuing == false )){
                this.GetComponent<AudioSource>().clip = BGMaudios[0];
                this.GetComponent<AudioSource>().loop = true;
                this.GetComponent<AudioSource>().Play();
                isPursuing = true;
            }
            else if((str1=="Patrol"&&str2=="Patrol"&&str3=="Patrol") && isPursuing == true){
                this.GetComponent<AudioSource>().clip = BGMaudios[1];
                this.GetComponent<AudioSource>().loop = true;
                this.GetComponent<AudioSource>().Play();
                isPursuing = false;
            
            }
        }else if(DiamondSave.thisC.transform.childCount<=20 && DiamondSave.thisC.transform.childCount>0){
            //print("<20");
            this.GetComponent<AudioSource>().Pause();
            this.GetComponent<AudioSource>().clip = BGMaudios[2];
            this.GetComponent<AudioSource>().loop = true;
            this.GetComponent<AudioSource>().Play();
        }
    }
  
}
