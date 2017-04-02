﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class LevelGenerator : MonoBehaviour {

    public GameObject enemy;
    public List<GameObject> prefabs;
    public List<int> prefabsQuantity;
    public int NumberOfBlocks = 128;
    public int NumberOfRows = 128;
    List<GameObject> Enemies;
    List<GameObject> Level;
    Random rand;
	// Use this for initialization

	void Start () {
        Random rand = new Random();
        GameObject world = new GameObject("World");
        Enemies = new List<GameObject>();
        Level = new List<GameObject>();
        Vector3 startingPos = Vector3.zero;
        int blocks = NumberOfBlocks;
        for (int j = 0; j < NumberOfRows; j++)
        {
            while (blocks > 0)
            {
                int i = rand.Next(prefabs.Count);
                if (blocks >= i)
                { 
                    GameObject platform = Instantiate(prefabs[i], startingPos, Quaternion.identity);
                    platform.transform.SetParent(world.transform);
                    Rigidbody2D rb = platform.AddComponent<Rigidbody2D>();
                    rb.isKinematic = true;
                    if (rand.Next(100) <= 10) 
                                platform.AddComponent<FallingPlatform>();
                    if (rand.Next(100) <= 40)
                    {
                        Enemies.Add(Instantiate(enemy, platform.transform.position + new Vector3(.5f, 0), Quaternion.identity) as GameObject);
                    }
                    Level.Add(platform);
                    startingPos.x += prefabsQuantity[i] + rand.Next(4, 6);
                    blocks -= prefabsQuantity[i];
                }
            }
            startingPos.y += 5;
            startingPos.x = 0;
            blocks = NumberOfBlocks;
        }

    }

    void Update()
    {

    }
	
}