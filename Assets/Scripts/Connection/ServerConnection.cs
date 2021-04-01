using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class ServerConnection : MonoBehaviour
{
    public static ServerConnection Instance = null;
    public bool prod = false;
    public string URL_LOCAL = "http://localhost/goo/main.php";
    public string URL_PROD = "https://gooplatform.com.br/main.php";
    private string URL = "";
    private void Awake()
    {
        if (ServerConnection.Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);

        URL = prod ? URL_PROD : URL_LOCAL;
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public Coroutine Post(string data, Action<DefaultResponse> callback)
    {
        return StartCoroutine(Post(URL, data, callback));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.LogError(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
            }
        }
    }

    IEnumerator Post(string uri, string logindataJsonString, Action<DefaultResponse> callback)
    {
        var request = new UnityWebRequest(uri, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(logindataJsonString);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.error != null)
        {
            Debug.LogError("Error: " + request.error);
        }
        else
        {
            Debug.Log(request.downloadHandler.text);
            DefaultResponse response = JsonUtility.FromJson<DefaultResponse>(request.downloadHandler.text);
            callback(response);
        }
    }
}