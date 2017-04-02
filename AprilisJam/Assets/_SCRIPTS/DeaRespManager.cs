﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeaRespManager : MonoBehaviour {

    private PlayerMove player;
    public GameObject currentCheckpoint;
    public GameObject deathParticle;
    public GameObject respawnParticle;
    public float respawnDelay;
    
    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerMove>();
        

    }
	
	// Update is called once per frame
	void Update () {

        
    }

    public void RespawnPlayer()
    {
        ScoreManag.CountTime(1);
        StartCoroutine("RespawnPlayerCo");
        

    }
    public  IEnumerator RespawnPlayerCo()
    {
        

        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(respawnDelay);
        player.enabled = true;
        player.GetComponent<Renderer>().enabled = true;
        player.transform.position = currentCheckpoint.transform.position;
        Instantiate(respawnParticle, player.transform.position, player.transform.rotation);        
    }
}
