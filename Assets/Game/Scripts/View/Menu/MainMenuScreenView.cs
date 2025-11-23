using Game.Input;
using UnityEngine;
using UnityEngine.UI;

namespace Game.View.UI
{
public class MainMenuScreenView : MonoBehaviour
{
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _match3Button;
    [SerializeField] private Button _mergeButton;
    [SerializeField] private Button _arkanoidButton;

    private PlayerInput _playerInput;
    
    public void Init(PlayerInput playerInput)
    {
        _playerInput = playerInput;
    }
    
    private void Start()
    {
        _exitButton.onClick.AddListener(() => _playerInput.MainMenu.IsExit = true);
        _match3Button.onClick.AddListener(() => _playerInput.MainMenu.IsMatch3 = true);
        _mergeButton.onClick.AddListener(() => _playerInput.MainMenu.IsMerge = true);
        _arkanoidButton.onClick.AddListener(() => _playerInput.MainMenu.IsArkanoid = true);
    }

    private void OnDestroy()
    {
        _exitButton.onClick.RemoveAllListeners();
        _match3Button.onClick.RemoveAllListeners();
        _mergeButton.onClick.RemoveAllListeners();
        _arkanoidButton.onClick.RemoveAllListeners();
    }
    
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
}
