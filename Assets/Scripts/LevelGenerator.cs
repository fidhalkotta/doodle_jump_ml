using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour {

	public GameObject platformPrefab;

	private List<GameObject> platforms;
	private float topY = -5f;

	[SerializeField] private float levelWidth = 3f;
	[SerializeField] private float levelDepth = 6f;
	[SerializeField] private float minY = .75f;
	[SerializeField] private float maxY = 1.5f;

	// Use this for initialization
	void Start ()
	{
		platforms = new List<GameObject>();
		ResetPlatforms();
	}

	private void FixedUpdate()
	{
		if (platforms.Count == 0) return;
		
		if (platforms[0].transform.position.y < transform.position.y - levelDepth)
		{
			Destroy(platforms[0]);
			platforms.RemoveAt(0);
		}

		if (platforms.Last().transform.position.y < transform.position.y + levelDepth)
		{
			AddNewPlatform();
		}
		
		
	}

	public void ResetPlatforms()
	{
		
		
		foreach (var platform in platforms)
		{
			Destroy(platform.gameObject);
		}
		
		platforms = new List<GameObject>();
		
		topY = -5f;

		while(topY < levelDepth)
		{
			AddNewPlatform();
		}
	}

	private void AddNewPlatform()
	{
		var spawnPosition = new Vector3();
		spawnPosition.y = topY + Random.Range(minY, maxY);
		spawnPosition.x = transform.position.x + Random.Range(-levelWidth, levelWidth);
		var addedPlatform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
			
		platforms.Add(addedPlatform);
		topY = spawnPosition.y;
		
	}
}
