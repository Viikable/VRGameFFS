using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OjectMovementControl : MonoBehaviour {

    
    [SerializeField]
    private GameObject cube;

    [SerializeField]
    private Vector3 startPoint;

    [SerializeField]
    private Vector3 midPoint;

    [SerializeField]
    private Vector3 finalPoint;

    [SerializeField]
    private float speed = 1;

    [System.Serializable]
    public class GridPositionColumn {
        public Vector3[] PositionColumn = new Vector3[0];
    }

    public GridPositionColumn[] PositionRow = new GridPositionColumn[0];

    public bool test;

    [SerializeField]
    private int finalRow;
    [SerializeField]
    private int finalColumn;

    public class RowColumn {
        public int row;
        public int column;

        public RowColumn(int Row, int Column) { row = Row; column = Column; }

        public int returnRow() {
            return row;
        }

        public int returnColumn() {
            return column;
        }
    }


    private void Start() {
        RowColumn RowColumnStartPoint;
        RowColumn RowColumFinalPoint;

        for(int i = 0; i < PositionRow.Length; i++) {
            for(int j = 0; j < PositionRow[i].PositionColumn.Length; j++) {
                float distance = Vector3.Distance(cube.GetComponent<Transform>().localPosition, PositionRow[i].PositionColumn[j]);

                if(distance < 0.2f) {
                    cube.GetComponent<Transform>().localPosition = PositionRow[i].PositionColumn[j];
                    RowColumnStartPoint = new RowColumn(i, j);
                }
            }
        }

        RowColumFinalPoint = new RowColumn(RowColumnStartPoint.returnRow.ToString(), RowColumnStartPoint.returnRow.ToString());
        startPoint = cube.GetComponent<Transform>().localPosition;
        finalPoint = PositionRow[1].PositionColumn[1];
    }

    void Update () {

        if (test) {
            speed += 0.000001f;
            cube.GetComponent<Transform>().localPosition = Vector3.Lerp(cube.GetComponent<Transform>().localPosition, finalPoint, speed);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            test = true;
        }
    }


}
