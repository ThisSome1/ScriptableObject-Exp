using UnityEngine;

public class GameItem : MonoBehaviour
{
#pragma warning disable IDE0044 // Add readonly modifier
    [SerializeField] RandomSoundSO soundPlayer;
#pragma warning restore IDE0044 // Add readonly modifier

    GameItemSO settings;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GameManager.Instance.SetItem(other.gameObject.name.EndsWith("1"), settings);
            other.GetComponent<PlayerController>().enabled = false;
            soundPlayer.PlayRandom(transform.position);
            Destroy(gameObject);
        }
    }

    internal void Set(GameItemSO settings)
    {
        this.settings = settings;
        GetComponent<MeshFilter>().mesh = settings.mesh;
        GetComponent<MeshRenderer>().material = settings.material;
    }

    public bool WinsOver(GameItem other) => settings.WinsOver(other.settings);
}