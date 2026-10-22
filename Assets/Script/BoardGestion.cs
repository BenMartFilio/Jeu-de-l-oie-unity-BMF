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
        if (numberOfMove > 0) //A refaire et à finir, il faut faire que ceci se passe uniquement après que le joueut ait fini le premier déplacement
        {
            int actualPosition = player.playerPosition;
            int positionToMove = frameInThisLevel[actualPosition].ReturnNextID();
            MovePlayers(player, positionToMove, numberOfMove);
        }
        return;
    }


    public void MovePlayers(Players player, int IDFrame, int numberOfMove)
    {
        Vector3 position = frameInThisLevel[IDFrame].transform.position;
        player.MovePlayer(position, IDFrame, numberOfMove);
    }
}
