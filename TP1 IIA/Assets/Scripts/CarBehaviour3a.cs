using UnityEngine;
using System.Collections;

public class CarBehaviour3a : CarBehaviour {

	public ObjectDetector leftOD;
	public ObjectDetector rightOD;
	private Rigidbody rb;


	void Update()
	{
		//Read sensor values

		float lightLeftSensor = LeftLD.getLinearOutput ();
		float lightRightSensor = RightLD.getLinearOutput ();

		//Calculate target motor values
		m_LeftWheelSpeed = lightLeftSensor * MaxSpeed;
		m_RightWheelSpeed = lightRightSensor * MaxSpeed;

		leftOD.angle = 20;
		rightOD.angle = 20;

		//Calculate target motor values

		bool leftSensor = leftOD.getOutput();
		bool rightSensor = rightOD.getOutput();

		if (leftSensor && !rightSensor) {
			//go right
			m_LeftWheelSpeed = m_LeftWheelSpeed + 5;
			m_RightWheelSpeed = m_RightWheelSpeed - 5;
		} else if (rightSensor && !leftSensor) {
			//go left
			m_RightWheelSpeed = m_RightWheelSpeed + 5;
			m_LeftWheelSpeed = m_LeftWheelSpeed - 5;

		} 
		else {
			m_LeftWheelSpeed = m_LeftWheelSpeed + 5;
			m_RightWheelSpeed = m_RightWheelSpeed +5;
		}

	}

}