using UnityEngine;
using DarkTonic.PoolBoss;
using System;

public class AudioManager : SingletonBase<AudioManager>
{
    public void PlaySound(AudioClip clip, float volume = 1f, bool isLoop = false, Action onClipEnded = null)
    {
        if (clip == null)
        {
            Debug.LogWarning("Không có clip nào để phát!");
            return;
        }

        Transform audioEmitterTransform = PoolBoss.Spawn("AudioEmitter", Vector3.zero, Quaternion.identity, transform);

        if (audioEmitterTransform == null)
        {
            Debug.LogError("Không thể spawn AudioEmitter từ Pool!");
            return;
        }
        AudioEmitter emitter = audioEmitterTransform.GetComponent<AudioEmitter>();
        emitter.PlayAudio(clip, volume, isLoop);
    }
}
