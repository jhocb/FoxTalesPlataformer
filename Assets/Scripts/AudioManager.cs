using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource footstepsAudioSource;
    public AudioSource environmentAudioSource;
    public AudioSource musicAudioSource;

    public AudioClip[] walkingSounds;
    public AudioClip[] runningSounds;
    public AudioClip[] environmentSounds;

    public AudioClip[] area1MusicTracks;
    public AudioClip[] area2MusicTracks;

    private Movimento3DAtualizado movPlayer;

    void Start()
    {
        ConfigureAudioSources();
        movPlayer = gameObject.GetComponent<Movimento3DAtualizado>();
        // Inicie a reprodução da música na área inicial
        PlayRandomMusicTrack(area1MusicTracks);
        PlayEnvironmentSound(environmentSounds[0]);
    }
    private void Update()
    {
        Debug.Log(movPlayer.isWalking);

        if (movPlayer.isWalking && movPlayer.isGrounded)
        {
            PlayFootsteps();
        }
        else
            StopFootsteps();

    }

    void ConfigureAudioSources()
    {
        // Configurar parâmetros de áudio conforme necessário
        footstepsAudioSource.loop = false;
        environmentAudioSource.loop = true;
        musicAudioSource.loop = true;
    }

    public void PlayFootsteps()
    {
        //isRunning = run;

        if (footstepsAudioSource != null && footstepsAudioSource.isActiveAndEnabled && !footstepsAudioSource.isPlaying)
        {
            //AudioClip[] footstepsSounds = movPlayer.isRunning ? runningSounds : walkingSounds;

            //int randomIndex = Random.Range(0, footstepsSounds.Length);
            footstepsAudioSource.clip = walkingSounds[0];
            footstepsAudioSource.Play();
        }
    }

    public void StopFootsteps()
    {
        if (footstepsAudioSource != null && footstepsAudioSource.isActiveAndEnabled)
        {
            footstepsAudioSource.Stop();
        }
    }

    public void PlayEnvironmentSound(AudioClip sound)
    {
        if (environmentAudioSource != null && environmentAudioSource.isActiveAndEnabled)
        {
            environmentAudioSource.clip = sound;
            environmentAudioSource.Play();
        }
    }

    public void PlayRandomMusicTrack(AudioClip[] musicTracks)
    {
        if (musicAudioSource != null && musicAudioSource.isActiveAndEnabled)
        {
            int randomIndex = Random.Range(0, musicTracks.Length);
            musicAudioSource.clip = musicTracks[randomIndex];
            musicAudioSource.Play();
        }
    }

}
