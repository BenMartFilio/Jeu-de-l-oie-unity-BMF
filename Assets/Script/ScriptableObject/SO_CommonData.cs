using UnityEngine;

[CreateAssetMenu(fileName = "SO_CommonData", menuName = "Scriptable Objects/SO_CommonData")]
public class SO_CommonData : ScriptableObject
{
    public float deplacementDuree = 10;

    public Players[] playersList;
}
