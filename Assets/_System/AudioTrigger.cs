using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private float volume = 1;
    [SerializeField] private bool isLoop = false;
    [SerializeField] private UnityEvent OnClipEnded;

    public void PlaySound()
    {
        AudioManager.Instance.PlaySound(audioClip, volume, isLoop, OnClipEnded.Invoke);
    }
}
