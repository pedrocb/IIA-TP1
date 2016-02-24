using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class LightDetectorScript : MonoBehaviour {

    public float angle;

    public float output;
    public int numObjects;
    private LineRenderer renderer;

    void Start () {
	output = 0;
	numObjects = 0;
	renderer = GetComponent<LineRenderer>();
	renderer.SetVertexCount ((int)angle + 2);
    }

    void FixedUpdate () {
	GameObject[] lights = GetVisibleLights();
	    
	output = 0;
	numObjects = lights.Length;
	    
	foreach (GameObject light in lights) {
	    float r = light.GetComponent<Light> ().range;
	    output += 1f / Mathf.Pow((transform.position - light.transform.position).magnitude / r + 1, 2);
	}
	    
	if(numObjects>0)
	    output = output/numObjects;
    }

    void Update(){
	renderer.SetPosition(0,transform.position);
	for(int i=0;i<angle;i++){
	    float auxAngle = (float)((90.0-angle/2) + i)*Mathf.Deg2Rad;
	    renderer.SetPosition(i+1,new Vector3(20*Mathf.Cos(-auxAngle),0,20*Mathf.Sin(auxAngle)));
	}
	renderer.SetPosition((int)angle+1,transform.position);
    }

    // Get Sensor output value
    public float getLinearOutput(){

	return output;
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
			
		if (angleToTarget <= halfAngle) {
		    visibleLights.Add (light);
		}
	    }

	    return (GameObject[])visibleLights.ToArray(typeof(GameObject));
	}


}
