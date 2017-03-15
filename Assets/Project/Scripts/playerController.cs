using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float SpeedoT = 5f;
    public float jumpHeight = 5f;
    public float NavBoost = 5f;
    public float PHealth = 100f;
    public Rigidbody Prb;
    public bool BoostModeActive = false;

    // Use this for initialization
    void Start()
    {
        Prb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMovement();
        BoostMode();
    }

    public void PlayerMovement()
    {
        if (BoostModeActive == false)
        {
            float moveH = Input.GetAxis("Horizontal");
            float moveV = Input.GetAxis("Vertical");

            Vector3 Move = new Vector3(moveH, 0.0f, moveV);

            Prb.AddTorque(Move * SpeedoT);

            if (Input.GetKeyDown("space"))
            {
                Vector3 Jump = new Vector3(0.0f, jumpHeight, 0.0f);
                Prb.AddForce(Jump * jumpHeight);
            }
            if (Input.GetKeyDown("left shift"))
            {
                Vector3 navboost = new Vector3(-NavBoost, 0f, 0f);
                Prb.AddForce(navboost * NavBoost);
            }
        }
    }

    public void BoostMode()
    {
        if (BoostModeActive == true)
        {
            //Changes movement and camera control.
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Hazard"))
        {
            //Destroy(gameObject)
        }
        if (other.gameObject.CompareTag("Zone Trigger"))
        {
            //Activate Boost Mode
            BoostModeActive = true;
        }
        if (other.gameObject.CompareTag("Launch Pad"))
        {
            //Launches player forwards and upwards to a pre specified location.
        }
    }
}
