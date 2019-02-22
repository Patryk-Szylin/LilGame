using UnityEngine;
using UnityEngine.EventSystems;

public class HexMapEditor : MonoBehaviour
{

    public Color[] colors;

    public HexGrid hexGrid;
    public GameObject MwallPrefab;
    private Color activeColor;


    void Awake()
    {
        SelectColor(0);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("handling input");
            HandleInput();
        }


    }

    void HandleInput()
    {
        //Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    RaycastHit hit;
        //    if (Physics.Raycast(inputRay, out hit))
        //    {
        //        //hexGrid.ColorCell(hit.point, activeColor);
        //        hexGrid.SpawnAtCell(hit.point, MwallPrefab);

        //    }
    }

    public void SelectColor(int index)
    {
        activeColor = colors[index];
    }
}