using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;



[RequireComponent(typeof(TextMeshProUGUI))]
public class CountdownTimer : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private UnityEvent _OnOneSecondTick;
    [SerializeField] private UnityEvent _OnOneMinuteWarning;
    [SerializeField] private UnityEvent _OnThirtySecondWarning;
    [SerializeField] private UnityEvent _OnBombExplode;
    [SerializeField] private float _loadMainMenuWaitTime;

    private float _timer = 0;
    private float _remainingTime = 180;
    private bool _oneMinuteWarning;
    private bool _thirtySecondWarning;
    private bool _gameOver;
    private bool _endSequenceCalled;

    public static bool _winGame;
    public static bool _loseGame;
    private bool _gameStarted;

    public static event Action OnLoseGame;
    public static event Action OnRestartGame;
    public static event Action OnWinGame;

    private void OnEnable()
    {
        StartTimer._OnTimerStart += GameStart;
        WrongAnswer._OnWrongAnswer += WrongAnswerReceived;
        WinGame.OnPlayerWon += SetPlayerWin;
    }


    private void OnDisable()
    {
        StartTimer._OnTimerStart -= GameStart;
        WrongAnswer._OnWrongAnswer -= WrongAnswerReceived;
        WinGame.OnPlayerWon -= SetPlayerWin;
    }


    // Start is called before the first frame update
    void Start()
    {
        _oneMinuteWarning = false;
        _thirtySecondWarning = false;
        _gameOver = false;
        _endSequenceCalled = false;
        _winGame = false;
        _loseGame = false;
        _gameStarted = false;
        _timerText.color = Color.green;
        _timerText.text = "3:00";
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameStarted)
        {
            if (!_gameOver && !_winGame)
            {
                _timer += Time.deltaTime;

                if (_timer >= 1)
                {
                    _remainingTime -= 1;
                    if (_remainingTime <= 60 && !_oneMinuteWarning)
                    {
                        _timerText.color = Color.yellow;
                        OneMinuteWarning();
                        _oneMinuteWarning = !_oneMinuteWarning;
                    }
                    else if (_remainingTime <= 30 && !_thirtySecondWarning)
                    {
                        _timerText.color = Color.red;
                        ThirtySecondWarning();
                        _thirtySecondWarning = !_thirtySecondWarning;
                    }
                    else if (_remainingTime <= 0)
                    {
                        _timerText.text = "0:00";
                        _gameOver = !_gameOver;
                        _loseGame = !_loseGame;
                        return;
                    }
                    int remainingMinutes = (int)_remainingTime / 60;
                    float remainingSeconds = _remainingTime % 60;
                    _timerText.text = remainingMinutes.ToString() + ":" + remainingSeconds.ToString("00");
                    OneSecondTick();
                    _timer = 0;
                }
            }
            else if (_loseGame && !_endSequenceCalled)
            {
                OnLoseGame?.Invoke();
                _endSequenceCalled = !_endSequenceCalled;
                RestartCountdown();
            } 
            else if (_winGame && !_endSequenceCalled) 
            {
                print("Player has won!");
                OnWinGame?.Invoke();
                _endSequenceCalled = !_endSequenceCalled;
                RestartCountdown();
            }
        }
    }

    private void GameStart()
    {
        _gameStarted = !_gameStarted;
    }
    private void WrongAnswerReceived()
    {
        _loseGame = true;
        _gameOver = true;
    }
    private void SetPlayerWin()
    {
        _winGame = !_winGame;
    }

    private void OneSecondTick()
    {
        _OnOneSecondTick?.Invoke();
    }

    private void OneMinuteWarning()
    {
        _OnOneMinuteWarning?.Invoke();
    }

    private void ThirtySecondWarning()
    {
        _OnThirtySecondWarning?.Invoke();
    }

    private void RestartCountdown()
    {
        StartCoroutine(CountdownRoutine());
    }

    private IEnumerator CountdownRoutine()
    {
        while (_loadMainMenuWaitTime > 0)
        {
            _loadMainMenuWaitTime -= Time.deltaTime;
            yield return null;
        }
        OnRestartGame?.Invoke();
    }
}
