using UnityEngine;

public class KeepScore : MonoBehaviour
{
    public static int Score = 0;

    void OnGUI()
    {
        int level = (Score / 50) + 1;
        GUI.Box(new Rect(10, 10, 150, 200), "Use Controls: \n W - up \n S - down \n D - right \n A - left \n\n You can also use\nthe arrow keys" +
            "\n\nLevel: " + level.ToString() + "\n\nScore: \n" + Score.ToString());
       
        Time.fixedDeltaTime = 0.1f / level;
    }
}
