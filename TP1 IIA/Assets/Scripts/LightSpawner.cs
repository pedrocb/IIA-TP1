using UnityEngine;
using System.Collections;

public class LightSpawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int maxNumberLights = 10;
		int xRandom, zRandom;
		for(int i = 0; i < maxNumberLights; i++){
				xRandom = Random.Range(-15,15);
				zRandom = Random.Range(-15,15);
				GameObject newLight = Instantiate(Resources.Load("Point light"),new Vector3(xRandom,1,zRandom), Quaternion.identity) as GameObject;
				newLight.transform.parent = this.gameObject.transform;
		}


	}

	// Update is called once per frame
	void Update () {

	}
}
