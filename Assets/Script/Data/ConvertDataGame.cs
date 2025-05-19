using System.IO;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

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
            // Trên Android, phải dùng UnityWebRequest
            Debug.Log("Android build - bắt đầu copy bằng coroutine");
            StartCoroutine(CopyFromStreamingAssets_Android(sourcePath, targetPath));
#else
            // Trên PC, iOS, hoặc trong Editor, có thể dùng File.Copy trực tiếp
            if (File.Exists(sourcePath))
            {
                File.Copy(sourcePath, targetPath);
                Debug.Log($"[PC/iOS] Copied {fileName} to: {targetPath}");
            }
            else
            {
                Debug.LogError($"[PC/iOS] Không tìm thấy file tại: {sourcePath}");
            }
#endif
        }
        else
        {
            Debug.Log($"{fileName} đã tồn tại tại: {targetPath}");
        }
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    private IEnumerator CopyFromStreamingAssets_Android(string sourcePath, string targetPath)
    {
        string androidPath = "jar:file://" + sourcePath;

        UnityWebRequest request = UnityWebRequest.Get(androidPath);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            try
            {
                File.WriteAllBytes(targetPath, request.downloadHandler.data);
                Debug.Log($"[Android] Đã copy {fileName} vào: {targetPath}");
            }
            catch (IOException ex)
            {
                Debug.LogError($"[Android] Lỗi ghi file: {ex.Message}");
            }
        }
        else
        {
            Debug.LogError($"[Android] Không thể đọc {fileName} từ StreamingAssets: {request.error}");
        }
    }
#endif
}
