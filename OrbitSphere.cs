using UnityEngine;
using System.Collections;

public class OrbitSphere : MonoBehaviour {

    [SerializeField] public Transform currentPlanet;
    public Vector3 axis = Vector3.up;
    public Vector3 desiredPosition;
    public float radius = 1.9f;
    public float radiusSpeed = 1.0f;
    public float rotationSpeed = 80.0f;
    public bool orbitflip = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
                if (Input.GetMouseButtonDown(0))
        {
            if (orbitflip == false)
            {
                orbitflip = true;
                radius = 1.42f;
            }
            else
            {
                orbitflip = false;
                radius = 1.9f;
            }
       
	}


        transform.RotateAround(currentPlanet.position, new Vector3(0.0f,0.0f,1.0f), rotationSpeed * Time.deltaTime);
        desiredPosition = (transform.position - currentPlanet.position).normalized * radius + currentPlanet.position;
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
	}
}
