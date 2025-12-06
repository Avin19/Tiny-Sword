using UnityEngine;


public class GameManager : SingletonManager<GameManager>
{
    [Header("UI")]
    [SerializeField] private PointToClick pointToClickPrefab;
    public Unit activeUnit;
    private Vector2 touchPosition;

    public bool IsUnitSelected => activeUnit != null;
    // Singleton instance
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            touchPosition = GetInputPosition();
        }
        if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            Vector2 inputPosition = GetInputPosition();
            if (Vector2.Distance(touchPosition, inputPosition) < 10f) // Threshold for click detection
            {

                DetectClick(inputPosition);
            }

        }

    }
    private bool HasClickedOnUnit(RaycastHit2D hit, out Unit _unit)
    {
        if (hit.collider != null && hit.collider.TryGetComponent<Unit>(out var unit))
        {
            _unit = unit;
            return true;
        }
        _unit = null;
        return false;
    }

    private Vector2 GetInputPosition()
    {
        return Input.touchCount > 0 ? (Vector2)Input.GetTouch(0).position : (Vector2)Input.mousePosition;
    }

    private void DetectClick(Vector2 _inputPosition)
    {
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(_inputPosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);
        if (HasClickedOnUnit(hit, out var unit))
        {
            HandleClickOnUnit(unit);
            return;
        }
        else
        {

            HandleClickOnGround(worldPosition);
        }

    }

    private void HandleClickOnGround(Vector2 worldPosition)
    {
        Displayeffect(worldPosition);
        if (activeUnit != null)
        {
            activeUnit.MoveToPosition(worldPosition);
        }
    }

    private void HandleClickOnUnit(Unit unit)
    {
        SelectNewUnit(unit);
    }

    private void SelectNewUnit(Unit unit)
    {
        if (IsUnitSelected)
        {
            activeUnit.Deselect();
        }
        activeUnit = unit;
        activeUnit.Select();
    }

    private void Displayeffect(Vector2 worldPoint)
    {
        Instantiate(pointToClickPrefab, (Vector3)worldPoint, Quaternion.identity);
    }

}