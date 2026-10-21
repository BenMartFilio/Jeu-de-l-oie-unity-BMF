using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class FrameScript : MonoBehaviour
{
    [SerializeField] private int OrderID = 0;
    [SerializeField] private int[] NextID; //C'est une liste, si la liste contient un seul élément alors ça avance, sinon ça donne un choix de direction au joueur
    void Start()
    {
        
    }

    public void OnPlayerInThisFrame() //Si un joueur tombe sur cette case
    {

    }

    public int ReturnFrameID()
    {
        return OrderID;
    }


    public int ReturnNextID()
    {
        if (NextID.Count() == 1)
        {
            return NextID[0];
        }
        else if (NextID.Count() > 1)
        {
            return ChoicePath();
        }
        Debug.LogError("ERREUR, nextID de la frame ID : " + OrderID + " n'est pas défini.");
        return 0;
    }

    public int ChoicePath()
    {
        //Ici, utiliser les deux next ID et proposer au joueur le choix.
        return 0;
    }
}
