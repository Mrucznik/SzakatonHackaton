﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootControl : MonoBehaviour {

    public int damage;
    public float destroyDelay;
    public float speed;
    public PlayerMove rb;
    public GameObject deathParticle;
    public GameObject brokenBullet;
    // Use this for initialization
    void Start () {
        rb = FindObjectOfType<PlayerMove>();
	}
	
	// UpdateTime is called once per frame
	void Update () {
        StartCoroutine("WaitAndDestroy");
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        if(lifeTime <=0)
        {
            die();
        }
        lifeTime -= Time.deltaTime;
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            //Instantiate(deathParticle, other.transform.position, other.transform.rotation);
            //Destroy(other.gameObject);

            other.GetComponent<EnemyHealtControl>().giveDMG(damage);
        }
        Instantiate(brokenBullet, other.transform.position, other.transform.rotation);
        Destroy(gameObject);
    }
    public IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }

}
