using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
    public string colorName;
    public Node currentNode;

    private bool isMoving = false;

    public void SetNode(Node node)
    {
        if (isMoving) return;

        StartCoroutine(MoveToNode(node));
    }

    IEnumerator MoveToNode(Node node)
    {
        isMoving = true;

        // Remove from old node
        if (currentNode != null)
        {
            currentNode.currentCoin = null;
            currentNode.UpdateVisual();
        }

        Vector3 startPos = transform.position;
        Vector3 targetPos = node.transform.position;

        float t = 0f;
        float speed = 5f;

        while (t < 1f)
        {
            t += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(startPos, targetPos, t);
            yield return null;
        }

        // Snap to exact position
        transform.position = targetPos;

        // Assign new node
        currentNode = node;
        node.currentCoin = this;

        node.UpdateVisual();

        isMoving = false;
    }

    public bool IsMoving()
    {
        return isMoving;
    }

    public void SetColor(string newColor)
    {
        colorName = newColor;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        switch (newColor)
        {
            case "Red": sr.color = Color.red; break;
            case "Green": sr.color = Color.green; break;
            case "Blue": sr.color = Color.blue; break;
            case "Yellow": sr.color = Color.yellow; break;
            case "Purple": sr.color = new Color(0.5f, 0, 0.5f); break;
        }
    }
}
