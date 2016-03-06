using UnityEngine;
using System.Collections;

public class CarBehaviour2a : CarBehaviour {

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
	
	float westObjectSensor = westOD.getOutput();
	float eastObjectSensor = eastOD.getOutput();
	Debug.Log(westObjectSensor + " " +eastObjectSensor);
	
	m_LeftWheelSpeed+= (1/westObjectSensor) * MaxSpeed;
	m_RightWheelSpeed+= (1/eastObjectSensor) * MaxSpeed;
	
	//Calcular os outputs dos sensores
	
	//Conforme os outputs rodar o carro
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            //other.gameObjet.SetActive(false);
        }
        if(other.gameObject.CompareTag("Walls"))
        {
            //other.gameObjet.SetActive(false);
            transform.root.transform.Rotate(0,180,0);
        }
        
    }

}
