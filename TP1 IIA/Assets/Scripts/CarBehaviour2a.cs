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

        bool northSensor = northOD.getOutput();
        bool southSensor = southOD.getOutput();
        bool eastSensor = eastOD.getOutput();
        bool westSensor = westOD.getOutput();

        /*
        Debug.Log("north: " + northSensor);
        Debug.Log("south: " + southSensor);
        Debug.Log("east: " + eastSensor);
        Debug.Log("west: " + westSensor);
        Debug.Log("-----------------------");
        */

        if(westSensor && !northSensor)
        {
            //ir para norte

            m_LeftWheelSpeed = Mathf.Abs(m_LeftWheelSpeed);
            m_RightWheelSpeed = Mathf.Abs(m_RightWheelSpeed);

        }
        else if(southSensor && !westSensor)
        {
            //ir para oest
            m_RightWheelSpeed = m_RightWheelSpeed + 20;
        }
        else if(eastSensor && !southSensor)
        {
            m_RightWheelSpeed = -m_RightWheelSpeed;
            m_LeftWheelSpeed = -m_LeftWheelSpeed; 
        }
        else if(northSensor && !eastSensor)
        {
            //ir para este
            m_LeftWheelSpeed = m_LeftWheelSpeed + 20;
        }
        else
        {
            m_LeftWheelSpeed = Mathf.Abs(m_LeftWheelSpeed);
            m_RightWheelSpeed = Mathf.Abs(m_RightWheelSpeed);

        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {

        }
    }

}
