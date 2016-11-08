using UnityEngine;
using System.Collections;

public class ButtonScripts : MonoBehaviour {

    public void endTurn()
    {
        if(Manager.instance.whosTurn == Manager.playerTurns.Player1Turn)
        {
            print("Player 2 Turn");
            Manager.instance.whosTurn = Manager.playerTurns.Player2Turn;
            Manager.instance.selector.GetComponent<Selector>().setPosition(
                                                               Manager.instance.player2Leader.GetComponent<Leaders>().xLocation,
                                                               Manager.instance.player2Leader.GetComponent<Leaders>().yLocation);
            Manager.instance.selector.GetComponent<Selector>().setRed();
        }
        else
        {
            print("Player 1 Turn");
            Manager.instance.whosTurn = Manager.playerTurns.Player1Turn;
            Manager.instance.selector.GetComponent<Selector>().setPosition(
                                                   Manager.instance.player1Leader.GetComponent<Leaders>().xLocation,
                                                   Manager.instance.player1Leader.GetComponent<Leaders>().yLocation);
            Manager.instance.selector.GetComponent<Selector>().setBlue();

        }
    }
}
