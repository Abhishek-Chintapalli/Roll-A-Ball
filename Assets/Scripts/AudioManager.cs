using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    [SerializeField] public AudioSource musicSource;
    [SerializeField] public AudioSource SFXSource;

    public AudioClip background;
    public AudioClip win;
    public AudioClip lose;
    public AudioClip gem;

    public void Start()
    {
        musicSource.clip = background;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip == lose || clip == win)
        {
            musicSource.Stop();
        }
        SFXSource.PlayOneShot(clip);
    }
    

}
