using Unity.VisualScripting;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        anim.SetTrigger("Touched");
    }
}
