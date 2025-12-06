using UnityEngine;


public class GameManager : SingletonManager<GameManager>
{

    public Unit activeUnit;
    private Vector2 touchPosition;
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

    private Vector2 GetInputPosition()
    {
        return Input.touchCount > 0 ? (Vector2)Input.GetTouch(0).position : (Vector2)Input.mousePosition;
    }

    private void DetectClick(Vector2 _inputPosition)
    {
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(_inputPosition);
        HandleClickOnGround(worldPosition);

    }

    private void HandleClickOnGround(Vector2 worldPosition)
    {
        if (activeUnit != null)
        {
            activeUnit.MoveToPosition(worldPosition);
        }
    }

}