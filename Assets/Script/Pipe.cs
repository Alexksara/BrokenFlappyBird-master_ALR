using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float destroyX = -10f;
    private bool scored = false;
    private float scorePosition = -1f;

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (!scored && transform.position.x < scorePosition)
        {
            scored = true;
            GameManager.Instance.IncreaseScore();
        }

        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}
