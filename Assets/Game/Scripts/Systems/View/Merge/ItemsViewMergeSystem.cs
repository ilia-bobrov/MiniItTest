using Game.Configs;
using Game.Ev;
using Game.Models;

namespace Game.Systems.View.Merge
{
public class ItemsViewMergeSystem : ISystem
{
    private readonly MergeViewModel _viewModel;
    private readonly Events _events;
    private readonly Assets _assets;

    public ItemsViewMergeSystem(MergeViewModel viewModel, Events events, Assets assets)
    {
        _viewModel = viewModel;
        _events = events;
        _assets = assets;
    }

    public void Start() { }

    public void Update()
    {
        var ev = _events.MergeEvents.Merge;
        if (ev.IsMerged)
        {
            var itemView = _viewModel.ActiveItems[ev.MergingCell];
            itemView.SetActive(false);
            _viewModel.ActiveItems.Remove(itemView.Index);
            _viewModel.InactiveItems.Add(itemView.Index, itemView);

            itemView = _viewModel.ActiveItems[ev.TargetCell];
            if (ev.NewLevel > 0)
            {
                itemView.SetSprite(_assets.ItemSprites[ev.NewLevel - 1]);
            }
            else
            {
                itemView.SetActive(false);
                _viewModel.ActiveItems.Remove(itemView.Index);
                _viewModel.InactiveItems.Add(itemView.Index, itemView);
            }
        }
    }

    public void Stop() { }
}
}