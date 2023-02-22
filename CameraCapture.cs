using UnityEngine;
using System.IO;

/// <summary>
/// 相机截图
/// </summary>
public class CameraCapture : MonoBehaviour {

    // 目标摄像机
    public Camera targetCamera;

    public string savePath;

    public int  offsetx;
    RenderTexture renderTexture;
    Texture2D texture2D;

    public void Reset() {
        renderTexture = new RenderTexture(800, 600, 32);
        texture2D = new Texture2D(800, 600, TextureFormat.ARGB32, false);
        if(targetCamera)
        {
            targetCamera.targetTexture = renderTexture ;
        }
        CreateNewFolderForScreenshots();
    }
    private void CreateNewFolderForScreenshots()
    {
        string  folderName = savePath;
        if(System.IO.Directory.Exists(folderName))
        {
            return;
        }
        System.IO.Directory.CreateDirectory(folderName); // Create the folder
    }

    public void saveAll()
    {
        Reset();
        GameObject[] objs  = GameObject.FindGameObjectsWithTag("Player");
        Rect arena = new Rect(0,0,800,600);
        for (int i =0 ;i < objs.Length;i++ )
        {
            targetCamera.transform.position = new Vector3(objs[i].transform.position.x,objs[i].transform.position.y,objs[i].transform.position.z-5);
            Debug.Log(targetCamera.transform.position);
            saveCapture(objs[i].name);
        }
    }
    public void  saveCapture(string name)
    {
        targetCamera.Render();
        RenderTexture.active = renderTexture;
        texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture2D.Apply();
        RenderTexture.active = null;
        byte[] bytes = texture2D.EncodeToPNG();
        string path =  string.Format("{0}/{1}.png",savePath,name);
        File.WriteAllBytes(path, bytes);
        Debug.Log("save file:"+path);
    }

    public void sortPlayer()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        for (int i =0 ;i<gos.Length;i++ )
        {         
            gos[i].transform.position = new Vector3(i*offsetx,0,0);
        }
    }

}