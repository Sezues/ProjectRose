using UnityEngine;
using System.Collections;

public class MapLocations : MonoBehaviour {

    public float xLocation = 0;
    public float yLocation = 0;

    public GameObject currentObject;

    public enum onThis //What is on this piece
    {
        empty,
        player1Leader,
        player2Leader,
        player1Attacker,
        player2Attacker
    };

    public onThis pieceContains = onThis.empty;

    public string whatsInThis()
    {
        return pieceContains.ToString();
    }

    public void setEmpty()
    {
        pieceContains = onThis.empty;
    }

    public void setPlayer1Leader()
    {
        pieceContains = onThis.player1Leader;
    }

    public void setPlayer1Attacker()
    {
        pieceContains = onThis.player1Attacker;
    }


    public void setPlayer2Leader()
    {
        pieceContains = onThis.player2Leader;
    }

    public void setPlayer2Attacker()
    {
        pieceContains = onThis.player2Attacker;
    }


    public void setLocation(float X, float Y)
    {
        xLocation = X;
        yLocation = Y;
    }

    public float getX_Location()
    {
        return xLocation;
    }

    public float getY_Location()
    {
        return yLocation;
    }

    public void setCurrentObjectEmpty()
    {
        currentObject = null;
    }

    public void setCurrentObject(GameObject newObject)
    {
        currentObject = newObject;
    }
}
