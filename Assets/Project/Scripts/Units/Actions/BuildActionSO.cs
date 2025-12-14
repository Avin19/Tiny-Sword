using UnityEngine;
[CreateAssetMenu(fileName = "BuildActionSO", menuName = "ActionSO/BuildAction", order = 0)]
public class BuildActionSO : ActionSO
{
    [Header(" Images")]
    [SerializeField] private Sprite placementSprite;
    [SerializeField] private Sprite foundationSprite;
    [SerializeField] private Sprite completionSprite;
    [Header("Resource ")]
    [SerializeField] private int goldCost;
    [SerializeField] private int woodCost;

    public Sprite PlacementSprite => placementSprite;
    public Sprite FoundationSprite => foundationSprite;
    public Sprite ComletionSprite => completionSprite;

    public int GoldCost => goldCost;
    public int WoodCost => woodCost;
    public override void Execute(GameManager gameManager)
    {

    }
}