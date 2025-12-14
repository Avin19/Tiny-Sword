using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class GameManager : SingletonManager<GameManager>
{
    [Header("UI")]
    [SerializeField] private PointToClick pointToClickPrefab;
    [SerializeField] private ActionBar actionBar;
    public Unit activeUnit;
    private Vector2 touchPosition;
    private PlacementProcess placementProcess;

    public bool IsUnitSelected => activeUnit != null;

    void Start()
    {
        ClearActionBarUI();
    }
    // Singleton instance
    void Update()
    {
        if (placementProcess != null)
        {
            placementProcess.Update();
        }
        else if (Utilis.TryGetShortClickPosition(out Vector2 inputPosition))
        {
            DetectClick(inputPosition);
        }


    }
    public void StartBuildProcess(BuildActionSO buildActionSO)
    {
        placementProcess = new PlacementProcess(buildActionSO);
        placementProcess.ShowPlacementOutline();
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



    private void DetectClick(Vector2 _inputPosition)
    {
        if (IsPointerOverUIElement()) return;
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
        if (activeUnit != null && IsHumanoid(activeUnit))
        {
            Displayeffect(worldPosition);
            activeUnit.MoveToPosition(worldPosition);
        }
    }

    private void HandleClickOnUnit(Unit unit)
    {
        if (activeUnit)
        {
            if (HasClickedOnActiveUnit(unit))
            {
                CancelActiveUnit();
                return;
            }
        }
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
        ShowUnitAction(unit);
    }

    bool HasClickedOnActiveUnit(Unit clickedUnit)
    {
        return clickedUnit == activeUnit;
    }
    bool IsHumanoid(Unit unit)
    {
        return unit is HumanoidUnit;
    }

    private void Displayeffect(Vector2 worldPoint)
    {
        Instantiate(pointToClickPrefab, (Vector3)worldPoint, Quaternion.identity);
    }

    private void CancelActiveUnit()
    {
        activeUnit = null;
        activeUnit.Deselect();


        ClearActionBarUI();


    }

    private void ShowUnitAction(Unit unit)
    {
        ClearActionBarUI();
        if (unit.Action.Length == 0)
        {
            return;
        }
        actionBar.Show();
        foreach (var action in unit.Action)
        {
            actionBar.RegisterAction(action.Icon, () => action.Execute(this));

        }

    }
    void ClearActionBarUI()
    {
        actionBar.ClearActions();
        actionBar.Hide();
    }

    bool IsPointerOverUIElement()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            return EventSystem.current.IsPointerOverGameObject(touch.fingerId);
        }
        else
        {
            return EventSystem.current.IsPointerOverGameObject();
        }
    }
}