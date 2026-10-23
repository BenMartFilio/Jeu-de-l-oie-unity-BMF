using System.Collections.Generic;
using UnityEngine;

public class BoardGestion : MonoBehaviour
{
    private Dictionary<int, FrameScript> frameInThisLevel= new Dictionary<int, FrameScript>();
    private FrameScript[] frames;
    void Start()
    {
        GetAllFrames();   
    }

    private void GetAllFrames()
    {
        frames = FindObjectsByType<FrameScript>(FindObjectsSortMode.None); //Une seule fois au départ, c'est un coût acceptable
        DefineBoard();
    }

    private void DefineBoard()
    {
        foreach (var frame in frames)
        {
            if (!frameInThisLevel.TryAdd(frame.ReturnFrameID(), frame))
            {
                Debug.LogWarning("Deux cases ont le même ID.");
            }
            Debug.Log(frameInThisLevel);
        }
    }


    public void AddToPlayerMovement(Players player, int numberOfMove)
    {
        if (numberOfMove > 0)
        {
            int actualPosition = player.playerPosition;
            int positionToMove = frameInThisLevel[actualPosition].ReturnNextID();
            MovePlayers(player, positionToMove, numberOfMove);
        }
        else
        {
            int actualPosition = player.playerPosition;
            OnPlayerOnFrame(frameInThisLevel[actualPosition].eventType, player); //Appel pour évènement des cases
        }
    }

    public void RemoveToPlayerMovement(Players player, int numberOfMove)
    {
        if (numberOfMove > 0)
        {
            int actualPosition = player.playerPosition;
            int positionToMove = frameInThisLevel[actualPosition].ReturnLastID();
            BackMovePlayers(player, positionToMove, numberOfMove);
        }
        else
        {
            int actualPosition = player.playerPosition;
            OnPlayerOnFrame(frameInThisLevel[actualPosition].eventType, player); //Appel pour évènement des cases
        }
    } 


    public void MovePlayers(Players player, int IDFrame, int numberOfMove)
    {
        Vector3 position = frameInThisLevel[IDFrame].transform.position;
        player.MovePlayer(position, IDFrame, numberOfMove);
    }

    public void BackMovePlayers(Players player, int IDFrame, int numberOfMove)
    {
        Vector3 position = frameInThisLevel[IDFrame].transform.position;
        player.BackMovePlayer(position, IDFrame, numberOfMove);
    }


    private void OnPlayerOnFrame(FrameType frameType, Players player)
    {
        DoEvent(frameType, player);
    }


    public void DoEvent(FrameType frameType, Players player) //Switch entre les events des cases, qui appelle leur fonction correspondantes, suivre le même fonctionnement pour en ajouter d'autre.
    {
        switch (frameType.type)
        {
            case FrameEvent.EarnMoney:
                EarnMoney(frameType.value, player);
                break;
            case FrameEvent.LoseMoney:
                LoseMoney(frameType.value, player);
                break;
            case FrameEvent.MiniGameFrame:
                MiniGameFrame(player);
                break;
            case FrameEvent.Shop:
                Shop(player);
                break;
            case FrameEvent.Teleport:
                Teleport(frameType.value, player);
                break;
            case FrameEvent.MoveForward:
                MoveForward(frameType.value, player);
                break;
            case FrameEvent.MoveBackward:
                MoveBackward(frameType.value, player);
                break;
            case FrameEvent.AleaEvent:
                AleaEvent(player);
                break;
            case FrameEvent.NoEffect:
                NoEffect(player);
                break;
        }
    }

    private void EarnMoney(int montant, Players player)
    {
        player.playerMoney = Mathf.Clamp(player.playerMoney + montant, 0, 200000000);
    }

    private void LoseMoney(int montant, Players player)
    {
        player.playerMoney = Mathf.Clamp(player.playerMoney - montant, 0, 200000000);
        player.MoneyChange();
    }

    private void MiniGameFrame(Players player) 
    { 
        //Faire évènement mini jeu ici
    }


    private void Shop(Players player)
    {
        //Faire évènement shop ici
    }

    private void Teleport(int frameID, Players player)
    {
        //Faire évènement teleport ici
    }

    private void MoveForward(int numberOfMove, Players player)
    {
        AddToPlayerMovement(player, numberOfMove);
    }

    private void MoveBackward(int numberofMove, Players player)
    {
        RemoveToPlayerMovement(player, numberofMove);
    }


    private void AleaEvent(Players player)
    {

    }


    private void NoEffect(Players player)
    {

    }
}
