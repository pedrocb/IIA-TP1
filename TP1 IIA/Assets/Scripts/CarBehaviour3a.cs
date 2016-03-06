using UnityEngine;
using System.Collections;

public class CarBehaviour3a : CarBehaviour {

    public ObjectDetector eastOD;
    public ObjectDetector westOD;
    private Rigidbody rb;


    void Update()
    {
	//Read sensor values
	float leftSensor = LeftLD.getLinearOutput ();
	float rightSensor = RightLD.getLinearOutput ();

	//Calculate target motor values
	//A velocidade das rodas é inversamente proporcional ao output dos sensores
	m_LeftWheelSpeed = (1/leftSensor) * MaxSpeed;
	m_RightWheelSpeed = (1/rightSensor) * MaxSpeed;

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
