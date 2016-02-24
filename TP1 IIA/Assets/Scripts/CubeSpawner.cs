using UnityEngine;
using System.Collections;

public class CubeSpawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int maxCubeObjects = 10;
		int xRandom, zRandom;
		for(int i = 0; i < maxCubeObjects; i++){
				xRandom = Random.Range(-15,15);
				zRandom = Random.Range(-15,15);
				GameObject newCube = Instantiate(Resources.Load("Cube"),new Vector3(xRandom,1,zRandom), Quaternion.identity) as GameObject;
				newCube.transform.parent = this.gameObject.transform;
		}

	}

	// Update is called once per frame
	void Update () {

	}
}
