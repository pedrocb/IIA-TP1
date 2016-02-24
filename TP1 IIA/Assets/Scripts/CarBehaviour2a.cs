﻿using UnityEngine;
using System.Collections;

public class CarBehaviour2a : CarBehaviour {

	void Update()
	{
		//Read sensor values
		float leftSensor = LeftLD.getLinearOutput ();
		float rightSensor = RightLD.getLinearOutput ();

		//Calculate target motor values
		m_LeftWheelSpeed = leftSensor * MaxSpeed;
		m_RightWheelSpeed = rightSensor * MaxSpeed;

		//Check unit collisions
	}
	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Cube"))
        {
            other.gameObject.SetActive (false);
        }
    }
}
