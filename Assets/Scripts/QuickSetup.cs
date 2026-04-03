using UnityEngine;

public class QuickSetup : MonoBehaviour
{
    public Coin[] coins;
    public Node[] nodes;

    void Start()
    {
        for (int i = 0; i < coins.Length; i++)
        {
            coins[i].SetNode(nodes[i]);
        }
    }
}
