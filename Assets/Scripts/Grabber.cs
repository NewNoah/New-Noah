using System.Collections;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.Networking;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class Grabber : MonoBehaviour
{
    public static bool isLive = true;
    public float refreshRate = 5f;

    public static JSON_POS jsonClass_pos;
    public static JSON_DET jsonClass_det;
    private string jsonData_pos;
    private string jsonData_det;
    private string _URL;

    private UnityWebRequest _webRequest_pos;
    private UnityWebRequest _webRequest_det;

    private IEnumerator GetRequest()
    {
        
            _webRequest_pos = UnityWebRequest.Get(_URL);
            _webRequest_det = UnityWebRequest.Get("http://167.99.219.165:8080/get_room_details/1");
            // Request and wait for the desired page.
            yield return _webRequest_pos.SendWebRequest();
            yield return _webRequest_det.SendWebRequest();
            yield return new WaitForSeconds(refreshRate);
            jsonData_pos = _webRequest_pos.downloadHandler.text;
            jsonData_det = _webRequest_det.downloadHandler.text;
            jsonClass_pos = JsonUtility.FromJson<JSON_POS>(jsonData_pos);
            jsonClass_det = JsonUtility.FromJson<JSON_DET>(jsonData_det);
        
    }

    private void Start()
    {
        var coroutine = GetRequest();
        StartCoroutine(coroutine);
    }

    private void Update()
    {
        _URL = isLive ? "http://167.99.219.165:8080/get_current_pos/1" : "http://167.99.219.165:8080/get_history_pos/1";
    }
}