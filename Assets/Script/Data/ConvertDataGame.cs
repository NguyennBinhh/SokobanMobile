using System.IO;
using UnityEngine;

public class ConvertDataGame : MonoBehaviour
{
    private string fileName = "LevelData.json";

    void Awake()
    {
        string targetPath = Path.Combine(Application.persistentDataPath, fileName);

        if (!File.Exists(targetPath))
        {
            string sourcePath = Path.Combine(Application.streamingAssetsPath, fileName);

#if UNITY_ANDROID && !UNITY_EDITOR
            // Đọc dạng WWW trên Android
            StartCoroutine(CopyFromStreamingAssets_Android(sourcePath, targetPath));
#else
            // PC, Editor, iOS
            if (File.Exists(sourcePath))
            {
                File.Copy(sourcePath, targetPath);
                Debug.Log("Copied default level data to persistent path.");
            }
#endif
        }
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    private IEnumerator CopyFromStreamingAssets_Android(string sourcePath, string targetPath)
    {
        UnityEngine.Networking.UnityWebRequest request = UnityEngine.Networking.UnityWebRequest.Get(sourcePath);
        yield return request.SendWebRequest();

        if (request.result == UnityEngine.Networking.UnityWebRequest.Result.Success)
        {
            File.WriteAllBytes(targetPath, request.downloadHandler.data);
            Debug.Log("Copied default level data to persistent path (Android).");
        }
        else
        {
            Debug.LogError("Failed to copy default data: " + request.error);
        }
    }
#endif
}