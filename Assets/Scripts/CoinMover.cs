using UnityEngine;
using System.Collections;

public class CoinMover : MonoBehaviour
{
    public Node emptyNode;

    private bool isBusy = false;

    public GameObject GM;
    public AudioSource CoinMoveSound;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleClick();
        }
    }

    void HandleClick()
    {
        if (isBusy) return;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
        //Debug.Log("The HIT is : " + hit.transform.gameObject.name);

        if (hit.collider == null) return;

        Coin coin = hit.collider.GetComponent<Coin>();
        if (coin == null)
        {
            //Debug.Log("The Coin is NULL");
            return;
        }

        TryMove(coin);
    }

    void TryMove(Coin coin)
    {

        if (coin == null || coin.currentNode == null || emptyNode == null)
        {
            Debug.Log(" Missing references!");
            return;
        }

        Node coinNode = coin.currentNode;

        if (!coinNode.connectedNodes.Contains(emptyNode))
        {
            Debug.Log(" Invalid move — no empty node nearby");
            return;
        }

        StartCoroutine(MoveRoutine(coin));
        CoinMoveSound.Play();

    }

    IEnumerator MoveRoutine(Coin coin)
    {
        isBusy = true;

        Node oldNode = coin.currentNode;

        coin.SetNode(emptyNode);

        // wait until movement completes
        while (coin.IsMoving())
            yield return null;

        emptyNode = oldNode;

        isBusy = false;
        GM.GetComponent<GameManager>().CheckWin();
        
    }
}
