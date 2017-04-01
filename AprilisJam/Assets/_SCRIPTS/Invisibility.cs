﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour {

    GameObject player;
    bool visible = true;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Jump") > 0)
        {
            visible = !visible;
        }
        player.GetComponent<SpriteRenderer>().enabled = visible;
    }
}
