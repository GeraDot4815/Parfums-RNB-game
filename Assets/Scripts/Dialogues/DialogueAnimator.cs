using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Image))]
public class DialogueAnimator : MonoBehaviour
{
    [field:SerializeField] public Sprite defSprite { get; private set; }
    public const string showTrigger = "showing";
    public const string hideTrigger = "hiding";
    public Animator animator { get; private set; }
    public Image sourseImg { get; private set; }
    private void Awake()
    {
        animator = GetComponent<Animator>();
        sourseImg = GetComponent<Image>();
    }
    public void OnHideOver()
    {
        sourseImg.sprite = null;
    }
}
