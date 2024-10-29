using UnityEngine;

[CreateAssetMenu(fileName = "GameItemSO", menuName = "GameItem SO", order = -215)]
public class GameItemSO : ScriptableObject
{
    public Mesh mesh;
    public Material material;
    public GameItemSO weakness;
    public bool WinsOver(GameItemSO other) => other.weakness == this;
}