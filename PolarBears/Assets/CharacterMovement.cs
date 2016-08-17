using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody rigidBody;
    public float speed = 2.0f;
    public int RedWine = 0;
    public int WhiteWine = 0;
    static Animator anim;


    // Use this for initialization
    void Start()
    {

        rigidBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    public bool HasWine(int wineType)
    {
        if (wineType == 0 && RedWine > 0)
            return true;
        if (wineType == 1 && WhiteWine > 0)
            return true;

        return false;
    }


    // Update is called once per frame
    void Update()
    {

        float inputV = Input.GetAxis("Vertical");
        float inputH = Input.GetAxis("Horizontal");
        
        float moveVertical = inputV * speed * Time.deltaTime;
        float moveHorizontal = inputH * speed * Time.deltaTime;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigidBody.MovePosition(rigidBody.position + (movement));

        //rigidBody.AddForce(moveHorizontal, 0f,moveVertical);

        if (movement != Vector3.zero)
        {
            rigidBody.MoveRotation(Quaternion.LookRotation(movement));
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }



    }
}
