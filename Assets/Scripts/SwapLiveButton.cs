using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SwapLiveButton : MonoBehaviour
{
    public Sprite liveOnSprite;
    public Sprite liveOffSprite;
    public GameObject isLiveText;

    public void SwapButtonSprite(GameObject button)
    {
        Grabber.isLive = !Grabber.isLive;
        button.GetComponent<Image>().sprite = Grabber.isLive ? liveOnSprite : liveOffSprite;
        isLiveText.GetComponent<TextMeshProUGUI>().text = Grabber.isLive ? "Live" : "History";
    }
}