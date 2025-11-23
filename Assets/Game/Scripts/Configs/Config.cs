using System;
using UnityEngine;

namespace Game.Configs
{
[CreateAssetMenu(fileName = "Config", menuName = "Game/Configs/Config")] [Serializable]
public sealed class Config : ScriptableObject
{
    [field: SerializeField] public Background Background { get; private set; }
    [field: SerializeField] public Match3Config Match3Config { get; private set; }
    [field: SerializeField] public MergeConfig MergeConfig { get; private set; }
    [field: SerializeField] public ArkanoidConfig ArkanoidConfig { get; private set; }
}

[Serializable]
public struct Background
{
    [field: SerializeField, Min(0)] public Vector2 MinVelocity { get; private set; }
    [field: SerializeField, Min(0)] public Vector2 MaxVelocity { get; private set; }
    [field: Space]
    [field: SerializeField] public Color MainMenuMainColor { get; private set; }
    [field: SerializeField] public Color MainMenuSpriteColor { get; private set; }
    [field: Space]
    [field: SerializeField] public Color Match3MainColor { get; private set; }
    [field: SerializeField] public Color Match3SpriteColor { get; private set; }
    [field: Space]
    [field: SerializeField] public Color MergeMainColor { get; private set; }
    [field: SerializeField] public Color MergeSpriteColor { get; private set; }
    [field: Space]
    [field: SerializeField] public Color ArkanoidMainColor { get; private set; }
    [field: SerializeField] public Color ArkanoidSpriteColor { get; private set; }
}
}