﻿using UnityEngine;
using System.Collections;

public class PlayerCollisionManager : MonoBehaviour {
    public GameObject Player;
    Transform newNeuron;
    public GameObject explosion;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Lethal")
        {

            Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);

            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Neuron")
        {
            Player.GetComponent<PlayerController>().fired = false;
            newNeuron = col.gameObject.transform;
            Player.GetComponent<PlayerController>().CurrentNeuron = newNeuron;


            Vector3 tempVec = new Vector3(0.0f, 0.0f, 0.0f);
            Player.GetComponent<Rigidbody>().velocity = tempVec;
            Player.GetComponent<PlayerController>().camera.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
            Player.transform.rotation = Quaternion.RotateTowards(Player.transform.rotation, newNeuron.rotation, 5.0f);
           //we need to set the cube back appropiately here
            Vector3 centerOfSphere = newNeuron.transform.position;

            Vector3 placementPosition = Player.transform.position;

            Vector3 normal = (placementPosition - centerOfSphere).normalized;

            Quaternion rotation = Quaternion.LookRotation(normal);
            Player.transform.rotation = rotation;
            Player.transform.rotation = new Quaternion(0.0f, 0.0f, Player.transform.rotation.z, 1.0f);
           
            //Quaternion startQuat = transform.rotation;
            //Vector3 startUp = transform.up;
            //transform.rotation = Quaternion.FromToRotation(transform.up, newNeuron.normal) * transform.rotation;
        }
    }
}