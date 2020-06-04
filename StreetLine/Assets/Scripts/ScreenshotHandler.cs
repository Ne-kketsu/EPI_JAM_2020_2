using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public string savePath = "./";
    public string fileName = "myStreetlineBoard";

    public Rect ScreenshotRect;
    private static ScreenshotHandler instance;
    private Camera myCamera;
    private bool TakeScreenshotOnNextFrame;
    private int StreetshotNbr = 1;
    private string folder;
    void Awake()
    {
        instance = this;
        myCamera = gameObject.GetComponent<Camera>();
        folder = Application.dataPath + "/Streetshots";
        System.IO.Directory.CreateDirectory(folder);
    }

    private void OnPostRender()
    {
        if (TakeScreenshotOnNextFrame) {
            TakeScreenshotOnNextFrame = false;
            RenderTexture cameraRenderTexture = myCamera.targetTexture;

            Texture2D cameraRenderResult = new Texture2D(cameraRenderTexture.width, cameraRenderTexture.height, TextureFormat.ARGB32, false);
            // Rect rect = new Rect(0, 0, cameraRenderTexture.width, cameraRenderTexture.height);
            cameraRenderResult.ReadPixels(ScreenshotRect, 0, 0);

            byte[] byteArray = cameraRenderResult.EncodeToPNG();
            string path = folder + "/StreetlineShot_" + StreetshotNbr + ".png";
            // string path = Application.dataPath + savePath + fileName + ".png";

            System.IO.File.WriteAllBytes(path, byteArray);
            Debug.Log("Board Saved ! [" + path + "]");

            RenderTexture.ReleaseTemporary(cameraRenderTexture);
            myCamera.targetTexture = null;
            StreetshotNbr += 1;
        }

    }
    private void TakeScreenshot(int width, int height)
    {
        myCamera.targetTexture = RenderTexture.GetTemporary((int)ScreenshotRect.width, (int)ScreenshotRect.height, 16);
        TakeScreenshotOnNextFrame = true;
    }
    // Update is called once per frame
    public static void TakeScreenshot_Static(int width, int height)
    {
        instance.TakeScreenshot(width, height);
    }
}
