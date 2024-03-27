using UnityEngine;
using Image = UnityEngine.UI.Image;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip _audioMove;
    [SerializeField] private AudioClip _audioPoint;
    [SerializeField] private AudioClip _audioExplode;
    [SerializeField] private AudioClip _audioBestScore;
    [SerializeField] private AudioSource _audioSource;
    
    [SerializeField] private Sprite _audioActive;
    [SerializeField] private Sprite _audioInactive;
    [SerializeField] private Image _image;
    
    public static AudioManager Instance { get; private set; }
    private float _volume;
    private int _soundVolume;
    
    public void Awake()
    {
        if (Instance != null && Instance == this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        
        _soundVolume = PlayerPrefs.GetInt(GlobalConstants.GAME_AUDIO, 1);
    }

    public void PlayMoveSound()
    {
        _audioSource.clip = _audioMove;
        _audioSource.Play();
    }
    
    public void PlayPointSound()
    {
        _audioSource.clip = _audioPoint;
        _audioSource.Play();
    }
    
    public void PlayExplodeSound()
    {
        _audioSource.clip = _audioExplode;
        _audioSource.Play();
    }

    public void PlayBestScoreSound()
    {
        _audioSource.clip = _audioBestScore;
        _audioSource.Play();
    }
    
    public void ToggleSound()
    {
        _soundVolume = _soundVolume == 1 ? 0 : 1;
        SetSoundValue();
        SaveSoundVolume();
    }

    private void SetSoundValue()
    {
        AudioListener.volume = _soundVolume;
        _image.sprite = _soundVolume == 1 ? _audioActive : _audioInactive;
    }
    
    private void SaveSoundVolume()
    {
        PlayerPrefs.SetInt(GlobalConstants.GAME_AUDIO, _soundVolume);
        PlayerPrefs.Save();
    }
}
