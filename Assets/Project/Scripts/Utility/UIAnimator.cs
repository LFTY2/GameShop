using System.Collections;
using UnityEngine;

namespace Project.Gameplay.UI
{
    public static class UIAnimator
    {
        public static IEnumerator AnchorPosAnim(this RectTransform rect, Vector2 target, float duration, AnimationCurve curve = null)
        {
            Vector2 start = rect.anchoredPosition;
            float elapsed = 0f;

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                float t = Mathf.Clamp01(elapsed / duration);

                // Allow easing via AnimationCurve, default to linear
                if (curve != null)
                    t = curve.Evaluate(t);

                rect.anchoredPosition = Vector2.LerpUnclamped(start, target, t);
                yield return null;
            }

            rect.anchoredPosition = target; // ensure it lands exactly
        }
    }
}