using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour {

    public int xLocation;
    public int yLocation;

    //used for math caculations of movement
    public float zeroX;
    public float zeroY;

    public bool grabbedPiece = false;
    public GameObject theGrabbedPiece = null;

    public enum whatTypeOfPiece
    {
        Leader,
        Attacker
    }

    public whatTypeOfPiece typeOfPiece;

    public Material blue;
    public Material red;
    public Material yellow;

    public void setBlue()
    {
        this.GetComponent<Renderer>().material = blue;
    }

    public void setRed()
    {
        this.GetComponent<Renderer>().material = red;
    }

    public void setYellow()
    {
        this.GetComponent<Renderer>().material = yellow;
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

            if (isTherePiece != "empty" && grabbedPiece == false)
            {
                if(isTherePiece == "player1Leader" || isTherePiece == "player2Leader")
                {
                    if (isTherePiece == "player1Leader" && Manager.instance.whosTurn == Manager.playerTurns.Player1Turn)
                    {
                        print(isTherePiece);
                        grabbedPiece = true;
                        theGrabbedPiece = Manager.instance.boardLocation[xLocation, yLocation].GetComponent<MapLocations>().currentObject;
                        typeOfPiece = whatTypeOfPiece.Leader;
                        setYellow();
                    }

                    if (isTherePiece == "player2Leader" && Manager.instance.whosTurn == Manager.playerTurns.Player2Turn)
                    {
                        grabbedPiece = true;
                        theGrabbedPiece = Manager.instance.boardLocation[xLocation, yLocation].GetComponent<MapLocations>().currentObject;
                        typeOfPiece = whatTypeOfPiece.Leader;
                        setYellow();
                    }
                }

                if (isTherePiece == "Player1Attacker" || isTherePiece == "Player2Attacker")
                {

                }
            }else if(isTherePiece == "empty" && grabbedPiece == true)
            {
                if(typeOfPiece == whatTypeOfPiece.Leader)
                {
                    int tempX = theGrabbedPiece.GetComponent<Leaders>().xLocation;
                    int tempY = theGrabbedPiece.GetComponent<Leaders>().yLocation;
                    Manager.instance.boardLocation[tempX, tempY].GetComponent<MapLocations>().setEmpty();
                    theGrabbedPiece.GetComponent<Leaders>().setPosition(xLocation, yLocation);
                    grabbedPiece = false;
                    theGrabbedPiece = null;
                    if(Manager.instance.whosTurn == Manager.playerTurns.Player1Turn)
                    {
                        setBlue();
                    }
                    else
                    {
                        setRed();
                    }
                }
            }
        }


    }
}
