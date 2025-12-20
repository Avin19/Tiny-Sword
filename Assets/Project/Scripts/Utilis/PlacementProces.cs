

using UnityEngine;

public class PlacementProcess
{
    private GameObject placementOutline;
    private BuildActionSO _buildActionSO;
    public PlacementProcess(BuildActionSO buildActionSO)
    {
        _buildActionSO = buildActionSO;
    }

    public void Update()
    {
        if (Utilis.TryGetHoldPosition(out Vector3 worldPosition))
        {
            placementOutline.transform.position = new Vector3(worldPosition.x, worldPosition.y, 0f);

        }


    }
    public void ShowPlacementOutline()
    {
        placementOutline = new GameObject("PlacementOutline");
        var renderer = placementOutline.AddComponent<SpriteRenderer>();
        renderer.sortingOrder = 99;
        renderer.color = new Color(1, 1, 1, 0.5f);
        renderer.sprite = _buildActionSO.PlacementSprite;

    }
}