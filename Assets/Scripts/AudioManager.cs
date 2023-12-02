using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource footstepsAudioSource;
    public AudioSource environmentAudioSource;
    public AudioSource musicAudioSource;
    public AudioSource sfx;

    public AudioClip[] walkingSounds;
    public AudioClip[] runningSounds;
    public AudioClip[] environmentSounds;

    public AudioClip[] area1MusicTracks;
    public AudioClip[] area2MusicTracks;
    public AudioClip[] area3MusicTracks;
    public AudioClip[] area4MusicTracks;


    public AudioClip dashH;
    public AudioClip dashV;

    private Movimento3DAtualizado movPlayer;

    void Start()
    {
        ConfigureAudioSources();
        movPlayer = gameObject.GetComponent<Movimento3DAtualizado>();
        // Inicie a reprodução da música na área inicial
        UpdateMusic();
        PlayEnvironmentSound(environmentSounds);

    }
    private void Update()
    {
        //Debug.Log(movPlayer.isWalking);

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
            AudioClip[] footstepsSounds = movPlayer.isRunning ? runningSounds : walkingSounds;

            int randomIndex = Random.Range(0, footstepsSounds.Length);
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

    public void PlayEnvironmentSound(AudioClip[] sound)
    {
        if (environmentAudioSource != null && environmentAudioSource.isActiveAndEnabled)
        {
            int randomIndex = Random.Range(0, sound.Length);
            environmentAudioSource.clip = sound[randomIndex];
            environmentAudioSource.Play();
        }
    }
    /*
    public void PlayRandomMusicTrackA1(AudioClip[] musicTracks1)
    {
        if (musicAudioSource != null && musicAudioSource.isActiveAndEnabled)
        {
            int randomIndex = Random.Range(0, musicTracks1.Length);
            musicAudioSource.clip = musicTracks1[randomIndex];
            musicAudioSource.Play();
        }
    }
    public void PlayRandomMusicTrackA2(AudioClip[] musicTracks2)
    {
        if (musicAudioSource != null && musicAudioSource.isActiveAndEnabled)
        {
            int randomIndex = Random.Range(0, musicTracks2.Length);
            musicAudioSource.clip = musicTracks2[randomIndex];
            musicAudioSource.Play();
        }
    }
    public void PlayRandomMusicTrackA3(AudioClip[] musicTracks3)
    {
        if (musicAudioSource != null && musicAudioSource.isActiveAndEnabled)
        {
            int randomIndex = Random.Range(0, musicTracks3.Length);
            musicAudioSource.clip = musicTracks3[randomIndex];
            musicAudioSource.Play();
        }
    }
    public void PlayRandomMusicTrackA4(AudioClip[] musicTracks4)
    {
        if (musicAudioSource != null && musicAudioSource.isActiveAndEnabled)
        {
            int randomIndex = Random.Range(0, musicTracks4.Length);
            musicAudioSource.clip = musicTracks4[randomIndex];
            musicAudioSource.Play();
        }
    }*/
    public void UpdateMusic()
    {
        AudioClip[] currentAreaMusic = null;

        if (movPlayer.playerArea == 1)
        {
            currentAreaMusic = area1MusicTracks;
        }
        else if (movPlayer.playerArea == 2)
        {
            currentAreaMusic = area2MusicTracks;
        }
        else if (movPlayer.playerArea == 3)
        {
            currentAreaMusic = area3MusicTracks;
        }
        else if (movPlayer.playerArea == 4)
        {
            currentAreaMusic = area4MusicTracks;
        }

        if (currentAreaMusic != null)
        {
            CrossFadeToNewMusic(currentAreaMusic);
        }
    }

    void CrossFadeToNewMusic(AudioClip[] newMusic)
    {
        if (musicAudioSource != null && musicAudioSource.isActiveAndEnabled)
        {
            // Se a música atual já estiver tocando, inicie a transição suave
            if (musicAudioSource.isPlaying)
            {
                StartCoroutine(CrossFadeCoroutine(newMusic));
            }
            else
            {
                // Se não houver música tocando, apenas reproduza a nova música
                PlayRandomMusicTrack(newMusic);
            }
        }
    }

    IEnumerator CrossFadeCoroutine(AudioClip[] newMusic)
    {
        float fadeDuration = 2.0f; // Ajuste conforme necessário
        float timer = 0f;
        float startVolume = musicAudioSource.volume;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            musicAudioSource.volume = Mathf.Lerp(startVolume, 0f, timer / fadeDuration);
            yield return null;
        }

        PlayRandomMusicTrack(newMusic);

        timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            musicAudioSource.volume = Mathf.Lerp(0f, startVolume, timer / fadeDuration);
            yield return null;
        }

        musicAudioSource.volume = startVolume; // Garanta que o volume seja restaurado ao valor original
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

    public void playDashH()
    {
        sfx.clip = dashH;
        sfx.Play();
    }
    public void playDashV()
    {
        sfx.clip = dashV;
        sfx.Play();
    }

}
