using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] public int _width, _height;

    [SerializeField] private Tile _tilePrefab;

    [SerializeField] GameObject tilesParent;

    float target = 90f;

    //private GameObject tilesParent;

    private Dictionary<Vector2, Tile> _tiles;
    private void Start()
    {
        
        GenerateGrid();
        
    }
    void GenerateGrid()
    {
        _tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"{x} {y}";
                //spawnedTile.name = $"Tile {x} {y}";
                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);

                _tiles[new Vector2(x, y)] = spawnedTile;
                spawnedTile.transform.parent = tilesParent.transform;
            }
        }

        //tilesParent.transform.rotation = Quaternion.Slerp(tilesParent.transform.rotation, target, Time.deltaTime * smooth)
        tilesParent.transform.Rotate(90, tilesParent.transform.rotation.y, tilesParent.transform.rotation.z);
    }
    
    public Tile GetTileAtPos(Vector2 pos)
    {
        if (_tiles.TryGetValue(pos, out var tile))
        {
            return tile;
        }
        return null;
    }
}
