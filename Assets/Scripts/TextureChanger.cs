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
        if (collision.gameObject.GetComponent<PlayerHealth>())
        {
            this.GetComponent<Renderer>().material = m_redMaterial;
            //Debug.Log("Collision");
            this.m_changeMaterial = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        this.m_changeMaterial = false;
        this.GetComponent<Renderer>().material = m_greenMaterial;

    }



}
