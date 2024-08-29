namespace World
{
    using UnityEngine;
    using UnityEngine.UI;

    public class WorldCanvas : MonoBehaviour
    {
        [SerializeField] private RawImage rawImage;
        [SerializeField] private Vector2 imageMovementSpeed;

        // Update is called once per frame
        void Update()
        {
            rawImage.uvRect = new Rect(rawImage.uvRect.position + imageMovementSpeed * Time.deltaTime,
                rawImage.uvRect.size);
        }
    }
}

