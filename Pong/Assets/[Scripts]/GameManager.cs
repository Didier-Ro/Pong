using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private Ball _ball = default;
    [SerializeField] private int _playerScore = default;
    [SerializeField] private int _computerScore = default;

    [SerializeField] private TextMeshProUGUI _playerScoreUI = default;
    [SerializeField] private TextMeshProUGUI _computerScoreUI = default;

    [SerializeField] private AudioClip _pointSound = default;

    [SerializeField] private GameObject playerWinText = default;
    [SerializeField] private GameObject computerWinText = default;
    [SerializeField] private GameObject playAgainButton = default;
    [SerializeField] private GameObject returnMenuButton = default;

    private void Awake()
    {
        Time.timeScale = 1;

        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(_playerScore == 5)
        {
            PlayerWin();
        }

        if (_computerScore == 5)
        {
            ComputerWin();
        }
    }

    public void PlayerScore()
    {
        _playerScore++;
        _ball.ResetBall();
        AudioManager.Instance.SetAudioClip(_pointSound, 1f);
        _playerScoreUI.text = _playerScore.ToString();
    }

    public void ComputerScore()
    {
        _computerScore++;
        _ball.ResetBall();
        AudioManager.Instance.SetAudioClip(_pointSound, 1f);
        _computerScoreUI.text = _computerScore.ToString();
    }

    private void PlayerWin()
    {
        Time.timeScale = 0;
        playerWinText.SetActive(true);
        playAgainButton.SetActive(true);
        returnMenuButton.SetActive(true);
    }

    private void ComputerWin()
    {
        Time.timeScale = 0;
        computerWinText.SetActive(true);
        playAgainButton.SetActive(true);
        returnMenuButton.SetActive(true);
    }
}
