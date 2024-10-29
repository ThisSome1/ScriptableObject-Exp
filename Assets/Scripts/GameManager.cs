using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject restartPanel;
    [SerializeField] PlaceLoader placeLoader;

    (GameItemSO p1, GameItemSO p2) selectedItems = (null, null);

    public static GameManager Instance;

    void Awake()
    {
        if (Instance)
            Destroy(Instance);
        Instance = this;
        DontDestroyOnLoad(Instance);
    }

    internal void SetItem(bool isPlayer1, GameItemSO item)
    {
        selectedItems = isPlayer1 ? (item, selectedItems.p2) : (selectedItems.p1, item);
        if (selectedItems.p1 && selectedItems.p2)
        {
            restartPanel.GetComponentInChildren<TextMeshProUGUI>().text = selectedItems.p1.WinsOver(selectedItems.p2) ? "Player 1 Won!" : (selectedItems.p2.WinsOver(selectedItems.p1) ? "Player 2 Won!" : "Draw!");
            restartPanel.SetActive(true);
        }
    }

    public void RestartGame()
    {
        placeLoader.enabled = false;
        selectedItems = (null, null);
        restartPanel.SetActive(false);
        Invoke("EnablePlaceloader", 0.1f);
    }
    void EnablePlaceloader() => placeLoader.enabled = true;

    public void QuittGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
