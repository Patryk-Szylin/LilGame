using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDragging : MonoBehaviour
{
    public GameObject m_selectedPlayer;
    Vector3[] m_positions = new Vector3[2];
    public Vector3 m_playerPosition;
    public Vector3 m_playerDestinationPosition;
    public int _mouseClicks = 1;
    private float _nextClick = 0;
    private float _clickCd = 1f;

    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            m_playerDestinationPosition = new Vector3();
            m_playerPosition = new Vector3();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (m_selectedPlayer != null)
            {
                m_selectedPlayer.transform.position = new Vector3(m_playerDestinationPosition.x, 16f, m_playerDestinationPosition.z);
            }
        }



        if(Time.time > _nextClick )
        {           
            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit hit;
                _nextClick = Time.time + _clickCd;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    if (hit.collider.gameObject.GetComponent<PlayerAttack>())
                    {
                        m_selectedPlayer = hit.collider.gameObject;
                        m_playerPosition = m_selectedPlayer.transform.position;
                        m_playerDestinationPosition = new Vector3();
                    }
                    else
                    {
                        _mouseClicks += 1;
                        m_playerDestinationPosition = hit.collider.gameObject.transform.position;
                    }

                    var objPos = hit.collider.gameObject.transform.position;
                }
            }
        }




    }

}
