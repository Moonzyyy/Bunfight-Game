using UnityEngine;
using UnityEngine.UI;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField, Range(0.1f, 5f)] float scrollSpeed;
    [SerializeField] RawImage backgroundImage;
    public bool canScroll = true;

    // Update is called once per frame
    void Update()
    {
        ScrollBackground();
    }

    private void ScrollBackground()
    {
        if (!canScroll) return;
        backgroundImage.uvRect = new Rect(backgroundImage.uvRect.position
                                          + new Vector2(scrollSpeed, 0) 
                                          * Time.deltaTime, backgroundImage.uvRect.size);
    }
}
