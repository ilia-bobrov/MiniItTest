using System;
using Game.View;
using Game.View.Merge;
using Game.View.UI;
using UnityEngine;

namespace Game.Configs
{
[CreateAssetMenu(fileName = "Assets", menuName = "Game/Assets/Asset")][Serializable]
public sealed class Assets : ScriptableObject
{
    [field:Space, Header("Background")]
    [field: SerializeField] public BackgroundView BackgroundView { get; private set; }
    [field: SerializeField] public BackgroundSprites BackgroundSprites { get; private set; }
    
    [field:Space, Header("Menu")]
    [field: SerializeField] public MainMenuScreenView MainMenuScreenView { get; private set; }
    
    [field:Space, Header("Merge")]
    [field: SerializeField] public GridView GridView { get; private set; }
    [field: SerializeField] public ItemView ItemView { get; private set; }
    [field: SerializeField] public Sprite[] ItemSprites { get; private set; }
    [field: SerializeField] public MergeScreenView MergeScreenView { get; private set; }
}

[Serializable]
public struct BackgroundSprites
{
    [field: SerializeField] public Texture MainMenuSprite { get; private set; }
    [field: SerializeField] public Texture Match3Sprite { get; private set; }
    [field: SerializeField] public Texture MergeSprite { get; private set; }
    [field: SerializeField] public Texture ArkanoidSprite { get; private set; }
}
}