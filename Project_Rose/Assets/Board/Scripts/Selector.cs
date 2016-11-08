using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour {

    public int xLocation;
    public int yLocation;

    //used for math caculations of movement
    public float zeroX;
    public float zeroY;

    private bool grabbedPiece = false;

    public Material blue;
    public Material red;

    public void setBlue()
    {
        this.GetComponent<Renderer>().material = blue;
    }

    public void setRed()
    {
        this.GetComponent<Renderer>().material = red;
    }

    public void setPosition(int X, int Y)
    {
        xLocation = X;
        yLocation = Y;

        print("X Location: " + xLocation + " Y Location" + yLocation);
        transform.position = new Vector3 (zeroX + (xLocation * Manager.instance.mapPieceOffset), zeroY + (yLocation * Manager.instance.mapPieceOffset),-11);
    }

    // Update is called once per frame
    void Update () {
	    if(Input.GetKeyDown(KeyCode.W) && yLocation < Manager.instance.mapRows-1)
        {
            setPosition(xLocation, yLocation + 1);
        }

        if (Input.GetKeyDown(KeyCode.A) && xLocation >0)
        {
            setPosition(xLocation -1, yLocation);
        }

        if (Input.GetKeyDown(KeyCode.S) && yLocation >0)
        {
            setPosition(xLocation, yLocation - 1);
        }

        if (Input.GetKeyDown(KeyCode.D) && xLocation < Manager.instance.mapCollumns-1)
        {
            setPosition(xLocation +1, yLocation);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            print("This piece contains " + Manager.instance.boardLocation[xLocation, yLocation].GetComponent<MapLocations>().whatsInThis());
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            string isTherePiece = Manager.instance.boardLocation[xLocation, yLocation].GetComponent<MapLocations>().whatsInThis();

            if(isTherePiece != "empty")
            {
                if(isTherePiece == "Player1Leader" || isTherePiece == "Player2Leader")
                {

                }

                if (isTherePiece == "Player1Attacker" || isTherePiece == "Player2Attacker")
                {

                }
            }
        }


    }
}
