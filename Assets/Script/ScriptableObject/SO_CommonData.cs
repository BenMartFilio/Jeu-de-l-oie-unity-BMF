using System.Runtime.CompilerServices;
using UnityEngine;
using System;
using Unity.VisualScripting;

[System.Serializable]
public struct PlayerData
{
    public int order;
    public int position;
    public bool isItMyTurn;
    public int money;
    public int[] inventory; //C'est une liste d'int, car ce sont les id qui permettent de retrouver les objets.

    public bool isInitialized;
}


public enum FrameEvent
{
    NoEffect,
    LoseMoney,
    EarnMoney,
    MoveForward,
    MoveBackward,
    Teleport,
    Shop,
    AleaEvent,
    MiniGameFrame
}

[System.Serializable]
public class FrameType
{
    public FrameEvent type;
    public int colorID;
    public int value; //Valeur lié à certain FrameEvent, il faut l'utiliser pour les perte d'argent par exemple, ou les déplacements de cases. Sauf si vous faites de l'aléatoire pour ça
}

[CreateAssetMenu(fileName = "SO_CommonData", menuName = "Scriptable Objects/SO_CommonData")]
public class SO_CommonData : ScriptableObject
{
    public float deplacementDuree = 10;

    public Players[] playersList;

    public PlayerData[] playerDatas;

}
