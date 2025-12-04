using UnityEngine;


public class GameManager : SingletonManager<GameManager>
{
    private Vector2 touchPosition;
    // Singleton instance
    void Update()
    {
        if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            Vector2 inputPosition = GetInputPosition();
            Debug.Log("Input detected at position: " + inputPosition);
        }
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            touchPosition = GetInputPosition();
        }

    }

    private Vector2 GetInputPosition()
    {
        return Input.touchCount > 0 ? (Vector2)Input.GetTouch(0).position : (Vector2)Input.mousePosition;
    }


}