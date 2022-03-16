using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    [SerializeField] private AudioClip bgMusic = null;
    [SerializeField] private AudioClip mainMenuMusic = null;
    [SerializeField] private AudioClip playerShootSound = null;
    [SerializeField] private AudioClip playerJumpSound = null;
    [SerializeField] private AudioClip playerCollectSound = null;
    [SerializeField] private AudioClip playerDeathSound = null;
    [SerializeField] private AudioClip playerSlideSound = null;
    [SerializeField] private AudioClip enemyDeathSound = null;
    [SerializeField] private AudioClip enemyAttackSound = null;

    private AudioSource audioSource;
    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        /*if (scene.name == TagManager.MAINMENU_SCENE_NAME)
        {
            AudioManager.Instance.PlayBGMusic(false);
        } else
        {
            AudioManager.Instance.PlayBGMusic(true);
        }*/
    }

    private void PlayBGMusic(bool gamePlay)
    {
        if (gamePlay)
        {
            audioSource.clip = bgMusic;

        } else
        {
            audioSource.clip = mainMenuMusic;
        }

        audioSource.loop = true;
        audioSource.Play();
    }

    public void Play_PlayerAttackSound()
    {
        AudioSource.PlayClipAtPoint(playerShootSound,transform.position,2f);
    }

    public void Play_PlayerJumpSound()
    {
        print("Jump");
        AudioSource.PlayClipAtPoint(playerJumpSound,transform.position,2f);
    }

    public void Play_PlayerDeathSound()
    {
        AudioSource.PlayClipAtPoint(playerDeathSound,transform.position,2f);
    }

    public void Play_PlayerCollectSound()
    {
        AudioSource.PlayClipAtPoint(playerCollectSound,transform.position,2f);
    }

    public void Play_PlayerSlideSound()
    {
        AudioSource.PlayClipAtPoint(playerSlideSound,transform.position,2f);
    }

    public void Play_EnemyAttackSound()
    {
        AudioSource.PlayClipAtPoint(enemyAttackSound,transform.position,2f);
    }

    public void Play_EnemyDeathSound()
    {
        AudioSource.PlayClipAtPoint(enemyDeathSound,transform.position,2f);
    }
}
