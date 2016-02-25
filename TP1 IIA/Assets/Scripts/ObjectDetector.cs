using UnityEngine;
using System.Collections;

public class ObjectDetector : MonoBehaviour
{

    // Use this for initialization
    public float angle;
    public float distance;
    public bool output;

    void Start()
    {
        angle = 90;
        distance = 2;
        output = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetSensorValue();
    }


    // Get Sensor output value
    public bool getOutput()
    {
        return output;
    }

    public void GetSensorValue()
    {
        ArrayList obstaclesOnSight = new ArrayList();
        float halfAngle = angle / 2.0f;

        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Walls");
        foreach (GameObject cube in cubes)
        {
            if (Vector3.Distance(transform.position, cube.transform.position) <= distance)
            {
                Vector3 toVector = (cube.transform.position - transform.position);
                Vector3 forward = transform.forward;
                toVector.y = 0;
                forward.y = 0;
                float angleToTarget = Vector3.Angle(forward, toVector);

                if (angleToTarget <= halfAngle)
                {
		    Debug.DrawLine(transform.position,cube.transform.position,Color.red);
                    Debug.Log(transform.position);
                    Debug.Log(cube.transform.position);
                    //Debug.Log(GameObject.FindGameObjectWithTag("Cube").transform.position);
                    //Debug.Log("Viu obstáculo");
                    obstaclesOnSight.Add(cube);
		    break;
                }
            }
        }
	foreach (GameObject wall in walls)
        {
            if (Vector3.Distance(transform.position, wall.transform.position) <= distance)
            {

                Vector3 toVector = (wall.transform.position - transform.position);
                Vector3 forward = transform.forward;
                toVector.y = 0;
                forward.y = 0;
                float angleToTarget = Vector3.Angle(forward, toVector);

                if (angleToTarget <= halfAngle)
                {
		    Debug.DrawLine(transform.position,GetComponent<Light>().transform.position,Color.blue);
                    Debug.Log(transform.position);
                    Debug.Log(wall.transform.position);
                    Debug.Log("Viu parede");
                    obstaclesOnSight.Add(wall);
                }
            }
        }

        if(obstaclesOnSight.Count==0)
        {
            output = false;
        }
        else
        {
            output = true;
        }

    }

}
