using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour //we don't need to make billion of Audio sources, when we can make only one
                                          //but it would be better if we had an "Audio mixer".
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
