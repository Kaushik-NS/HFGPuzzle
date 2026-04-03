using UnityEngine;
using System.Collections.Generic;

public class Node : MonoBehaviour
{
    public List<Node> connectedNodes = new List<Node>();

    public Coin currentCoin;

    public string targetColor;
    public SpriteRenderer baseRenderer;

    public bool IsEmpty()
    {
        return currentCoin == null;
    }

    public void UpdateVisual()
    {
        if (baseRenderer == null) return;

        baseRenderer.enabled = IsEmpty();
    }
}
