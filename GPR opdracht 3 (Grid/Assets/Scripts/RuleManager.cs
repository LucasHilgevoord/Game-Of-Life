using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleManager : MonoBehaviour {

    //---Add the rules to the cells.

    private int _width;
    private int _height;
    bool isLiving;
    bool StaysAlive;
    private Renderer Rend;

    // Use this for initialization
    void Start () {
        _width = GridManager.width;
        _height = GridManager.height;
    }

    void CopyArray()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int z = 0; z < _height; z++)
            {
                GridManager.ActStatus[x, z] = GridManager.NextGen[x, z];
            }
        }
    }

	// Update is called once per frame
	void UpdateArray () {
        for (int x = 0; x < _width; x++)
        {
            for (int z = 0; z < _height; z++)
            {
                isLiving = GridManager.ActStatus[x, z];
                int AliveCount = CheckNeighbors(x, z);

                //Pas de regel doe
                if (isLiving && AliveCount < 2)
                    StaysAlive = false;
                else if (isLiving && (AliveCount == 2 || AliveCount == 3))
                    StaysAlive = true;
                else if (isLiving && AliveCount > 3)
                    StaysAlive = false;
                else if (!isLiving && AliveCount == 3)
                    StaysAlive = true;
                else
                    StaysAlive = false;

                GridManager.NextGen[x, z] = StaysAlive;

                //Voorbeeld: https://gamedevelopment.tutsplus.com/tutorials/creating-life-conways-game-of-life--gamedev-558
            }
        }
        
     }

    //Check de Neighbors om de cel.
    int CheckNeighbors(int x, int z)
    {
        int AliveCount = 0;

        // Check cell on the right.
        if (x != _width - 1)
            if (GridManager.ActStatus[x + 1, z])
                AliveCount++;

        // Check cell on the bottom right.
        if (x != _width - 1 && z != _height - 1)
            if (GridManager.ActStatus[x + 1, z + 1])
                AliveCount++;

        // Check cell on the bottom.
        if (z != _height - 1)
            if (GridManager.ActStatus[x, z + 1])
                AliveCount++;

        // Check cell on the bottom left.
        if (x != 0 && z != _height - 1)
            if (GridManager.ActStatus[x - 1, z + 1])
                AliveCount++;

        // Check cell on the left.
        if (x != 0)
            if (GridManager.ActStatus[x - 1, z])
                AliveCount++;

        // Check cell on the top left.
        if (x != 0 && z != 0)
            if (GridManager.ActStatus[x - 1, z - 1])
                AliveCount++;

        // Check cell on the top.
        if (z != 0)
            if (GridManager.ActStatus[x, z - 1])
                AliveCount++;

        // Check cell on the top right.
        if (x != _width - 1 && z != 0)
            if (GridManager.ActStatus[x + 1, z - 1])
                AliveCount++;

        return AliveCount;
        //Kijk om zich heen welke alive zijn en welke niet.
        //Eerste if is voor het checken als hij niet op de rand zit.
    }


     public void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("Grid Update");
            UpdateArray();

            for (int x = 0; x < _width; x++)
            {
                for (int z = 0; z < _height; z++)
                {
                    Rend = GridManager.cells[x, z].GetComponent<Renderer>();
                    if (GridManager.NextGen[x, z])
                        {
                            Rend.material.color = Color.black;
                        }
                    else
                        {
                            Rend.material.color = Color.white;
                        } 
                }
            }
            CopyArray();
        }  
    }
}
