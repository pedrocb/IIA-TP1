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
        angle = 80;
        distance = 2;
        output = false;
    }

    // Update is called once per frame
    void Update()
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
                    obstaclesOnSight.Add(cube);
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
