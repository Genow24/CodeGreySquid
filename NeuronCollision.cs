using UnityEngine;
using System.Collections;

public class NeuronCollision : MonoBehaviour {

    public GameObject Player;
    public SphereCollider CollisionNeuron;
    public Quaternion Transformer;

    // Use this for initialization
    void Start ()
    {
        CollisionNeuron = GetComponent<SphereCollider>();
        CollisionNeuron.enabled = false;
        Transformer = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f); 
    }
	
	// Update is called once per frame
	void Update ()
    {
       if (Player.GetComponent<PlayerController>().fired == true)
        {
            CollisionNeuron = GetComponent<SphereCollider>();
            CollisionNeuron.enabled = true;
            CollisionNeuron.GetComponent<Transform>().rotation = Transformer;
        }

        else
        {
            CollisionNeuron = GetComponent<SphereCollider>();
            CollisionNeuron.enabled = false;
            CollisionNeuron.GetComponent<Transform>().rotation = Transformer;
        }
    }
}
