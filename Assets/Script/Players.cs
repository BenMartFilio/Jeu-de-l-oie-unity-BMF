using System;
using System.Collections;
using UnityEngine;

public class Players : MonoBehaviour
{
    private int playerOrder = 0; //Ordre de lancé de dés
    public int playerPosition = 0; //Position du joueur sur le plateau
    [SerializeField] private SO_CommonData commonDatas;
    Coroutine moveCoroutine;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DefineOrder(int order)
    {
        //Mettre ici l'animation d'ordre si c'est fait pas le dé etc.
        playerOrder = order;
        Debug.LogError("je suis " + playerOrder);
    }

    public void MovePlayer(Vector3 MoveTo, int NewFrameID)
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
            moveCoroutine = StartCoroutine(movement(MoveTo, NewFrameID));
        }
        else
        {
            moveCoroutine = StartCoroutine(movement(MoveTo, NewFrameID));
        }
    }

    private IEnumerator movement(Vector3 MoveTo, int NewFrameID)
    {
        float tempsDeplacement = commonDatas.deplacementDuree;
        Vector3 StartPosition = transform.position;
        float i = 0;
        while (i < 1)
        {
            transform.position = Vector3.Lerp(StartPosition, MoveTo, i);
            i = i + Time.deltaTime/tempsDeplacement;
            yield return null;
        }
        transform.position = MoveTo;
        playerOrder = NewFrameID;
        StopCoroutine(moveCoroutine);
    }
}
