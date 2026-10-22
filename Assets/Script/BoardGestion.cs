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
        Debug.Log("numberofmove" + numberOfMove);
        if (numberOfMove > 0) //A refaire et à finir, il faut faire que ceci se passe uniquement après que le joueur ait fini le premier déplacement
        {
            int actualPosition = player.playerPosition;
            int positionToMove = frameInThisLevel[actualPosition].ReturnNextID();
            MovePlayers(player, positionToMove, numberOfMove);
        }
        else
        {
            int actualPosition = player.playerPosition;
            OnPlayerOnFrame(frameInThisLevel[actualPosition].eventType); //Appel pour évènement des cases
        }
    }


    public void MovePlayers(Players player, int IDFrame, int numberOfMove)
    {
        Vector3 position = frameInThisLevel[IDFrame].transform.position;
        player.MovePlayer(position, IDFrame, numberOfMove);
    }


    private void OnPlayerOnFrame(FrameType frameType)
    {
        DoEvent(frameType);
    }


    public void DoEvent(FrameType frameType)
    {
        switch (frameType.type)
        {
            case FrameEvent.EarnMoney:
                EarnMoney(frameType.value);
                break;
            case FrameEvent.LoseMoney:
                LoseMoney(frameType.value);
                break;
            case FrameEvent.MiniGameFrame:
                MiniGameFrame();
                break;
            case FrameEvent.Shop:
                Shop();
                break;
            case FrameEvent.Teleport:
                Teleport(frameType.value);
                break;
            case FrameEvent.MoveForward:
                MoveForward(frameType.value);
                break;
            case FrameEvent.MoveBackward:
                MoveBackward(frameType.value);
                break;
            case FrameEvent.AleaEvent:
                AleaEvent();
                break;
            case FrameEvent.NoEffect:
                NoEffect();
                break;
        }
    }

    private void EarnMoney(int montant)
    {

    }

    private void LoseMoney(int montant)
    {

    }

    private void MiniGameFrame() 
    { 

    }


    private void Shop()
    {

    }

    private void Teleport(int frameID)
    {

    }

    private void MoveForward(int numberOfMove)
    {

    }

    private void MoveBackward(int numberofMove)
    {

    }


    private void AleaEvent()
    {

    }


    private void NoEffect()
    {

    }
}
