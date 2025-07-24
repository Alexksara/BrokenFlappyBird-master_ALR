using UnityEngine;

public class GroundScroll : MonoBehaviour
{
    [SerializeField] private float M_scrollSpeed = 2f;
    [SerializeField] private float M_resetPositionX;
    [SerializeField] private float M_startPositionX; 

    void Update()
    {
        transform.Translate(Vector2.left * M_scrollSpeed * Time.deltaTime);

        if (transform.position.x <= M_resetPositionX)
        {
            Vector2 newPos = new Vector2(M_startPositionX, transform.position.y);
            transform.position = newPos;
        }
    }
}
