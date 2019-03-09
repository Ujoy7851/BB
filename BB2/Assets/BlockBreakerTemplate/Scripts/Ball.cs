using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour 
{
    public float ballSpeed;
    public Rigidbody2D rb2d;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Reset()
    {
        rb2d.velocity = Vector3.zero;
    }
    public void AddVel(Vector3 vector)
    {
        rb2d.velocity = vector * ballSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Floor")
        {
            Reset();
            Invoke("LevelEnd", .5f);
        }
    }
    void LevelEnd()
    {
        GameManager.manager.NextLine();
    }
}
