using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource backgroundMusic;

    // Una variable para asegurar que solo haya un AudioManager en la escena
    private static AudioManager instance;

    // Reproducir música de fondo al iniciar
    public AudioClip[] musicTracks;
    private int currentTrackIndex = 0;

    // Control de volumen de música
    [Range(0f, 1f)]
    public float musicVolume = 0.5f;

    // Control de volumen de efectos
    [Range(0f, 1f)]
    public float effectsVolume = 1f;

    // Al comenzar, aseguramos que solo haya un AudioManager
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Mantener el AudioManager entre escenas
        }
        else
        {
            Destroy(gameObject); // Si ya existe, destruir este objeto
        }
    }

    // Empezar la música de fondo al iniciar el juego
    void Start()
    {
        if (musicTracks.Length > 0)
        {
            PlayMusic(musicTracks[currentTrackIndex]);
        }
    }

    // Método para reproducir música de fondo
    public void PlayMusic(AudioClip track)
    {
        backgroundMusic.clip = track;
        backgroundMusic.volume = musicVolume;
        backgroundMusic.loop = true;
        backgroundMusic.Play();
    }

    // Cambiar la pista de música
    public void ChangeTrack(int trackIndex)
    {
        if (trackIndex >= 0 && trackIndex < musicTracks.Length)
        {
            currentTrackIndex = trackIndex;
            PlayMusic(musicTracks[trackIndex]);
        }
    }

    // Control del volumen de la música
    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        backgroundMusic.volume = musicVolume;
    }

    // Método para detener la música
    public void StopMusic()
    {
        backgroundMusic.Stop();
    }
}
