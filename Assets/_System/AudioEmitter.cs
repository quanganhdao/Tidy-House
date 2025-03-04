using DarkTonic.PoolBoss;
using UnityEngine;

public class AudioEmitter : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(AudioClip clip, float volume = 1f, bool loop = false)
    {
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.Play();
        audioSource.loop = loop;

        // Tắt object khi clip phát xong
        if (!loop)
            Invoke(nameof(Deactivate), clip.length);
    }

    private void Deactivate()
    {
        // Trả object về Pool
        PoolBoss.Despawn(transform);
    }
}