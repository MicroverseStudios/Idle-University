using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapGenerator : MonoBehaviour
{

    public Transform tilePrefab;
    public Transform obstaclePrefab;
    private GameObject building;
    public Vector2 mapSize;
    public Material green;
    private Vector3 tilePos;
    [Range(0, 1)]
    public float outlinePercent;

    List<Coord> allTileCoords;
    public int position;

    void Start()
    {
        GenerateMap();
        tilePos = new Vector3();
    }

    public void GenerateMap()
    {
        //populates list of tiles
        allTileCoords = new List<Coord>();
        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                allTileCoords.Add(new Coord(x, y));
            }
        }
        //trims extra list spaces
        allTileCoords.TrimExcess();

        string holderName = "Generated Map";
        if (transform.Find(holderName))
        {
            DestroyImmediate(transform.Find(holderName).gameObject);
        }

        Transform mapHolder = new GameObject(holderName).transform;
        mapHolder.parent = transform;

        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                Vector3 tilePosition = CoordToPosition(x, y);
                Transform newTile = Instantiate(tilePrefab, tilePosition, Quaternion.Euler(Vector3.right * 90)) as Transform;
                newTile.localScale = Vector3.one * (1 - outlinePercent);
                newTile.parent = mapHolder;
            }
        }

        //spawns cube at position on the map
        int obstacleCount = 1;
        for (int i = 0; i < obstacleCount; i++)
        {
            Coord randomCoord = GetCoord(position);
            Vector3 obstaclePosition = CoordToPosition(randomCoord.x, randomCoord.y);
            building = Instantiate(obstaclePrefab.gameObject, obstaclePosition + Vector3.up * .5f, Quaternion.identity);
            building.transform.parent = mapHolder;
        }

    }

    Vector3 CoordToPosition(int x, int y)
    {
        return new Vector3(-mapSize.x / 2 + 0.5f + x, 0, -mapSize.y / 2 + 0.5f + y);
    }

    private void Update()
    {
        
        //if the player is moving the building
        if (MoveBuilding.MovingBuilding)
        {
            Vector3 buildingPos = building.transform.position;

            //for every tile
            foreach (Transform child in transform.GetChild(0).transform)
            {
                if (child.CompareTag("Tile"))
                {
                    //if the distance between the building position and the tile is less than 0.5, highlight it green
                    //USE 0.5F FOR 1X1 BUILDING AND 1 FOR 2X2
                    if (Mathf.Abs(buildingPos.x - child.gameObject.transform.position.x) < 0.5f && Mathf.Abs(buildingPos.z - child.gameObject.transform.position.z) < 0.5f)
                    {
                        child.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                        tilePos = child.gameObject.transform.position;
                    }
                    else
                    {
                        child.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
                    }
                }
            }
        }
        else
        {
            building.transform.position = tilePos;
        }
    }

    public Coord GetCoord(int pos)
    {
        Coord coord = new Coord();
        if (pos <= allTileCoords.Capacity-1 && pos > 0)
        {
            coord = allTileCoords[pos];
        }
        else
        {
            if (pos < 0)
            {
                coord = allTileCoords[0];
            }
            if(pos > allTileCoords.Capacity - 1)
            {
                coord = allTileCoords[allTileCoords.Capacity - 1];
            }
        }
        return coord;
    }

    public struct Coord
    {
        public int x;
        public int y;

        public Coord(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }
}