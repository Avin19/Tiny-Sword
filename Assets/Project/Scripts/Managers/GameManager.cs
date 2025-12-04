using UnityEngine;


public class GameManager : SingletonManager<GameManager>
{
    // Singleton instance

    public void Test()
    {
        Debug.Log("GameManager is working!");
    }

}