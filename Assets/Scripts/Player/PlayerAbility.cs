using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour {

    public GameObject MwallPrefab;

	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("handling input");
            HandleInput();
        }
    }

    void HandleInput()
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(inputRay, out hit))
        {
            //hexGrid.ColorCell(hit.point, activeColor);
            hexGrid.SpawnAtCell(hit.point, MwallPrefab);

        }
    }
}
