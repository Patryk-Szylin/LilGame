using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour
{
    public float m_speed = 25f;
    private Rigidbody rb;
    public bool m_enableWalking;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!isLocalPlayer)
            return;

        if (m_enableWalking)
        {
            Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            this.transform.position += Movement * m_speed * Time.deltaTime;
        }
    }


}

