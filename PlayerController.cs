using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float currentScale;
    public Camera camera;
    public float currentPosition;
    Vector3 velocity;
    bool flip = false;
    bool inverseflip = false;
    bool inverseflippossible= false;
    bool scaleflipped = true;
    [SerializeField]
    public Transform CurrentNeuron;
    public Vector3 axis = Vector3.up;
    public Vector3 desiredPosition;
    public Vector3 flightVelocity;
    public float radius = 1.9f;
    public float radiusSpeed = 1.0f;
    public float flightSpeed = 5.0f;
    public float rotationSpeed = 80.0f;
    public bool orbitflip = false;
    public bool fired = false;
    [SerializeField]
    public Rigidbody rigid;

   

	// Use this for initialization
	void Start () {
        currentScale = transform.localScale.y;
        currentPosition = transform.position.y;
        velocity = new Vector3(0.0f, 0.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && scaleflipped == true)
        {
            scaleflipped = false;
            if (inverseflippossible  == true)
            {
                inverseflip = true;
            }
            if (flip == false && inverseflip == false)
            {
                flip = true;
            }
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
        if (Input.GetMouseButtonDown(1) && inverseflippossible == false) // you can fly out
        {
            flightVelocity = (CurrentNeuron.position - transform.position).normalized * -flightSpeed;
            rigid.velocity = (flightVelocity);
           camera.GetComponent<Rigidbody>().velocity = flightVelocity;
            fired = true;
        }

        if (fired == false)
        {
            camera.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
            OrbitUpdate();
        }

        if(flip == true)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - (2 *Time.deltaTime), transform.localScale.z);
            if (transform.localScale.y < -currentScale)
            {
                transform.localScale = new Vector3(transform.localScale.x, -currentScale, transform.localScale.z);
                scaleflipped = true;
                flip = false;
                inverseflippossible = true;
            }
        }

        if (inverseflip == true)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + (2 * Time.deltaTime), transform.localScale.z);
            if (transform.localScale.y > currentScale)
            {
                transform.localScale = new Vector3(transform.localScale.x, currentScale, transform.localScale.z);
                scaleflipped = true;
                flip = false;
                inverseflippossible = false;
                inverseflip = false;
            }
        }
	}

    void OrbitUpdate()
    {

        transform.RotateAround(CurrentNeuron.position, new Vector3(0.0f, 0.0f, 1.0f), rotationSpeed * Time.deltaTime);
        desiredPosition = (transform.position - CurrentNeuron.position).normalized * radius + CurrentNeuron.position;
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
    }
}
