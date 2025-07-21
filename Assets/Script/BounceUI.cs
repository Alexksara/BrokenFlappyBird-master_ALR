using System.Collections;
using UnityEngine;

public class BounceUI : MonoBehaviour
{
    public float bounceHeight = 50f;        
    public float bounceDuration = 0.5f;     

    private RectTransform M_rectTransform;
    private Vector2 M_startAnchoredPos;

    void Start()
    {
        M_rectTransform = GetComponent<RectTransform>();
        M_startAnchoredPos = M_rectTransform.anchoredPosition;

        StartCoroutine(BounceUp());
    }

    IEnumerator BounceUp()
    {
        yield return StartCoroutine(MoveVertical(M_startAnchoredPos, M_startAnchoredPos + Vector2.up * bounceHeight, bounceDuration));
        StartCoroutine(BounceDown());
    }

    IEnumerator BounceDown()
    {
        yield return StartCoroutine(MoveVertical(M_startAnchoredPos + Vector2.up * bounceHeight, M_startAnchoredPos, bounceDuration));
    }

    IEnumerator MoveVertical(Vector2 from, Vector2 to, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            M_rectTransform.anchoredPosition = Vector2.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        M_rectTransform.anchoredPosition = to;
    }
}
