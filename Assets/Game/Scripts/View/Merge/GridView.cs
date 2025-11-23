using UnityEngine;

namespace Game.View.Merge
{
public sealed class GridView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _backgroundRenderer;
    [SerializeField] private SpriteRenderer _divider;
    
    public void Init(float sizeMult, int gridSizeX, int gridSizeY, float backWidth, float backHeight, float cellSize, float borderThickness)
    {
        _backgroundRenderer.size = new Vector2(backWidth, backHeight);

        int i;
        for (i = 0; i < gridSizeX - 1; i++)
        {
            var divider = Instantiate(_divider, transform);
            divider.size = new Vector2(divider.size.x, backHeight);
            var pos = _backgroundRenderer.transform.position;
            divider.transform.position = new Vector3(pos.x + backWidth / 2f - borderThickness - cellSize * (i + 1), pos.y, pos.z);
        }
        
        for (int j = 0; j < gridSizeY - 1; j++)
        {
            var divider = Instantiate(_divider, transform);
            divider.size = new Vector2(backWidth, divider.size.y);
            var pos = _backgroundRenderer.transform.position;
            divider.transform.position = new Vector3(pos.x, pos.y + backHeight / 2f - borderThickness - cellSize * (j + 1), pos.z);
        }
        
        transform.localScale = new Vector3(transform.localScale.x * sizeMult, transform.localScale.y * sizeMult, 1f);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
}