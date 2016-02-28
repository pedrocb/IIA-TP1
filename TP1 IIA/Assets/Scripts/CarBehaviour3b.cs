using UnityEngine;
using System.Collections;

public class CarBehaviour3b : CarBehaviour {

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

	//Calculate target motor values
	m_LeftWheelSpeed = (1 - rightSensor) * MaxSpeed;
	m_RightWheelSpeed = (1 - leftSensor) * MaxSpeed;


	//Calculate target motor values

        bool northSensor = northOD.getOutput();
        bool southSensor = southOD.getOutput();
        bool eastSensor = eastOD.getOutput();
        bool westSensor = westOD.getOutput();

        if(northSensor){
            if(!eastSensor){
                //m_RightWheelSpeed = m_RightWheelSpeed +20;
                transform.root.transform.Rotate(0,10,0);
            }
            else if(!westSensor){
                //m_LeftWheelSpeed = m_LeftWheelSpeed + 20;
                transform.root.transform.Rotate(0,-10,0);
            }
            else if(!southSensor){
                //m_RightWheelSpeed = m_RightWheelSpeed - 20;
                //m_LeftWheelSpeed = m_LeftWheelSpeed - 20;
                transform.root.transform.Rotate(0,180,0);
            }
        }

        if(westSensor){
            if(!northSensor){
                transform.root.transform.Rotate(0,0,0);
                //m_LeftWheelSpeed = m_LeftWheelSpeed;
                //m_RightWheelSpeed = m_RightWheelSpeed;

            }
            else if(!eastSensor){
                //m_RightWheelSpeed = m_RightWheelSpeed + 20;
                transform.root.transform.Rotate(0,10,0);
            }
            else if(!southSensor){
                //m_RightWheelSpeed = m_RightWheelSpeed - 20;
                //m_LeftWheelSpeed = m_LeftWheelSpeed - 20;
                transform.root.transform.Rotate(0,180,0);
            }
        }


        if(eastSensor){
            if(!northSensor){
                //m_LeftWheelSpeed = m_LeftWheelSpeed + 20;
                //m_RightWheelSpeed = m_RightWheelSpeed;
                transform.root.transform.Rotate(0,0,0);
            }
            else if(!westSensor){
                //m_LeftWheelSpeed = m_LeftWheelSpeed + 20;
                transform.root.transform.Rotate(0,-10,0);
            }
            else if(!southSensor){
                //m_RightWheelSpeed = m_RightWheelSpeed - 20;
                //m_LeftWheelSpeed = m_LeftWheelSpeed - 20;
                transform.root.transform.Rotate(0,180,0);
            }

        }
        if(southSensor){
            if(!eastSensor){
                m_LeftWheelSpeed = m_LeftWheelSpeed + 20;
            }
            else if(!eastSensor){
                m_RightWheelSpeed = m_RightWheelSpeed - 20;
            }
            else if(!northSensor){
                m_LeftWheelSpeed = m_LeftWheelSpeed;
                m_RightWheelSpeed = m_RightWheelSpeed;

            }


        }

        /*
        if(transform.position.x == -22 && transform.position.z< 22 && transform.position.z>-22)
        {
            Debug.Log("PAREDE 1");
            transform.root.transform.Rotate(0, 180, 0);
        }
        else if (transform.position.x == 22 && transform.position.z < 22 && transform.position.z > -22)
        {
            Debug.Log("PAREDE 2");
            transform.root.transform.Rotate(0, 180, 0);
        }
        else if (transform.position.z == -22 && transform.position.x < 22 && transform.position.x > -22)
        {
            Debug.Log("PAREDE 3");
            transform.root.transform.Rotate(0, 180, 0);
        }
        else if (transform.position.z == -22 && transform.position.x < 22 && transform.position.x > -22)
        {
            Debug.Log("PAREDE 4");
            transform.root.transform.Rotate(0, 180, 0);
        }
        */

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {

        }
    }

}
