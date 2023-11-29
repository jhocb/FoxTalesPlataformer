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

        // Inicie a reprodução da música na área inicial
        PlayRandomMusicTrack(area1MusicTracks);
    }

    void ConfigureAudioSources()
    {
        // Configurar parâmetros de áudio conforme necessário
        footstepsAudioSource.loop = false;
        environmentAudioSource.loop = true;
        musicAudioSource.loop = true;
    }

    public void PlayFootsteps(bool run)
    {
        //isRunning = run;

        if (footstepsAudioSource != null && footstepsAudioSource.isActiveAndEnabled && movPlayer.isWalking == true)
        {
            AudioClip[] footstepsSounds = movPlayer.isRunning ? runningSounds : walkingSounds;

            int randomIndex = Random.Range(0, footstepsSounds.Length);
            footstepsAudioSource.clip = footstepsSounds[randomIndex];
            footstepsAudioSource.pitch = movPlayer.isRunning ? 1.5f : 1.0f;
            footstepsAudioSource.Play();
        }
    }

    public void StopFootsteps()
    {
        if (footstepsAudioSource != null && footstepsAudioSource.isActiveAndEnabled && movPlayer.isWalking == false)
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

    void OnTriggerEnter(Collider other)
    {
        // Verifica se o jogador entrou em uma nova área
        if (other.CompareTag("Area1"))
        {
            // Muda a música e o som ambiente para a Área 1
            PlayRandomMusicTrack(area1MusicTracks);
            PlayEnvironmentSound(environmentSounds[0]);
        }
        else if (other.CompareTag("Area2"))
        {
            // Muda a música e o som ambiente para a Área 2
            PlayRandomMusicTrack(area2MusicTracks);
            PlayEnvironmentSound(environmentSounds[1]);
        }
        else if (other.CompareTag("Area3"))
        {
            // Muda a música e o som ambiente para a Área 2
            PlayRandomMusicTrack(area2MusicTracks);
            PlayEnvironmentSound(environmentSounds[2]);
        }
        else if (other.CompareTag("Area4"))
        {
            // Muda a música e o som ambiente para a Área 2
            PlayRandomMusicTrack(area2MusicTracks);
            PlayEnvironmentSound(environmentSounds[3]);
        }
        // Adicione mais verificações de área conforme necessário
    }
}
