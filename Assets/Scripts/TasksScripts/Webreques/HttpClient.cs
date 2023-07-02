using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class HttpClient
{
    private readonly string _url;
    private readonly List<RequestHeaderData> _request;

    private UnityWebRequest _webRequest;

    public HttpClient(string url, List<RequestHeaderData> request)
    {
        _url = url;
        _request = request;
    }

    public async Task<T> Get<T>()
    {
        using var webRequest = UnityWebRequest.Get(_url);

        SetHeadData(webRequest);

        var operation = webRequest.SendWebRequest();

        while (!operation.isDone)
            await Task.Yield();

        return GetRequestResultHandler<T>(webRequest);
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