using UnityEngine;

public class AudioLooper : MonoBehaviour
{
    public AudioClip clip;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private float timeBtwLoops = 1;
    private float startLoop;

    public bool isPlaying;


    private void Start()
    {
        startLoop = timeBtwLoops;
    }

    public void Play()
    {
        audioSource.Play();
        isPlaying = true;
    }

    public void Stop()
    {
        isPlaying = false;
    }

    private void Update()
    {
        if (isPlaying)
            timeBtwLoops -= Time.deltaTime;

        if (timeBtwLoops < 0)
        {
            audioSource.Play();
            timeBtwLoops = startLoop;
        }
    }

    public void changeLoopTime(float time)
    {
        timeBtwLoops = time;
        startLoop = timeBtwLoops;
    }
}
