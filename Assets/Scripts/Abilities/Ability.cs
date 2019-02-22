using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour {

    public Rigidbody m_abilityPrefab;
    public GameObject m_cursor;
    public LayerMask m_layer;
    private Vector3 m_shootPoint;

    private Camera m_cam;


	// Use this for initialization
	void Start () {
        m_cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        m_shootPoint = new Vector3(transform.position.x, 10f, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            LaunchAbility();
        }
    }

    void LaunchAbility()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            //m_cursor.SetActive(true);
            //m_cursor.transform.position = hit.point + Vector3.up * 0.1f;
            Debug.Log("jdisadjias");
            Vector3 Vo = CalculateVelocity(hit.point, transform.position, 1f);

            transform.rotation = Quaternion.LookRotation(Vo);

            Rigidbody obj = Instantiate(m_abilityPrefab, m_shootPoint, Quaternion.identity);
            obj.velocity = Vo;
        }
    }


    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
    {
        var distance = target - origin;
        var distanceXZ = distance;
        distanceXZ.y = 0f;

        float Sy = distance.y;
        float Sxz = distanceXZ.magnitude;

        float Vxz = Sxz / time;
        float Vy = Sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = distanceXZ.normalized;
        result *= Vxz;
        result.y = Vy;

        return result;
    }

}
