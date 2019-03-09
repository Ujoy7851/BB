using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    const float angleDiff = 10 * Mathf.Deg2Rad;
    public float radius = 2.5f;
    public float start = 30 * angleDiff;
    public float end = 150 * Mathf.Deg2Rad;
    
    bool shot;
    Vector2 ballPos;
    Vector2 ballAngle;
    Ball ball;
    float prevAngle;
    private void Awake()
    {
        ball = FindObjectOfType<Ball>();
    }
    // Start is called before the first frame update
    void Start()
    {
        prevAngle = 0;
        Setup();
    }
    private void Setup()
    {
        float currAngle = Random.Range(start, end);          //choose a random angle
        float angleDifference = currAngle - prevAngle;  //if the difference between prev angles is smaller than 10 degrees
        if(Mathf.Abs(angleDifference) < angleDiff)      //add that much difference to the curr angle
        {
            currAngle += angleDifference;
            currAngle = Mathf.Clamp(currAngle, start, end);
        }
        prevAngle = currAngle;
        //set the ball position;
        ballPos = new Vector2(transform.position.x + Mathf.Cos(currAngle) * radius, transform.position.y + Mathf.Sin(currAngle) * radius);
        ballAngle = new Vector2(Mathf.Cos(currAngle), Mathf.Sin(currAngle));
        ball.transform.position = ballPos;
    }
    public void Shoot()
    {
        if (shot) return;
        foreach (Bouncer bouncer in FindObjectsOfType<Bouncer>())
        {
            bouncer.shooted = true;
        }
        shot = true;
        ball.AddVel(ballAngle);
    }
    public void BallReturns()
    {
        shot = false;
        Setup();
    }
}
