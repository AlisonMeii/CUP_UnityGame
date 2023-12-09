using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class FDAudio {
	public static float musicValue=0.5f;
	public static float soundValueOwn=0.5f;
	public static float soundValue{
		get{return soundValueOwn;}
		set{
			soundValueOwn=value;
			listMusicAudioSource.RemoveAll(delegate(AudioSource theAudioSource){return (theAudioSource==null);});
			foreach(AudioSource loopAudioSource in listMusicAudioSource){
				loopAudioSource.volume=soundValueOwn;
			}
		}
	}
	private static List<AudioSource> listMusicAudioSource=new List<AudioSource>();
	public static void PlaySound2D(this Transform theTra,AudioClip theAudioClip){
		if(theTra.GetComponent<AudioSource>()==null)theTra.gameObject.AddComponent<AudioSource>();
		theTra.GetComponent<AudioSource>().spatialBlend = 0f;
		theTra.GetComponent<AudioSource>().PlayOneShot(theAudioClip,soundValue);
	}
	public static void PlayMusic2D(this Transform theTra,AudioClip theAudioClip,bool theIsLoop){
		if(theTra.GetComponent<AudioSource>()==null)theTra.gameObject.AddComponent<AudioSource>();
		theTra.GetComponent<AudioSource>().spatialBlend = 0f;
		theTra.GetComponent<AudioSource>().clip = theAudioClip;
		theTra.GetComponent<AudioSource>().loop = theIsLoop;
		theTra.GetComponent<AudioSource>().volume = musicValue;
		theTra.GetComponent<AudioSource>().Play ();
		if(!listMusicAudioSource.Contains(theTra.GetComponent<AudioSource>())){
			listMusicAudioSource.Add(theTra.GetComponent<AudioSource>());
		}
	}
	public static void PlaySound3D(this Transform theTra,AudioClip theAudioClip){
		if(theTra.GetComponent<AudioSource>()==null)theTra.gameObject.AddComponent<AudioSource>();
		theTra.GetComponent<AudioSource>().spatialBlend = 1f;
		theTra.GetComponent<AudioSource>().minDistance = 5f;
		theTra.GetComponent<AudioSource>().maxDistance = 50f;
		theTra.GetComponent<AudioSource>().PlayOneShot(theAudioClip,soundValue);
	}
	public static void PlaySound3D(this Vector3 thePos,AudioClip theAudioClip){
		AudioSource.PlayClipAtPoint (theAudioClip,thePos,soundValue);
	}
	public static void PlayMusic3D(this Transform theTra,AudioClip theAudioClip,bool theIsLoop){
		if(theTra.GetComponent<AudioSource>()==null)theTra.gameObject.AddComponent<AudioSource>();
		theTra.GetComponent<AudioSource>().spatialBlend = 1f;
		theTra.GetComponent<AudioSource>().minDistance = 5f;
		theTra.GetComponent<AudioSource>().maxDistance = 50f;
		theTra.GetComponent<AudioSource>().clip = theAudioClip;
		theTra.GetComponent<AudioSource>().loop = theIsLoop;
		theTra.GetComponent<AudioSource>().volume = musicValue;
		theTra.GetComponent<AudioSource>().Play ();
		if(!listMusicAudioSource.Contains(theTra.GetComponent<AudioSource>())){
			listMusicAudioSource.Add(theTra.GetComponent<AudioSource>());
		}
	}
	public static void ResumeMusic(this Transform theTra){
		if(theTra.GetComponent<AudioSource>()==null)theTra.gameObject.AddComponent<AudioSource>();
		theTra.GetComponent<AudioSource>().Play ();
	}
	public static void PauseMusic(this Transform theTra){
		if(theTra.GetComponent<AudioSource>()==null)theTra.gameObject.AddComponent<AudioSource>();
		theTra.GetComponent<AudioSource>().Pause ();
	}
	public static void StopMusic(this Transform theTra){
		if(theTra.GetComponent<AudioSource>()==null)theTra.gameObject.AddComponent<AudioSource>();
		theTra.GetComponent<AudioSource>().Stop ();
	}
}
