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
    public float radius = 1.56f;
    public float outerradius = 1.56f;
    public float innerradius = 1.12f;
    public float radiusSpeed = 1.0f;
    public float flightSpeed = 5.0f;
    public float rotationSpeed = 80.0f;
    public bool orbitflip = false;
    public bool fired = false;
    [SerializeField]
    public Rigidbody rigid;
    RaycastHit HitObject;



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
                transform.position = new Vector3(transform.position.x, transform.position.y, -0.5f);
                radius = innerradius;
            }
            else
            {
                orbitflip = false;
                transform.position = new Vector3(transform.position.x, transform.position.y, 0.0f);
                radius = outerradius;
            }

        }
        if (Input.GetMouseButtonDown(1) && inverseflippossible == false) // you can fly out
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0.0f);
            flightVelocity = (CurrentNeuron.position - transform.position).normalized * -flightSpeed;
            flightVelocity.Set(flightVelocity.x, flightVelocity.y, 1.14f);
            rigid.velocity = (flightVelocity);
           camera.GetComponent<Rigidbody>().velocity = flightVelocity;
           fired = true;
            
            Debug.DrawRay(transform.position, flightVelocity);
            Debug.Log(Physics.Raycast(transform.position, flightVelocity, out HitObject));
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

/*on collision
calculate direction vector between player and neuron
normalise it
multiply by radius
add the players radius
players position = thisVector + neuron position
*/
