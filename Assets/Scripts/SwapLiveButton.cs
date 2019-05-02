using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SwapLiveButton : MonoBehaviour
{
    public Sprite liveOnSprite;
    public Sprite liveOffSprite;
    public GameObject isLiveText;

    private bool _isLive;

    public void SwapButtonSprite(GameObject button)
    {
        _isLive = !_isLive;
        button.GetComponent<Image>().sprite = _isLive ? liveOnSprite : liveOffSprite;
        isLiveText.GetComponent<TextMeshProUGUI>().text = _isLive ? "Live" : "History";
    }
}