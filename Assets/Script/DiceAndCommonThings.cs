using System;
using System.Collections.Generic;
using UnityEngine;

public class DiceAndCommonThings : MonoBehaviour
{
    private Players[] players; //référence des joueurs 
    private Dictionary<int, Players> playersAndOrder = new Dictionary<int, Players>();
    [SerializeField] private SO_CommonData commonDatas;
    [SerializeField] private BoardGestion boardGestion;

    void Start()
    {
        GetAllPlayers();
    }

    private void GetAllPlayers()
    {
        players = FindObjectsByType<Players>(FindObjectsSortMode.None); //Récupère toute la liste de joueur
        commonDatas.playersList = players;
        Debug.Log(players.Length); //Debug publiant le nombre de joueurs en jeu
        DefinePlayersOrder();
    }


    private void DefinePlayersOrder()
    {
        int i = 1;
        foreach (var player in players)
        {
            OrderDefinitionEvent(player, i);
            i++;
        }
    }


    private void OrderDefinitionEvent(Players player, int order)
    {
        player.DefineOrder(order);
        playersAndOrder.Add(order, player);
    }



    public void ThrowDice(int playerOrderID, int numberFaceOfDice = 6) //Avec l'id du joueur à qui lancer et le nombre de face du dé à tirer
    {
        int diceResult = UnityEngine.Random.Range(1, numberFaceOfDice);
        Debug.LogError("Le dé renvoie : " + diceResult);

        //Utiliser cet évènement pour mettre l'ordre de jeu. Utiliser une liste, si deux joueurs font le même lancé, le premier passe avant
        MoveOnBoard(diceResult, playerOrderID);
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
            ThrowDice(1,6);
        }

    }
}
