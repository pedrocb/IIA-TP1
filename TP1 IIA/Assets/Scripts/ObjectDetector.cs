using UnityEngine;
using System.Collections;

public class ObjectDetector : MonoBehaviour
{

    // Use this for initialization
    public float angle;
    public float distance;
    public int numObjects;
    public Vector3 output;
    void Start()
    {
        angle = 60;
        distance = 20;
        numObjects = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] cubes = GetVisibleObstacles();
        numObjects = cubes.Length;

        Debug.Log(cubes.Length);

        foreach (GameObject cube in cubes)
        {
            
            //output += 1f / Mathf.Pow((transform.position - cube.transform.position).magnitude / r + 1, 2);
        }

    }


    // Get Sensor output value
    public Vector2 getObstaclePosition()
    {
        return output;
    }

    
    GameObject[] GetVisibleObstacles()
    {
        ArrayList visibleLights = new ArrayList();
        float halfAngle = angle / 2.0f;

        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");

        foreach (GameObject cube in cubes)
        {
            Vector3 toVector = (cube.transform.position - transform.position);
            Vector3 forward = transform.forward;
            toVector.y = 0;
            forward.y = 0;
            float angleToTarget = Vector3.Angle(forward, toVector);

            if (angleToTarget <= halfAngle)
            {
                visibleLights.Add(cube);
            }
        }

        return (GameObject[])visibleLights.ToArray(typeof(GameObject));
    }

}
