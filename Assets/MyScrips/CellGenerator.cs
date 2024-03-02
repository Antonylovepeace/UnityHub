using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CellPrefab;
    public Cell[] cells = new Cell[9];
    void Start()
    {
        Build();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Build()
    {
        for (int i = 0; i<=8; i++)
        {
            GameObject newCell = Instantiate(CellPrefab,transform);
            
            cells[i] = newCell.GetComponent<Cell>();            // button


        }
    }
}
