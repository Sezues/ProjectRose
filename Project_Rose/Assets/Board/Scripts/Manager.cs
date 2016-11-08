using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {
    public static Manager instance = null; // instance variable
    private bool managerReady = false; // checks to see if everything is loaded. 

    public int mapCollumns;
    public int mapRows;

    public float mapPieceStartX; //starting X position of map at X
    public float mapPieceStartY; //starting Y position of map at Y
    public float mapPieceOffset; //scale size

    public GameObject[,] boardLocation; //holds the object at the location

    public GameObject mapPiece; //prefab

    public enum playerTurns
    {
        Player1Turn,
        Player2Turn
    }

    public playerTurns whosTurn = playerTurns.Player1Turn;

    // Use this for initialization
    void Awake () {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        setup();
        managerReady = true;
    }

    private void setup()
    {
        initializeArray();
        loadMap();  
    }

    private void initializeArray()
    {
        boardLocation = new GameObject[mapCollumns, mapRows];
    }
    private void loadMap()
    {
        for (int i = 0; i < mapCollumns; i++)
        {
            for (int j = 0; j < mapRows; j++)
            {
                GameObject tempObject;
                tempObject = (GameObject)Instantiate(mapPiece, new Vector3((mapPieceStartX) +(i* mapPieceOffset), (mapPieceStartY)+(j*mapPieceOffset), -10), Quaternion.identity);
                tempObject.GetComponent<MapLocations>().setLocation(i, j);
                tempObject.GetComponent<MapLocations>().setEmpty();
                boardLocation[i,j] = tempObject;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	    if(managerReady)
        {

        }
	}
}
