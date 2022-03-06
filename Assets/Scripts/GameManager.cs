using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameGrid gameGrid;
    private Vector3 mouseDownPosition;
    private Vector3 mouseUpPosition;

    private Tile selectedTile;
    void Start()
    {
        gameGrid = FindObjectOfType<GameGrid>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject.GetComponent<Tile>() != null)
            {
                mouseDownPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //Debug.Log(mouseDownPosition);
                selectedTile = hit.collider.gameObject.GetComponent<Tile>();
                //Debug.Log(selectedTile.gameObject.tag);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if(selectedTile != null)
            {
                mouseUpPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                CheckSwapDirection(mouseDownPosition, mouseUpPosition);
            }
        }
    }
    private void CheckSwapDirection(Vector3 mouseDownPos, Vector3 mouseUpPos)
    {
        Vector3 targetDir = mouseUpPos - mouseDownPos;
        float angle = Vector3.Angle(targetDir, transform.up);

        if (targetDir.x < 0)
        {
            angle = -angle;
        }

        Debug.Log(angle);
        if (angle > 0)
        {
            if (angle > 0 && angle <= 45)
            {
                Debug.Log("up");
            }
            if (angle > 45 && angle <= 135)
            {
                Debug.Log("right");
            }
            if (angle > 135 && angle <= 180)
            {
                Debug.Log("down");
            }
        } else if (angle <= 0)
        {
            if (angle <= 0 && angle > -45)
            {
                Debug.Log("up");
            }
            if (angle <= -45 && angle > -135)
            {
                Debug.Log("left");
            }
            if (angle <= -135 && angle > -180)
            {
                Debug.Log("down");
            }
        }
    }
}
