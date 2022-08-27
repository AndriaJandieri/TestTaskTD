using UnityEngine;

public class ScaleToFitScreen : MonoBehaviour
{
    public SpriteRenderer backgroundToFit;

    private void Start()
    {

        float worldScreenHeight = Camera.main.orthographicSize * 2;

        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        transform.localScale = new Vector3(
            worldScreenWidth / backgroundToFit.sprite.bounds.size.x,
            worldScreenHeight / backgroundToFit.bounds.size.y, 1);
    }

}