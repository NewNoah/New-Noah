using System.Globalization;
using TMPro;
using UnityEngine;

public class LabelsController : MonoBehaviour
{
    [Header("Dog")]
    public GameObject dogName;
    public GameObject age;
    public GameObject gender;
    public GameObject weight;
    
    [Header("Stats")]
    public GameObject temperature;
    public GameObject humidity;

    private void Update()
    {
        try
        {
            temperature.GetComponent<TextMeshProUGUI>().text = Grabber.jsonClass_det.temp.ToString(CultureInfo.CurrentCulture);
            humidity.GetComponent<TextMeshProUGUI>().text = Grabber.jsonClass_det.hum.ToString(CultureInfo.CurrentCulture);
        }
        catch
        {
            Debug.Log("JSON Data not ready.");
        }
    }
}
