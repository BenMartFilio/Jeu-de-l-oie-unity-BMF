using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DiceAndCommonThings : MonoBehaviour
{
    private Dictionary<int, Players> playersAndOrder = new Dictionary<int, Players>(); //Référence des joueurs
    [SerializeField] private SO_CommonData commonDatas;
    [SerializeField] private BoardGestion boardGestion;
    private int nextPlayerOrder = 1;
    private int orderIncrement = 0;


    void Start()
    {
        OnLoadLevel();
    }

    private void OnLoadLevel()
    {
        for (int i = 0; i < commonDatas.playerDatas.Length; i++) 
        {
            if (commonDatas.playerDatas[i].isItMyTurn)
            {
                nextPlayerOrder = i;
                commonDatas.playerDatas[i].isItMyTurn = false;
                break;
            }
            
        }
    }


    public int GetPlayers(Players player)
    {
        int order = orderIncrement = orderIncrement+1;
        player.DefineOrder(order);
        playersAndOrder.Add(order, player);
        return order;
    }


    public void ThrowDice(int playerOrderID, int numberFaceOfDice = 6) //Avec l'id du joueur à qui lancer et le nombre de face du dé à tirer
    {
        int diceResult = UnityEngine.Random.Range(1, numberFaceOfDice);
        Debug.LogError("Le dé renvoie : " + diceResult);

        //Utiliser cet évènement pour mettre l'ordre de jeu. Utiliser une liste, si deux joueurs font le même lancé, le premier passe avant
        MoveOnBoard(diceResult, playerOrderID);
        nextPlayerOrder = Math.Max((nextPlayerOrder +1)%(playersAndOrder.Count+1),1);
    }


    public void MoveOnBoard(int numberOfMove, int playerOrderID)
    {
        boardGestion.AddToPlayerMovement(playersAndOrder[playerOrderID], numberOfMove);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Dé lancé");
            ThrowDice(nextPlayerOrder,6);
        }

    }
}
