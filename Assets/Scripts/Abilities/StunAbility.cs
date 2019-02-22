using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunAbility : MonoBehaviour
{
    public Ability m_ability;
    public float m_attackSpeed = 1f;
    private float _nextFire = 0f;

    // Update is called once per frame
    void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Alpha2) && Time.time > _nextFire)
        {
            _nextFire = Time.time + m_attackSpeed;


        }
	}
}
