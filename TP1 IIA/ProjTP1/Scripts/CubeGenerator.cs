using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {
    public int numberBlocks = 7;
    // Use this for initialization
    void Start () {
        for (int i = 0; i < numberBlocks; i++)
        {
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.AddComponent<Rigidbody>();
            cube.transform.position = new Vector3(Random.Range(-25,25), 1, Random.Range(-25, 25));
        }


	}

	// Update is called once per frame
	void Update () {
    }
}
