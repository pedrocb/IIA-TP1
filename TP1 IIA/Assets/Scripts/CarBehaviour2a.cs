﻿using UnityEngine;
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
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {

        }
    }

}
