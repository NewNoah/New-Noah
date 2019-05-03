using System.Collections;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.Networking;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class Grabber : MonoBehaviour
{
    public bool isWorking = true;
    public float refreshRate = 2f;
    
    public static JSON jsonClass;
    private string jsonData;

    private UnityWebRequest _webRequest;

    private IEnumerator GetRequest()
    {
        while (isWorking)
        {
            _webRequest = UnityWebRequest.Get("http://167.99.219.165:8080/get_current_pos/1");
            // Request and wait for the desired page.
            yield return _webRequest.SendWebRequest();
            yield return new WaitForSeconds(refreshRate);
            jsonData = _webRequest.downloadHandler.text;
            jsonClass = JsonUtility.FromJson<JSON>(jsonData);
            Debug.Log(jsonClass);
        }
    }

    private void Start()
    {
        var coroutine = GetRequest();
        StartCoroutine(coroutine);
    }
}