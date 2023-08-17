using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{
    // Save scores to a binary file.
    private void SaveScores(int[] scores)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/scores"; 
        FileStream stream = new FileStream(path, FileMode.Create); 
        formatter.Serialize(stream, scores); 
        stream.Close(); 
    }

    // Load scores from a binary file.
    private int[] LoadScores()
    {
        string path = Application.persistentDataPath + "/scores"; 
        if (File.Exists(path)) // Check if the file exists
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open); 
            int[] bestScores = formatter.Deserialize(stream) as int[]; // Deserialize and load the scores
            stream.Close(); // Close the file stream
            return bestScores;
        }
        return new int[3]; // If the file doesn't exist, return default scores
    }

    // Public method to save best scores.
    public void SaveBestScores(int[] scores)
    {
        SaveScores(scores); 
    }

    // Public method to load best scores.
    public int[] LoadBestScores()
    {
        return LoadScores(); 
    }
}