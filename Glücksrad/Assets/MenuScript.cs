﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void MultiPlayer()
    {
        Application.LoadLevel("glücksrad");
    }

    public void LoadLevel()
    {

    }

}
