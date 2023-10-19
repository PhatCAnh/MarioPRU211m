using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveScore : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerScore = 0;

    void OnApplicationQuit()
    {
        string path = Application.persistentDataPath + "/score.txt";
        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(playerScore);
        writer.Close();

        Debug.Log("Score saved to: " + path);
    }
}
