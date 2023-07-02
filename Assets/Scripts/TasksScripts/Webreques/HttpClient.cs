using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class HttpClient : MonoBehaviour
{
    private string _url;
    private List<RequestHeaderData> _request;

    private UnityWebRequest _webRequest;
    
    public delegate void OnDataReceivedEventHandler(string data);
    public event OnDataReceivedEventHandler DataReceivedEvent;

    public void InsertData(string url, List<RequestHeaderData> request)
    {
        _url = url;
        _request = request;
    }

    public void Get<T>()
    {
        StartCoroutine(GetData<T>());
    }

    public void Post<T>(T input)
    {
        StartCoroutine(PostData<T>(input));
    }

    private IEnumerator GetData<T>()
    {
        using var webRequest = UnityWebRequest.Get(_url);
        yield return webRequest.SendWebRequest();

        var pages = _url.Split('/');
        var page = pages.Length - 1;
        
        switch (webRequest.result)
        {
            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.DataProcessingError:
                Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                break;
            case UnityWebRequest.Result.ProtocolError:
                Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                break;
            case UnityWebRequest.Result.Success:
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                DataReceivedEvent?.Invoke(webRequest.downloadHandler.text);
                break;
        }
    }
    
    private IEnumerator PostData<T>(T input)
    {
        var json = JsonUtility.ToJson(input);

        using var request = UnityWebRequest.Post(_url, json);
        
        yield return request.SendWebRequest();
    
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log($"Form upload complete! {request.downloadHandler.text}");
        }
    }
    

    private T GetRequestResultHandler<T>(UnityWebRequest webRequest)
    {
        if (webRequest.result != UnityWebRequest.Result.Success)
            Debug.Log($"Failed: {webRequest.error}");

        var jsonResponse = webRequest.downloadHandler.text;

        try
        {
            var result = JsonUtility.FromJson<T>(jsonResponse);
            Debug.Log($"Success: {webRequest.downloadHandler.text}");
            return result;
        }
        catch (Exception)
        {
            Debug.Log($"Failed: {webRequest.error}");
        }

        return default;
    }
    private void SetHeadData(UnityWebRequest web)
    {
        foreach (var data in _request)
            web.SetRequestHeader(data._name, data._value);
    }
}