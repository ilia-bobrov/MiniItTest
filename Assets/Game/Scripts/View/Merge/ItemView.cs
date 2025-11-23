using Game.Input;
using Game.Utils;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace Game.View.Merge
{
public sealed class ItemView : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerCaptureEvent
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public Index2 Index { get; private set; }
    
    private PlayerInput _playerInput;

    public void Init(Index2 index, PlayerInput playerInput)
    {
        Index = index;
        _playerInput = playerInput;
    }
    
    public void SetSize(float size)
    {
        transform.localScale = new Vector3(size, size, transform.localScale.z);
    }
    
    public void SetLayerOrder(int order)
    {
        _spriteRenderer.sortingOrder = order;
    }
    
    public void SetPosition(Vector2 position)
    {
        transform.position = position;
    }

    public void SetLocalPosition(Vector2 position)
    {
        transform.localPosition = position;
    }
    
    public void SetSprite(Sprite sprite)
    {
        _spriteRenderer.sprite = sprite;
    }
    
    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public Vector2 GetPosition()
    {
        return transform.position;
    }
    
    public void Destroy()
    {
        Destroy(gameObject);
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        _playerInput.MergeInput.ItemPointerDown = new MergeInput.ItemPointerDownAction
        {
            IsDown = true,
            ItemIndex = Index
        };
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        _playerInput.MergeInput.ItemPointerUp = new MergeInput.ItemPointerUpAction
        {
            IsUp = true,
            ItemIndex = Index,
            EventData = eventData
        };
    }
}
}