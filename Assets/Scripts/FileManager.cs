using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public class Data
{
    public float speed;
    public float health;
    public string fullName;
    public string base64Texture;
}
public class FileManager : MonoBehaviour
{
    private static readonly int BumpMap = Shader.PropertyToID("_BumpMap");

    [MenuItem("Tools/AddParameters")]
    public static void AddParameters()
    {
        var url = "https://dminsky.com/settings.zip";
        var outPath = Path.Combine(Application.persistentDataPath, "settings.zip");
        var outArchive = Path.Combine(Application.persistentDataPath, "outArchive");
        
        UnityWebRequest uwr = UnityWebRequest.Get(url);
        uwr.downloadHandler = new DownloadHandlerFile(outPath);
        var asyncOp = uwr.SendWebRequest();
        asyncOp.completed += (ao) =>
        {
            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log("Error!!!");
            }
            else
            {
                if (!Directory.Exists(outArchive))
                {
                    Directory.CreateDirectory(outArchive);
                } 
                if (Directory.GetFiles(outArchive).Length == 0)
                {
                    ZipFile.ExtractToDirectory(outPath,outArchive);
                }

                var temp = Directory.GetFiles(outArchive)[0].Split('/');
                var fileName = temp[temp.Length - 1];

                var dataJson = File.ReadAllText(Path.Combine(outArchive, fileName));
                var data = JsonUtility.FromJson<Data>(dataJson);
                
                var base64Texture = Convert.FromBase64String(data.base64Texture);
                var newTexture = new Texture2D(2,2);
                newTexture.LoadImage(base64Texture);

                var material = GameObject.Find("Wall").GetComponent<MeshRenderer>().sharedMaterial;
                material.SetTexture(BumpMap,newTexture);
                material.EnableKeyword("_NORMALMAP");

                Player.NewSpeed = data.speed;

            }
        };

    }

    
}
