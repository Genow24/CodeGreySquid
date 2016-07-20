using UnityEngine;
using System.Collections;

public class UpAndDown : MonoBehaviour {

    public float movementspeed = 2.0f;
    [SerializeField]
    public float targetY;
    public float startY;
    public float currenttarget;
    public float currentY;
    public bool routeflag = false;
	// Use this for initialization
	void Start () {
        startY = transform.localPosition.y;
        currenttarget = targetY;
	}
	
	// Update is called once per frame
	void Update () {
        currentY = transform.localPosition.y;
        if (routeflag == false)
        {
            if (currentY < currenttarget)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + (movementspeed * Time.deltaTime), transform.position.z);
            }
            else
            {
                routeflag = true;
                currenttarget = startY;
            }
        }
        else
        {
            if (currentY > currenttarget)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - (movementspeed * Time.deltaTime), transform.position.z);
            }
            else
            {
                routeflag = false;
                currenttarget = targetY;
            }
        }
	}
}
