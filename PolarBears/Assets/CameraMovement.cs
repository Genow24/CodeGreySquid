using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public GameObject Player;
    Vector3 PlayerPosition;

	// Use this for initialization
	void Start ()
    {
        PlayerPosition = Player.GetComponent<Transform>().position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        PlayerPosition = Player.GetComponent<Transform>().position;

        transform.position = new Vector3(PlayerPosition.x, PlayerPosition.y + 4, PlayerPosition.z - 20.0f);
    }
}
