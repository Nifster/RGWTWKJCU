using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;
    public AudioSource bgmSource;
    public AudioClip loopTrack;
    [SerializeField]
    private AudioSource shootSFXSource;
    [SerializeField]
    private AudioSource lightsaberSFXSource;
    // Use this for initialization
    void Start () {
        instance = this;
        bgmSource.Play();
        Invoke("PlayNextTrack", bgmSource.clip.length);
    }

    void PlayNextTrack()
    {
        bgmSource.Stop();
        bgmSource.clip = loopTrack;
        bgmSource.Play();
        bgmSource.loop = true;
    }

    public void ShootSFX()
    {
        shootSFXSource.Play();
    }

    public void LightsaberSFX()
    {
        lightsaberSFXSource.Play();
    }

    // Update is called once per frame
    void Update () {
	
	}
}
