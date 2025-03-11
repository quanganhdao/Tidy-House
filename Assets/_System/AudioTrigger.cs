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
    [SerializeField] private bool isAudioSourceIndependent = true;
    [SerializeField] private UnityEvent OnClipEnded;
    /// <summary>
    /// hold reference to audiosource that play this audio clip
    /// </summary>
    private AudioEmitter emitter;

    public void PlaySound()
    {
        if (isAudioSourceIndependent || emitter == null)
        {

            emitter = AudioManager.Instance.PlaySound(audioClip, volume, isLoop, OnClipEnded.Invoke);
        }
        else
        {
            if (emitter.AudioSource.time >= 0.9 * audioClip.length || emitter.AudioSource.time < 0.01)
            {
                emitter = AudioManager.Instance.PlaySound(audioClip, volume, isLoop, OnClipEnded.Invoke);
            }
        }
    }

    void OnDisable()
    {
        emitter.OnAudioTriggerDisable();
    }

}
