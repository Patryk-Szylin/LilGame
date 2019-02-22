using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HexGrid : MonoBehaviour {

	public int width = 6;
	public int height = 6;

	public Color defaultColor = Color.white;

	public HexCell cellPrefab;
	Text cellLabelPrefab;
    public GameObject mwall;

	public HexCell[] cells;
    public List<Vector3> cellPositions = new List<Vector3>();
	Canvas gridCanvas;
	HexMesh hexMesh;

	void Awake () {
		gridCanvas = GetComponentInChildren<Canvas>();
		hexMesh = GetComponentInChildren<HexMesh>();

		cells = new HexCell[height * width];
		for (int z = 0, i = 0; z < height; z++) {
			for (int x = 0; x < width; x++) {
                Debug.Log("dsajdisad");
				CreateCell(x, z, i++);
                //
			}
		}

        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            foreach(var cell in cells)
            {
                cell.GetComponent<TextureChanger>().m_displayCells = !cell.GetComponent<TextureChanger>().m_displayCells;
            }
        }
    }


    void Start()
    {
        hexMesh.Triangulate(cells);
    }

    public Vector3 GetCellWorldPos(int index)
    {
        return cellPositions[index];
    }

	public void ColorCell (Vector3 position, Color color, GameObject toSpawn) {
		position = transform.InverseTransformPoint(position);
		HexCoordinates coordinates = HexCoordinates.FromPosition(position);
		int index = coordinates.X + coordinates.Z * width + coordinates.Z / 2;
		HexCell cell = cells[index];
		cell.color = color;
	    Instantiate(toSpawn, new Vector3(coordinates.X, 0, coordinates.Z), Quaternion.identity);
	}

    public void SpawnAtCell(Vector3 position, GameObject toSpawn)
    {
        position = transform.InverseTransformPoint(position);
        HexCoordinates coordinates = HexCoordinates.FromPosition(position);
        int index = coordinates.X + coordinates.Z * width + coordinates.Z / 2;
        HexCell cell = cells[index];

        Vector3 pos = new Vector3(GetCellWorldPos(index).x, 12f, GetCellWorldPos(index).z);

        Instantiate(toSpawn, pos, toSpawn.transform.rotation);
    }

    void CreateCell (int x, int z, int i) {
		Vector3 position;
		position.x = (x + z * 0.5f - z / 2) * (HexMetrics.innerRadius * 2f);
		position.y = 0f;
		position.z = z * (HexMetrics.outerRadius * 1.5f);

        cellPositions.Add(position);


        HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
        cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, z);
        cell.color = defaultColor;


    }
}