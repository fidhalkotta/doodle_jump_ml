using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour {

	public GameObject platformPrefab;
	public GameObject cameraObject;

	private List<GameObject> platforms;

	[SerializeField] private int numberOfPlatforms = 200;
	[SerializeField] private float levelWidth = 3f;
	[SerializeField] private float minY = .2f;
	[SerializeField] private float maxY = 1.5f;

	// Use this for initialization
	void Start ()
	{
		platforms = new List<GameObject>();
		var spawnPosition = new Vector3();

		for (var i = 0; i < numberOfPlatforms; i++)
		{
			spawnPosition.y += Random.Range(minY, maxY);
			spawnPosition.x = Random.Range(-levelWidth, levelWidth);
			var addedPlatform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
			
			platforms.Add(addedPlatform);
		}
	}

	private void FixedUpdate()
	{
		if (platforms[0].transform.position.y > cameraObject.transform.position.y - 5f) return;
		
		Destroy(platforms[0]);
		platforms.RemoveAt(0);
	}
}
