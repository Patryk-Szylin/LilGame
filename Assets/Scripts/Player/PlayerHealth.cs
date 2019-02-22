using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    public float m_maxHealth = 100f;
    public bool m_selfHeal;
    public float m_healSpeed = 1f;
    public float m_healAmount = 25f;
    private float _nextHeal = 0f;
    public Image m_healthbar;
    public float m_currenthealth;

    public float Health
    {
        get
        {
            return m_currenthealth;
        }
        set
        {
            m_currenthealth = value;
            m_healthbar.fillAmount = m_currenthealth / m_maxHealth;

            if(m_currenthealth <= 0)
            {
                Die();
            }

        }
    }

    public void Start()
    {
        //m_currenthealth = m_maxHealth;
        m_healthbar.fillAmount = m_currenthealth / m_maxHealth;
    }

    public void Update()
    {
        if (m_selfHeal && Time.time > _nextHeal)
        {
            _nextHeal = Time.time + m_healSpeed;

            var difference = (m_maxHealth - m_currenthealth);
            if(difference > m_healAmount)
            {
                this.Health += m_healAmount;
            }
            else
            {
                this.Health += difference;
            }

        }
    }

    public void Damage(float dmg)
    {
        this.Health -= dmg;
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }



}
