using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject map;
    public GameObject pin;

    private float _mapWidth;
    private float _mapHeight;
    
    private float _x;
    private float _y;

    private void Start()
    {
        //TODO получать ширину элемента из кода
        _mapWidth = 218f;
        _mapHeight = 198f;
        
        InvokeRepeating(nameof(DebugLog), 0, 1f);
    }

    private void Update()
    {
        try
        {
            _x = Grabber.jsonClass_pos.x_val;
            _y = Grabber.jsonClass_pos.y_val;
        }
        catch
        {
            Debug.Log("JSON Data not ready.");
        }
   
        pin.GetComponent<RectTransform>().anchoredPosition = new Vector3(_mapWidth * _x, _mapHeight * _y);
    }
    
    private void DebugLog()
    {
        Debug.Log("X: " + _x + " Y: " + _y);
    }
    
}
