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



    }



    public void SelectColor(int index)
    {
        activeColor = colors[index];
    }
}