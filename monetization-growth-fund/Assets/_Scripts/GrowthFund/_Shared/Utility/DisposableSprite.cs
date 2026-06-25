using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Scripts.GrowthFund._Shared.Utility
{
    public class DisposableSprite : IDisposable
    {
        public static readonly DisposableSprite Empty = new DisposableSprite(
            Sprite.Create(
                Texture2D.blackTexture,
                Rect.MinMaxRect(0, 0, 1, 1),
                Vector2.zero));

        public Sprite Sprite { get; }

        public DisposableSprite(Sprite sprite)
        {
            Sprite = sprite;
        }

        public void Dispose()
        {
            if (Sprite == null ||  Sprite == Empty.Sprite) return;
            Object.Destroy(Sprite.texture);
            Object.Destroy(Sprite);
        }

        public DisposableSprite(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit,
            UnityEngine.SpriteMeshType meshType)
        {
            Sprite = Sprite.Create(texture, rect, pivot, pixelsPerUnit, 0, meshType);
        }

        public DisposableSprite(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude,
            UnityEngine.SpriteMeshType meshType, Vector4 border, bool generateFallbackPhysicsShape)
        {
            Sprite = Sprite.Create(texture, rect, pivot, pixelsPerUnit, extrude, meshType, border,
                generateFallbackPhysicsShape);
        }
    }
}