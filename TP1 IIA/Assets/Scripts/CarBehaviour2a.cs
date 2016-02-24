using UnityEngine;
using System.Collections;

public class CarBehaviour2a : CarBehaviour {

    public ObjectDetector northOD;
    public ObjectDetector southOD;
    public ObjectDetector eastOD;
    public ObjectDetector westOD;


    void Update()
	{
		//Read sensor values
		float leftSensor = LeftLD.getLinearOutput ();
		float rightSensor = RightLD.getLinearOutput ();

		//Calculate target motor values
		m_LeftWheelSpeed = leftSensor * MaxSpeed;
		m_RightWheelSpeed = rightSensor * MaxSpeed;

        int northSensor = northOD.getOutput();
        int southSensor = southOD.getOutput();
        int eastSensor = eastOD.getOutput();
        int westSensor = westOD.getOutput();

        /*
        Debug.Log("north: " + northSensor);
        Debug.Log("south: " + southSensor);
        Debug.Log("east: " + eastSensor);
        Debug.Log("west: " + westSensor);
        Debug.Log("-----------------------");
        */
    }

}
