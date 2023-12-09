using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2_IsV : MonoBehaviour
{
    // Start is called before the first frame update
    public Boolean IsVis = false;
    private void OnBecameVisible()
    {   
        IsVis = true;
        print("摄像机视野内");
    }
    private void OnBecameInvisible()

    {
        IsVis = false;
        print("在摄像机视野外");
    }

}
