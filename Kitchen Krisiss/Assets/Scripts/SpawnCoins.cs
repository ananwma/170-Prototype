using UnityEngine;
using System.Collections;

public class SpawnCoins : MonoBehaviour {

	public Transform[] coinSpawns;
	public GameObject Pea;

	// Use this for initialization
	void Start () {
		Spawn ();
	}

	void Spawn () {
		for (int i = 0; i < coinSpawns.Length; i++) {
			//int coinFlip = Random.Range (0,2);
			//if(coinFlip > 0) 
				//Instantiate(Pea, coinSpawns[i].position, Quaternion.identity);
		}
	}
}
