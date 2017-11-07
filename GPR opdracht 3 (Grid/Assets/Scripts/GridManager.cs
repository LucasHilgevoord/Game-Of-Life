using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    //---Creation of the grid

    public GameObject plane;
    public static int width = 35;
    public static int height = 20;

    public static GameObject[,] cells = new GameObject[width, height];
    public static bool[,] ActStatus = new bool[width, height];
    public static bool[,] NextGen = new bool[width, height];

    // Use this for initialization
    void Awake()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                GameObject gridPlane = (GameObject)Instantiate(plane);

                gridPlane.transform.position = new Vector3(gridPlane.transform.position.x + x,
                gridPlane.transform.position.y, gridPlane.transform.position.z + z);
                cells[x, z] = gridPlane;
                ActStatus[x, z] = false;
                NextGen[x, z] = false;
            }
        }
    }
}
