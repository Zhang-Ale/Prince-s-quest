using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNarrationSystem : MonoBehaviour, IObserver
{
    [SerializeField] Subject _playerSubject;
    [SerializeField] int _jumpCount = 0;
    int _jumpAudioThreshold = 3;
    Coroutine _currentJumpResetRoutine = null;

    AudioSource _audioPlayer;
    public AudioClip _jumpingAudioClip;
    public AudioClip _collectAudioClip;

    void Awake()
    {
        _audioPlayer = GetComponent<AudioSource>(); 
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

            case (PlayerActions.Collect):
                _audioPlayer.clip = _collectAudioClip;
                _audioPlayer.Play();
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
