using JetBrains.Annotations;
using UnityEngine;

namespace _Scripts.GrowthFund._Shared.Utility
{
    public static class SpriteExtensionMethods
    {
        public static DisposableSprite ToDisposableSprite(this Sprite sprite)
        {
            return new DisposableSprite(sprite);
        }

        public static DisposableSprite ToDisposableSpriteOrEmpty([CanBeNull] this Sprite sprite)
        {
            return sprite == null ? DisposableSprite.Empty : ToDisposableSprite(sprite);
        }
    }
}