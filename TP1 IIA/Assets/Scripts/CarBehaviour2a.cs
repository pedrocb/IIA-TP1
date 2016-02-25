using UnityEngine;
using System.Collections;

public class CarBehaviour2a : CarBehaviour {

    public ObjectDetector northOD;
    public ObjectDetector southOD;
    public ObjectDetector eastOD;
    public ObjectDetector westOD;
    private Rigidbody rb;


    void Update()
    {
	//Read sensor values
	float leftSensor = LeftLD.getLinearOutput ();
	float rightSensor = RightLD.getLinearOutput ();

	//leftSensor = 0.5f;
	//rightSensor = 0.5f;
	//Calculate target motor values
	
	m_LeftWheelSpeed = rightSensor * MaxSpeed;
	m_RightWheelSpeed = leftSensor * MaxSpeed;
	
        bool northSensor = northOD.getOutput();
        bool southSensor = southOD.getOutput();
        bool eastSensor = eastOD.getOutput();
        bool westSensor = westOD.getOutput();
	
        /*if(westSensor && !northSensor)
        {
            //ir para norte
            m_LeftWheelSpeed = m_LeftWheelSpeed +20;
            m_RightWheelSpeed = m_RightWheelSpeed + 20;

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

	    }*/
	if(westSensor || eastSensor || northSensor || southSensor){
	    transform.root.transform.Rotate(0,10,0);
	}
	
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {

        }
    }

}
