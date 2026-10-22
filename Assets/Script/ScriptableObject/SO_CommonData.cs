using System.Runtime.CompilerServices;
using UnityEngine;
using System;

[System.Serializable]
public struct PlayerData
{
    public int order;
    public int position;
    public bool isItMyTurn;
    public int money;
    public int[] inventory; //C'est une liste d'int, car ce sont les id qui permettent de retrouver les objets.
}

[CreateAssetMenu(fileName = "SO_CommonData", menuName = "Scriptable Objects/SO_CommonData")]
public class SO_CommonData : ScriptableObject
{
    public float deplacementDuree = 10;

    public Players[] playersList;

    public PlayerData[] playerDatas;
}
