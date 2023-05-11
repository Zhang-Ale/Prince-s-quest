using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets; 

public class PlayerNarrationSystem : MonoBehaviour, IObserver
{
    [SerializeField] Subject _playerSubject;
    [SerializeField] int _jumpCount = 0;
    int _jumpAudioThreshold = 3;
    Coroutine _currentJumpResetRoutine = null;
    int index; 

    AudioSource _audioPlayer;
    public AudioClip _jumpingAudioClip;
    public AudioClip _buttonAudioClip;
    public AudioClip[] _groundFootstepAudioClip;
    public AudioClip[] _caveFootstepAudioClip;
    public AudioClip[] _dungeonFootstepAudioClip;
    ThirdPersonController TPC; 
    void Awake()
    {
        _audioPlayer = GetComponent<AudioSource>();
        index = SceneManager.GetActiveScene().buildIndex;
        TPC = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonController>(); 
    }

    public void OnNotify(PlayerActions action)
    {
        switch (action)
        {
            case (PlayerActions.Jump):      
                if (_currentJumpResetRoutine != null)
                {
                    StopCoroutine(_currentJumpResetRoutine);
                }

                //increment jump count
                _jumpCount += 1;

                if (_jumpCount == _jumpAudioThreshold)
                {
                    _audioPlayer.clip = _jumpingAudioClip;
                    _audioPlayer.Play();
                }

                _currentJumpResetRoutine = StartCoroutine(IJumpResetRoutine());
                return;

            case (PlayerActions.Walk):
                if (index == 1)
                {
                    _audioPlayer.clip = _groundFootstepAudioClip[Random.Range(0, _groundFootstepAudioClip.Length)];
                }
                if (index == 2)
                {
                    _audioPlayer.clip = _caveFootstepAudioClip[Random.Range(0, _caveFootstepAudioClip.Length)];
                }
                if (index == 3)
                {
                    _audioPlayer.clip = _dungeonFootstepAudioClip[Random.Range(0, _dungeonFootstepAudioClip.Length)];
                }
                _audioPlayer.Play();
                return;


            case (PlayerActions.StopWalk):
                _audioPlayer.Stop();
                return;

            case (PlayerActions.Button):
                _audioPlayer.clip = _buttonAudioClip;
                _audioPlayer.Play();
                return;

            case (PlayerActions.DialogueStart):
                TPC.enabled = false;
                return;

            case (PlayerActions.DialogueOver):
                TPC.enabled = true; 
                return; 

            default:
                return;         
        }
    }

    private void OnEnable()
    {
        //add itself to the subject's list of observers
        _playerSubject.AddObserver(this); 
    }

    private void OnDisable()
    {
        //remove itself to the subject's list of observers
        _playerSubject.RemoveObserver(this); 
    }

    IEnumerator IJumpResetRoutine()
    {
        yield return new WaitForSeconds(2.75f);
        _jumpCount = 0; 
    }
}
