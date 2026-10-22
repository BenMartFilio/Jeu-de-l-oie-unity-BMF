using UnityEngine;

[CreateAssetMenu(fileName = "SO_ColorIndex", menuName = "Scriptable Objects/SO_ColorIndex")]
public class SO_ColorIndex : ScriptableObject
{
    public Color[] colourTable = new Color[3] {Color.red, Color.blue, Color.green}; 
}
