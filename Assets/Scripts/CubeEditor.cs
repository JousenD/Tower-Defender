using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour {

    Waypoint waypoint;
    

    // Update is called once per frame
    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }


    void Update ()
    {
        SnapToGrid();
        UpdateLabel();
    }

    

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(
            waypoint.GetGridPos().x*gridSize,
            0f,
            waypoint.GetGridPos().y * gridSize
            );
    }

    private void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        
        string labelName = waypoint.GetGridPos().x+ "." + waypoint.GetGridPos().y;
        textMesh.text = labelName;
        gameObject.name = labelName;
    }
}
