using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    //---Initialize the state of the cell.

    private Renderer Rend;
    private bool IsAlive;
    private int myX;
    private int myZ;

    // Use this for initialization
    void Start()
    {
        Rend = GetComponent<Renderer>();
        IsAlive = false;
    }

    void OnMouseDown()
    {
        myX = Mathf.RoundToInt(this.transform.position.x);
        myZ = Mathf.RoundToInt(this.transform.position.z);
        Debug.Log(this.transform.position.x);
        IsAlive = !IsAlive;
        if (IsAlive)
        {
            Rend.material.color = Color.black;
        }
        else
        {
            Rend.material.color = Color.white;
        }

        //Seeds in globale array zetten.
        GridManager.ActStatus[myX,myZ] = IsAlive;
    }

    public void UpdateColor()
    {
        Rend.material.color = Color.red;
    }
}

