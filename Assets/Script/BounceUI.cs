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
    //Summary
    //calls move vertical with parameters to bounce upwards, also calls bouncedown
    IEnumerator BounceUp()
    {
        yield return StartCoroutine(MoveVertical(M_startAnchoredPos, M_startAnchoredPos + Vector2.up * bounceHeight, bounceDuration));
        StartCoroutine(BounceDown());
    }
    //Summary
    // calls move vertical with parameters to "bounce" down
    IEnumerator BounceDown()
    {
        yield return StartCoroutine(MoveVertical(M_startAnchoredPos + Vector2.up * bounceHeight, M_startAnchoredPos, bounceDuration));
    }

    //Summary
    // receives arguments to move the bird from start to end positions over the duration, uses iEnumerator because many instances can be called at once
    IEnumerator MoveVertical(Vector2 startPosition, Vector2 endPosition, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            M_rectTransform.anchoredPosition = Vector2.Lerp(startPosition, endPosition, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        M_rectTransform.anchoredPosition = endPosition;
    }
}
