using UnityEngine;

public class MusicFadeMix : MonoBehaviour
{
    [SerializeField]
    private float vol1, vol2;

    [SerializeField]
    private AudioSource musicSource;

    [SerializeField]
    private AudioClip clip1, clip2;

    private float fadeTime = 3f;
    private float decayRate;

    private bool switching, decaying;
    private float desiredVol;

    public bool depth = false, under = false;
    [SerializeField]
    private float posY = -25;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        decayRate = (vol1 + vol2) / fadeTime;
    }

    private void Update()
    {
        if (switching)
        {
            if (decaying)
            {
                musicSource.volume -= decayRate * Time.deltaTime;
                if (musicSource.volume <= 0)
                {
                    decaying = false;
                    desiredVol = musicSource.clip == clip1 ? vol2 : vol1;
                    musicSource.clip = musicSource.clip == clip1 ? clip2 : clip1;
                    musicSource.Play();
                }
            }
            else
            {
                musicSource.volume += decayRate * Time.deltaTime;
                if (musicSource.volume >= desiredVol)
                {
                    switching = false;
                }
            }
        }
        if (depth)
        {
            if (under && transform.position.y > posY)
            {
                switchClips();
                under = false;
            }
            else if (!under && transform.position.y < posY)
            {
                switchClips();
                under = true;
            }
        }
    }

    public void switchClips()
    {
        switching = true;
        decaying = true;
    }
}
