using UnityEngine;
using System.Collections;

public class VehicleBehaviour : CarBehaviour {
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float leftSensor = LeftLD.getLinearOutput ();
		float rightSensor = RightLD.getLinearOutput ();

		//Calculate target motor values
		//A velocidade das rodas é inversamente proporcional ao output dos sensores
		m_LeftWheelSpeed = leftSensor * MaxSpeed;
		m_RightWheelSpeed = rightSensor * MaxSpeed;
	}
}
