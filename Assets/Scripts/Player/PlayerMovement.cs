using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour
{

    // Use this for initialization
    void Start()
    {

    }


    // Update is called once per frame
    void FixedUpdate()
    {

        if (!isLocalPlayer)
            return;
        Move();
    }

    public void Move()
    {
        //if (!isLocalPlayer)
        //    return;

        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("djasiojdi");
            this.transform.Translate(Vector3.forward * Time.deltaTime * 10f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("djasiojdi");
            this.transform.Translate(Vector3.back * Time.deltaTime * 10f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("djasiojdi");
            this.transform.Translate(Vector3.left * Time.deltaTime * 10f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("djasiojdi");
            this.transform.Translate(Vector3.right * Time.deltaTime * 10f);
        }
    }


}
