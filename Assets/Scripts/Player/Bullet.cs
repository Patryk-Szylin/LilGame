using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float m_dmg = 10f;
    public PlayerAttack m_owner;

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerAttack>() != null && m_owner != other.GetComponent<PlayerAttack>() || other.GetComponent<Environment>() != null)
        {
            Debug.Log("hit");
            if (other.GetComponent<PlayerAttack>())
            {
                other.GetComponent<PlayerHealth>().Damage(m_dmg);
            }

            Destroy(this.gameObject);
        }
    }


}
