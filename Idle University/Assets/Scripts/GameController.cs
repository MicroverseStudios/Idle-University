using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject path; //path plane object
	// Use this for initialization
	void Start () {
		
	}
	
	void Update () {
        //first touch and one finger on screen
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //casts ray from touch point
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            //if the ray hits a collider and is a tile
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.CompareTag("Tile"))
            {
                //if the tile isn't already occupied
                if (!hit.collider.gameObject.GetComponent<TileOccupied>().Occupied)
                {
                    //spawn path square at that position
                    GameObject Path = Instantiate(path, hit.collider.gameObject.transform.position, Quaternion.identity);
                    Path.transform.position += new Vector3(0f, 0.01f, 0f);
                    hit.collider.gameObject.GetComponent<TileOccupied>().Occupied = true;
                }
            }
        }
        //if one finger on screen has moved
        else if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            //cast ray and spawn path at position if hits a tile and it isn't occupied
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.CompareTag("Tile"))
            {
                if (!hit.collider.gameObject.GetComponent<TileOccupied>().Occupied)
                {
                    GameObject Path = Instantiate(path, hit.collider.gameObject.transform.position, Quaternion.identity);
                    Path.transform.position += new Vector3(0f, 0.01f, 0f);
                    hit.collider.gameObject.GetComponent<TileOccupied>().Occupied = true;
                }
            }
        }
    }
}
