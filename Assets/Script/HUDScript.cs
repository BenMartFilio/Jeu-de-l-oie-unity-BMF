using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HUDScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textPlayer1;
    [SerializeField] private TextMeshProUGUI textPlayer2;
    [SerializeField] private TextMeshProUGUI textPlayer3;
    [SerializeField] private TextMeshProUGUI textPlayer4; //Ajouter autant de variable que de joueur max

    public TextMeshProUGUI ReturnGoodText(int order)
    {
        switch (order)
        {
            case 1: return textPlayer1;
            case 2: return textPlayer2;
            case 3: return textPlayer3;
            case 4: return textPlayer4;
        }
        return null;
    }
}
