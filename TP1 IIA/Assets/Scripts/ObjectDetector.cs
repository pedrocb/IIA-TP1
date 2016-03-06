using UnityEngine;
using System.Collections;

public class ObjectDetector : MonoBehaviour
{

    // Use this for initialization
    public float angle;
    public float output;
    public float bias;
    
    void Start()
    {
        angle = 90;
        output = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetSensorValue();
    }


    // Get Sensor output value
    public float getOutput()
    {
        return bias*output;
    }
    
   public void GetSensorValue()
    {
        float halfAngle = angle / 2.0f;
	
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");
	float minDistance = -1;
	GameObject closer = null;
	foreach (GameObject cube in cubes)
        {
	    Vector3 toVector = (cube.transform.position - transform.position);
	    Vector3 forward = transform.forward;
	    toVector.y = 0;
	    forward.y = 0;
	    float angleToTarget = Vector3.Angle(forward, toVector);
	    
	    if (angleToTarget <= halfAngle){
		if (minDistance == -1 || Vector3.Distance(transform.position, cube.transform.position) <= minDistance)
		    {
			
			minDistance=Vector3.Distance(transform.position, cube.transform.position);
			closer = cube;
		    }
            }
        }
	if(minDistance == -1){
	    output = 1f;
	}
	else{
	    Debug.DrawLine(transform.position,closer.transform.position,Color.red);
	    output = (minDistance/25);
	}
    }

}
