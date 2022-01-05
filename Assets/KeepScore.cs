using UnityEngine;

public class KeepScore : MonoBehaviour
{
    public static int Score = 0;
    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 120, 140), "Use Controls: \n W - up \n S - down \n D - right \n A - left \n\nScore" + "\n" + Score.ToString());
    }
}
