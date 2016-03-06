using UnityEngine;
using System.Collections;

public class CarBehaviour3a : CarBehaviour {

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
	//A velocidade das rodas é inversamente proporcional ao output dos sensores
		m_LeftWheelSpeed = (1/leftSensor) * MaxSpeed;
		m_RightWheelSpeed = (1/rightSensor) * MaxSpeed;

	//Calcular os outputs dos sensores
        bool northSensor = northOD.getOutput();
        bool southSensor = southOD.getOutput();
        bool eastSensor = eastOD.getOutput();
        bool westSensor = westOD.getOutput();

	//Conforme os outputs rodar o carro
        if(northSensor){
            if(!eastSensor){
                transform.root.transform.Rotate(0,10,0);
            }
            else if(!westSensor){
                transform.root.transform.Rotate(0,-10,0);
            }
            else if(!southSensor){
                transform.root.transform.Rotate(0,180,0);
            }
        }

        if(westSensor){
            if(!northSensor){
                transform.root.transform.Rotate(0,0,0);

            }
            else if(!eastSensor){
                transform.root.transform.Rotate(0,10,0);
            }
            else if(!southSensor){
                transform.root.transform.Rotate(0,180,0);
            }
        }


        if(eastSensor){
            if(!northSensor){
                transform.root.transform.Rotate(0,0,0);
            }
            else if(!westSensor){
                transform.root.transform.Rotate(0,-10,0);
            }
            else if(!southSensor){
                transform.root.transform.Rotate(0,180,0);
            }

        }
        if(southSensor){
            if(!eastSensor){
                transform.root.transform.Rotate(0,10,0);
	    }
            else if(!westSensor){
                transform.root.transform.Rotate(0,-10,0);
            }

        }

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
