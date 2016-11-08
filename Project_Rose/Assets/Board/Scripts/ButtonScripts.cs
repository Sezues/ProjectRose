using UnityEngine;
using System.Collections;

public class ButtonScripts : MonoBehaviour {

    public void endTurn()
    {
        if(Manager.instance.whosTurn == Manager.playerTurns.Player1Turn)
        {
            print("Player 2 Turn");
            Manager.instance.whosTurn = Manager.playerTurns.Player2Turn;
        }
        else
        {
            print("Player 1 Turn");
            Manager.instance.whosTurn = Manager.playerTurns.Player1Turn;
        }
    }
}
