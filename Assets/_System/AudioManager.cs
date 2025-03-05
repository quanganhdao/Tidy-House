using UnityEngine;
using DarkTonic.PoolBoss;
using System;

public class AudioManager : SingletonBase<AudioManager>
{
    public AudioEmitter PlaySound(AudioClip clip, float volume = 1f, bool isLoop = false, Action onClipEnded = null)
    {
        if (clip == null)
        {
            Debug.LogWarning("Không có clip nào để phát!");
            return null;
        }

        Transform audioEmitterTransform = PoolBoss.Spawn("AudioEmitter", Vector3.zero, Quaternion.identity, transform);

        if (audioEmitterTransform == null)
        {
            Debug.Log("Không thể spawn AudioEmitter từ Pool!");
            return null;
        }
        AudioEmitter emitter = audioEmitterTransform.GetComponent<AudioEmitter>();
        emitter.PlayAudio(clip, volume, isLoop);
        Debug.Log($"Play Audio Clip {clip.name} with volume {volume}");
        return emitter;
    }
}
