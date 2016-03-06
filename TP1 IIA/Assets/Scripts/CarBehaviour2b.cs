using UnityEngine;
using System.Collections;

public class CarBehaviour2b : CarBehaviour {

    public ObjectDetector eastOD;
    public ObjectDetector westOD;
    private Rigidbody rb;


    void Update()
    {
	//Read sensor values
	float leftSensor = LeftLD.getLinearOutput ();
	float rightSensor = RightLD.getLinearOutput ();

	//Calculate target motor values
	//Sensor da direita influencia roda da esquerda e vice-versa
	m_LeftWheelSpeed = rightSensor * MaxSpeed;
	m_RightWheelSpeed = leftSensor * MaxSpeed;

	float westObjectSensor = westOD.getOutput();
	float eastObjectSensor = eastOD.getOutput();
	
	m_LeftWheelSpeed+= (1/westObjectSensor) * MaxSpeed;
	m_RightWheelSpeed+= (1/eastObjectSensor) * MaxSpeed;

	
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {

        }
        if(other.gameObject.CompareTag("Walls"))
        {
            //other.gameObjet.SetActive(false);
            transform.root.transform.Rotate(0,180,0);
        }
    }


}
