using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopBehaviour : MonoBehaviour
{
    //Before using, set the offset to 1.5 and the length of surroundingTiles to 4



    [SerializeField] float offset = 1.5f;
    public Troop troopObject;
    GameObject[] tilesGO;
    public Transform[] tiles;
    public Transform currentTile;
    public GameObject[] surroundingTiles;

    // Start is called before the first frame update
    void Start()
    {
        //SnapToClosestTile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    


    public void GetTile()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, 10))
        {
            Debug.Log(hit.transform.gameObject.name);
            //return hit.transform.gameObject;         
        }
        //return null;
    }

    public void SnapToClosestTile()
    {
        tilesGO = GameObject.FindGameObjectsWithTag("Tile");


        for (int i = 0; i < tilesGO.Length; i++)
        {

            Transform tileTransform;
            tileTransform = tilesGO[i].transform;

            tiles[i] = tileTransform;

        }

        transform.position = GetClosestTile(tiles).position;
        
        transform.position = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);
        GetTile();
        FindSurroundingTiles();
    }

    public void FindSurroundingTiles()
    {
        //print(currentTile.ToString());
        //print(currentTile);
        //print(curre)

        int firstCoord;
        int secondCoord;
        int.TryParse(currentTile.name.ToString(), out firstCoord);
        print(firstCoord);

        for (int i = 0; i < surroundingTiles.Length; i++)
        {
            //int firstCoord;
            //int secondCoord;
            //int.TryParse(currentTile.ToString(), out firstCoord);
            //print(firstCoord);
            //GameObject addTile;
            //surroundingTiles[i] = GameObject.Find("Tile"+currentTile.name)

        }
    }

    public Transform GetClosestTile(Transform[] tiles)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Transform potentialTarget in tiles)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPos;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        currentTile = bestTarget;
        return bestTarget;

    }
}
