using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audioSource {  get; private set; }
    [field: SerializeField] public AudioClip rightAnswerSound { get; private set; }
    [field: SerializeField] public AudioClip wrongAnswerSound { get; private set; }
    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }
}
