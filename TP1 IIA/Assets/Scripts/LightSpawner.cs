using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightSpawner : MonoBehaviour {
	int maxNumberLights = 10;
	private int remainingLights = 10;
	float timeLeft = 6.0f;
	private List<float> lightsTimer = new List<float>();
	private List<GameObject> newLight = new List<GameObject>();

	// Use this for initialization
	void Start () {
		getLightsTimer();
		int xRandom, zRandom;
		for(int i = 0; i < maxNumberLights; i++){
				xRandom = Random.Range(-15,15);
				zRandom = Random.Range(-15,15);
				GameObject auxLight = Instantiate(Resources.Load("Point light"),new Vector3(xRandom,1,zRandom), Quaternion.identity) as GameObject;
				auxLight.transform.parent = this.gameObject.transform;
				newLight.Add(auxLight);
		}
		Debug.Log("Finished start function");


	}

	void getLightsTimer() {
		for(int i = 0; i < maxNumberLights; i++){
			float aux = Random.Range(2.0F, 7.0F);
			lightsTimer.Add(aux);
		}
	}

	// Update is called once per frame
	void Update () {
		for(int i = 0; i < maxNumberLights; i++){
			lightsTimer[i] -= Time.deltaTime;
			if ( lightsTimer[i] < 0 )
			{
				Debug.Log("Passou o tempo");
				newLight[i].gameObject.SetActive(false);
				remainingLights--;
			}
		}
		/*if(remainingLights == 0){
			Start();
		}*/
	}
}
