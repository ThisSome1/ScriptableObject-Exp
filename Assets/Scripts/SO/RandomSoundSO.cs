using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "RandomSoundSO", menuName = "RandomSound SO", order = -215)]
public class RandomSoundSO : ScriptableObject
{
    public AudioClip[] sounds;
    public void PlayRandom(Vector3 position) => AudioSource.PlayClipAtPoint(sounds[Random.Range(0, sounds.Length)], position);
    public void PlayNamed(Vector3 position, string name) => AudioSource.PlayClipAtPoint(sounds.Where((s) => s.name == name).First(), position);
}