using System.Collections;
using UnityEngine;
using UnityEngine.U2D; // IMPORTANT

public class AutoColorChanger : MonoBehaviour
{
    public float changeInterval = 0.1f;

    private SpriteShapeRenderer sr;

    private Color[] colors =
    {
        Color.red,
        Color.blue,
        Color.green,
        new Color(1f, 0.5f, 0f),   // Orange
        new Color(1f, 0f, 0.5f)    // Pink
    };

    void Start()
    {
        sr = GetComponent<SpriteShapeRenderer>(); //CORRECT COMPONENT
        //StartCoroutine(ChangeColorRoutine());
    }

    public IEnumerator ChangeColorRoutine()
    {
        float timer = 0f;

        while (timer < 2f) // run only for 2 seconds
        {
            yield return new WaitForSeconds(changeInterval);

            int rand = Random.Range(0, colors.Length);
            sr.color = colors[rand];

            timer += changeInterval;
        }

        // optional: reset to white after stop
        // sr.color = Color.white;
    }
}