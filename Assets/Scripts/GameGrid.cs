using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    public GameObject[] tilesForSpawn;
    public GameObject[,] tilesGrid = new GameObject[10, 8];

    private Vector3 startGridPosition = new Vector3(-5, 4, 0);

    private int gridHorizontalSize = 10;
    private int gridVerticalSize = 8;

    
    void Awake()
    {
        CreateGameGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateGameGrid()
    {
        for (int y = 0; y < gridVerticalSize; y++)
        {
            for (int x = 0; x < gridHorizontalSize; x++)
            {
                int randTileIndex = Random.Range(0, tilesForSpawn.Length);
                GameObject tile = Instantiate(tilesForSpawn[randTileIndex], startGridPosition + new Vector3(x, -y, 0), Quaternion.identity);
                tile.transform.SetParent(gameObject.transform);
                tilesGrid[x, y] = tile;
            }
        }
    }
}
