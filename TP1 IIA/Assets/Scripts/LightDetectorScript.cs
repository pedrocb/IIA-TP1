using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class LightDetectorScript : MonoBehaviour {

    public float angle;
	
    public float output;
    public int numObjects;
    public bool isGaussian;
    public float stdev;
    public float mean;
    public float limInf;
    public float limSup;
    public float limiarInf;
    public float limiarSup;
    public float bias;
    
    void Start () {
		output = 0;
		numObjects = 0;
    }


    void FixedUpdate () {
	GameObject[] lights = GetVisibleLights (); //Todas as luzes dentro do angulo do sensor
	
	output = 0;
	numObjects = lights.Length;
	
	foreach (GameObject light in lights) {
	    Debug.DrawLine(transform.position,light.transform.position,Color.green);
	    float r = light.GetComponent<Light> ().range;
	    output += 1f / Mathf.Pow((transform.position - light.transform.position).magnitude / r + 1, 2);
	}
	
	if(numObjects>0){
	    output = output/numObjects;
	}
    }
    
    // Get Sensor output value
    public float getLinearOutput(){
	float result;
	if(output < limiarInf){
	    result = limInf;
	}
	else if(output > limiarSup){
	    result = limInf;
	}
	else{
	    if(isGaussian){ 
		result = (1F/Mathf.Sqrt(2F*Mathf.PI*stdev))*Mathf.Exp((float)-Math.Pow((output - mean),2F)/(float)(2F*Math.Pow(stdev,2F)));
		Debug.Log(result);
	    }
	    else{
		result = output;
	    }
	    result*=bias;
	    if(result> limSup){
		result = limSup;
	    }
	    else if(result<limInf){
		result = limInf;
	    }
	}
	return result;
    }
    
    
    // Returns all "Light" tagged objects. The sensor angle is not taken into account.
    GameObject[] GetAllLights()
    {
	return GameObject.FindGameObjectsWithTag ("Light");
    }

	// Returns all "Light" tagged objects that are within the view angle of the Sensor. Only considers the angle over
	// the y axis. Does not consider objects blocking the view.
	GameObject[] GetVisibleLights()
	{
	    ArrayList visibleLights = new ArrayList();
	    float halfAngle = angle / 2.0f;

	    GameObject[] lights = GameObject.FindGameObjectsWithTag ("Light");

	    foreach (GameObject light in lights) {
		Vector3 toVector = (light.transform.position - transform.position);
		Vector3 forward = transform.forward;
		toVector.y = 0;
		forward.y = 0;
		float angleToTarget = Vector3.Angle (forward, toVector);
		//Debug.DrawLine(transform.position, (light.transform.position - transform.position), Color.blue);
		if (angleToTarget <= halfAngle) {
		    visibleLights.Add (light);
		}
	    }

	    return (GameObject[])visibleLights.ToArray(typeof(GameObject));
	}


}
