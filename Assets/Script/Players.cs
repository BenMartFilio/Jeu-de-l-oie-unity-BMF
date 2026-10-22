using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Players : MonoBehaviour
{
    private int playerID = 0;
    private int playerOrder = 0; //Ordre de lancé de dés
    public int playerPosition = 0; //Position du joueur sur le plateau

    public int playerMoney = 0;
    [SerializeField] private SO_CommonData commonDatas;
    Coroutine moveCoroutine;
    Coroutine backMoveCoroutine;
    [SerializeField] private BoardGestion boardGestion;
    [SerializeField] private DiceAndCommonThings dice;

    void Start()
    {
        StartSetup();
    }

    private void OnApplicationQuit()
    {
        commonDatas.playerDatas[playerID].isInitialized = false;
    }


    private void StartSetup()
    {
        if (commonDatas == null)
        {
            Debug.LogError("common data invalide");
            return;
        }

        if (playerID < 0 || playerID >= commonDatas.playerDatas.Length)
        {
            Debug.LogError("playerID invalide : " + playerID);
            return;
        }

        PlayerData playerData = commonDatas.playerDatas[playerID];

        if (!playerData.isInitialized)
        {
            playerOrder = dice.GetPlayers(this);

            playerData.position = playerPosition;
            playerData.order = playerOrder;
            playerData.money = playerMoney;
            playerData.isInitialized = true;
            
            commonDatas.playerDatas[playerID] = playerData;

            
        }
        else
        {
            playerPosition = playerData.position;
            playerOrder = playerData.order;
            playerMoney = playerData.money;
        }
    }

    private void EndOfGame() //à appeler à la fin du jeu ou si retour au menu pour reset les valeurs.
    {
        commonDatas.playerDatas[playerID].isInitialized = false;
    }


    public void DefineOrder(int order)
    {
        //Mettre ici l'animation d'ordre si c'est fait pas le dé etc.
        playerOrder = order;
        Debug.LogError("je suis " + playerOrder);
    }

    public void MovePlayer(Vector3 MoveTo, int NewFrameID, int numberOfMove)
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
            moveCoroutine = StartCoroutine(movement(MoveTo, NewFrameID, numberOfMove));
        }
        else
        {
            moveCoroutine = StartCoroutine(movement(MoveTo, NewFrameID, numberOfMove));
        }
    }

    public void BackMovePlayer(Vector3 MoveTo, int NewFrameID, int numberOfMove)
    {
        if (backMoveCoroutine != null)
        {
            StopCoroutine(backMoveCoroutine);
            backMoveCoroutine = StartCoroutine(backMovement(MoveTo, NewFrameID, numberOfMove));
        }
        else
        {
            backMoveCoroutine = StartCoroutine(backMovement(MoveTo, NewFrameID, numberOfMove));
        }
    }



    private IEnumerator movement(Vector3 MoveTo, int NewFrameID, int numberOfMove)
    {
        float tempsDeplacement = commonDatas.deplacementDuree;
        Vector3 StartPosition = transform.position;
        float i = 0;
        while (i < 1)
        {
            transform.position = Vector3.Lerp(StartPosition, MoveTo, i);
            i = i + Time.deltaTime / tempsDeplacement;
            yield return null;
        }
        transform.position = MoveTo;
        playerPosition = NewFrameID;
        Debug.Log(numberOfMove + "ici aussi");
        boardGestion.AddToPlayerMovement(this, numberOfMove-1);        
    }



    private IEnumerator backMovement(Vector3 MoveTo, int NewFrameID, int numberOfMove)
    {
        float tempsDeplacement = commonDatas.deplacementDuree;
        Vector3 StartPosition = transform.position;
        float i = 0;
        while (i < 1)
        {
            transform.position = Vector3.Lerp(StartPosition, MoveTo, i);
            i = i + Time.deltaTime / tempsDeplacement;
            yield return null;
        }
        transform.position = MoveTo;
        playerPosition = NewFrameID;
        Debug.Log(numberOfMove + "ici aussi");
        boardGestion.RemoveToPlayerMovement(this, numberOfMove - 1);
    }



}
