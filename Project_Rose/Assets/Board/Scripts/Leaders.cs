using UnityEngine;
using System.Collections;

public class Leaders : MonoBehaviour {

    public int xLocation;
    public int yLocation;

    //used for math caculations of movement
    public float zeroX;
    public float zeroY;

    public int startX;
    public int startY;

    public enum whichLeader
    {
        Player1,
        Player2
    }

    public whichLeader whichPlayer;

    public void setPosition(int X, int Y)
    {
        xLocation = X;
        yLocation = Y;

        print("X Location: " + xLocation + " Y Location" + yLocation);
        transform.position = new Vector3(zeroX + (xLocation * Manager.instance.mapPieceOffset), zeroY + (yLocation * Manager.instance.mapPieceOffset), -11);

        if (whichPlayer == whichLeader.Player1)
        {
            Manager.instance.boardLocation[xLocation, yLocation].GetComponent<MapLocations>().setPlayer1Leader();
        }
        else
        {
            Manager.instance.boardLocation[xLocation, yLocation].GetComponent<MapLocations>().setPlayer2Leader();
        }

        Manager.instance.boardLocation[xLocation, yLocation].GetComponent<MapLocations>().setCurrentObject(this.gameObject);
    }

    // Use this for initialization
    void Start () {
        setPosition(startX, startY);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
