using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Codebase.UI
{
    public class Fade : MonoBehaviour
    {
        private Tween fadeTween;

        private void Start()
        {
            ChangeScene(1);
            DontDestroyOnLoad(gameObject);
        }

        public void FadeIn(float duration, CanvasGroup canvasGroup)
        {
            FadeCanvasGroup(1f, duration, canvasGroup,
                () =>
                {
                    Debug.Log("FadeIn animation is end");
                });
        }
        public void FadeOut(float duration, CanvasGroup canvasGroup)
        {
            FadeCanvasGroup(0f, duration, canvasGroup,
                () =>
                {
                    Debug.Log("FadeOut animation is end");
                });
        }

        private void FadeCanvasGroup(float fadeValue, float duration, CanvasGroup canvasGroup, TweenCallback onEnd)
        {
            canvasGroup.DOFade(fadeValue, duration);
        }

        public void ChangeScene(int scene_index)
        {
            SceneManager.LoadScene(scene_index);
        }
    }
}