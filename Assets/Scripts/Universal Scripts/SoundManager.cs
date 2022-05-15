using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSrc;
    [SerializeField]
    private AudioClip jump_FX, slide_FX, click_FX, stunt_FX, crash_FX;
    // Start is called before the first frame update
    private void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
    }



    public void PlayJumpFx()
    {
        audioSrc.clip = jump_FX;
        audioSrc.Play();
    }
    public void PlayClickFx()
    {
        audioSrc.clip = click_FX;
        audioSrc.Play();
    }
    public void PlayStuntFx()
    {
        audioSrc.clip = stunt_FX;
        audioSrc.Play();
    }
    public void PlayCrashFx()
    {
        audioSrc.clip = crash_FX;
        audioSrc.Play();
    }
    public void PlaySlideFx()
    {
        audioSrc.clip = slide_FX;
        audioSrc.Play();
    }
}
