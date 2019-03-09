using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bouncer : MonoBehaviour
{
    public GameObject shadow;
    public float rotationSpeed = 0.02f;
    public bool shooted;
    float pressedTimer;
    bool rotating;
    bool moving;
    Vector3 mousePos;
    Vector3 defaultMousePos;
    Vector3 prevMousePos;
    Vector3 worldmousePos;

    // Start is called before the first frame update
    void Start()
    {
        shooted = false;
        shadow.SetActive(false);
        defaultMousePos = new Vector3(-1, -1);
        mousePos = defaultMousePos;
        pressedTimer = 0f;
    }
    private void Update()
    {
        if (shooted) return;
        if (Input.GetButtonUp("Fire1"))
        {
            mousePos = defaultMousePos;
            rotating = false;
            moving = false;
            shadow.SetActive(false);
            pressedTimer = 0f;
        }
    }
    void OnMouseDrag()
    {
        if (shooted) return;
        worldmousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (rotating) { Rotate(); return; }
        if (moving) {Translate(); return; }
        if(mousePos == defaultMousePos) {
            mousePos = worldmousePos;
            return;
        }
        if(worldmousePos != mousePos)
        {
            rotating = true;
            moving = false;
        }
        else
        {
            pressedTimer += Time.deltaTime;
            if(pressedTimer >= 0.7f)
            {
                Handheld.Vibrate();
                moving = true;
                rotating = false;
                shadow.SetActive(true);
            }
        }
    }
    void Rotate()
    {
        float mouseYMoveDiff = worldmousePos.y - mousePos.y;
//        float mouseXMoveDiff = worldmousePos.x - mousePos.x;
        transform.Rotate(Vector3.forward * mouseYMoveDiff*rotationSpeed);
    }
    void Translate()
    {
        worldmousePos.z = 0;
        transform.position = worldmousePos;
    }
}
