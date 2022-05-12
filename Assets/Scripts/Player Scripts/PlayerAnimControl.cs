using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimControl : MonoBehaviour
{
    private Animator playerAnim;

    private void Awake() => playerAnim = GetComponent<Animator>();
   public void Run(bool move)
    {
        playerAnim.SetBool(AnimationTags.Run, move);
    }

    public void Slide()
    {
        playerAnim.SetTrigger(AnimationTags.Slide_Trig);
    }
    public void Jump()
    {
        playerAnim.SetTrigger(AnimationTags.Jump_Trig);
    }
    public void TwistFlip()
    {
        playerAnim.SetTrigger(AnimationTags.TwistFlip_Trig);
    }
    public void ForwardFlip()
    {
        playerAnim.SetTrigger(AnimationTags.RunFlip_Trig);
    }
}
