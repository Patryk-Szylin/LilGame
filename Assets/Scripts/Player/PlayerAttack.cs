using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float m_attackSpeed = 1f;
    public float m_speed = 1f;
    private float _nextFire = 0f;
    public GameObject m_target;
    public GameObject m_bullet;

    public void Update()
    {
        if (m_target != null && Time.time > _nextFire)
        {
            _nextFire = Time.time + m_attackSpeed;
            var dir = m_target.transform.position - transform.position;
            GameObject bullet = Instantiate(m_bullet, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = m_speed * dir;
            bullet.GetComponent<Bullet>().m_owner = this;
        }
    }



}
