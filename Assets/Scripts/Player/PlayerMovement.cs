using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour
{
    public float m_speed = 25f;
    private Rigidbody rb;
    public bool m_enableWalking;
    public bool m_hasAlly;
    public float allySpeed = 20f;

    private PlayerMovement allyController;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        allyController = GameObject.FindObjectOfType<Ally>().GetComponent<PlayerMovement>();

        if (allyController)
            m_hasAlly = true;

    }

    private void Update()
    {
        if (!isLocalPlayer)
            return;

        if (m_hasAlly)
        {
            if (Input.GetKey(KeyCode.T))
            {
                allyController.transform.Translate(Vector3.forward * Time.deltaTime * allySpeed);
            }
            if (Input.GetKey(KeyCode.G))
            {

                allyController.transform.Translate(Vector3.back * Time.deltaTime * allySpeed);
            }
            if (Input.GetKey(KeyCode.F))
            {
                allyController.transform.Translate(Vector3.left * Time.deltaTime * allySpeed);
            }
            if (Input.GetKey(KeyCode.H))
            {
                allyController.transform.Translate(Vector3.right * Time.deltaTime * allySpeed);
            }
        }

        if (m_enableWalking)
        {
            Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            this.transform.position += Movement * m_speed * Time.deltaTime;
        }
    }


}

