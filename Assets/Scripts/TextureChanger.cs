using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureChanger : MonoBehaviour
{
    public Material m_greenMaterial;
    public Material m_redMaterial;
    public Material m_defaultMaterial;
    public bool m_displayCells;
    public bool m_changeMaterial;

    private GameObject capsuledObject;
    private PlayerHealth player;

    private void Start()
    {
        capsuledObject = GetComponentInChildren<CapsuledCell>().gameObject;
        capsuledObject.layer = 8; // free cell


    }

    private void Update()
    {
        if (m_displayCells)
        {
            if (m_changeMaterial)
                this.GetComponent<Renderer>().material = m_redMaterial;
            else
                this.GetComponent<Renderer>().material = m_greenMaterial;
        }
        else
        {
            this.GetComponent<Renderer>().material = m_defaultMaterial;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        player = collision.gameObject.GetComponent<PlayerHealth>();
        if (player)
        {
            this.GetComponent<Renderer>().material = m_redMaterial;
            this.m_changeMaterial = true;


            // Need to know what id
            var id = player.GetComponent<Player>().PlayerID;

            // Adjust layers
            capsuledObject.layer = LayerMask.NameToLayer("OccupiedCell_" + id);
            player.gameObject.layer = LayerMask.NameToLayer("PlayerOnCell_" + id);

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        this.m_changeMaterial = false;
        this.GetComponent<Renderer>().material = m_greenMaterial;
        capsuledObject.layer = 8;
        player.gameObject.layer = LayerMask.NameToLayer("PlayerDefault_" + player.GetComponent<Player>().PlayerID);
    }



}
