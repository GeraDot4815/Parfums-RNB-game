using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(Image))]
[System.Serializable]
public class DialogueGraphics
{
    [field: SerializeField] public Sprite sprite =null;
    [HideInInspector] public DialogueAnimator anim;
    protected void Start()
    {
        Hide(usefade: false);
        //if(sprite==null) sprite = anim.defSprite;
    }
    public virtual void Show(bool usefade=true)
    {
        Debug.Log("Show");
        anim.sourseImg.sprite = sprite;
        if (usefade) anim.animator.SetTrigger(DialogueAnimator.showTrigger);
    }
    public virtual void Hide(bool usefade=true)
    {
        Debug.Log("Hide");
        if (usefade) anim.animator.SetTrigger(DialogueAnimator.hideTrigger);
        else anim.OnHideOver();
    }

}
[System.Serializable]
public class Character : DialogueGraphics
{}
[System.Serializable]
public class BackGround : DialogueGraphics
{}
