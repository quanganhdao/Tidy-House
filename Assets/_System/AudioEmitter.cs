using DarkTonic.PoolBoss;
using UnityEngine;

public class AudioEmitter : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioSource AudioSource { get => audioSource; set => audioSource = value; }

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

    public void Deactivate()
    {
        // Trả object về Pool
        PoolBoss.Despawn(transform);
    }


    public void OnAudioTriggerDisable()
    {
        AudioSource.Stop();
        Deactivate();
    }

}