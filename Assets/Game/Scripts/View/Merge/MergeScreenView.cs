using Game.Input;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.View.Merge
{
public sealed class MergeScreenView : MonoBehaviour
{
    [SerializeField] private Button _exitButton;
    [SerializeField] private TextMeshProUGUI _recordText;
	[SerializeField] private TextMeshProUGUI _scoreText;
	
	private PlayerInput _playerInput;
	
	private void Start()
	{
		_exitButton.onClick.AddListener(() => _playerInput.MergeInput.IsExit = true);
	}

	private void OnDestroy()
	{
		_exitButton.onClick.RemoveAllListeners();
	}

	public void Init(PlayerInput playerInput)
	{
		_playerInput = playerInput;
	}

	public void SetRecord(int score)
	{
		_recordText.text = score.ToString();
	}
	
	public void SetScore(int score)
	{
		_scoreText.text = score.ToString();
	}
	
	public void Destroy()
	{
		Destroy(gameObject);
	}
}
}