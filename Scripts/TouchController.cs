using UnityEngine;
using UnityEngine.EventSystems;

public class TouchControl : MonoBehaviour
{
    public Rigidbody2D rb;
    public float engineForce = 1000f;
    private bool isTouching = false;

    void Update()
    {
        if (isTouching)
        {
            Ascend();
        }
    }

    public void OnPointerDown()
    {
        isTouching = true;
    }

    public void OnPointerUp()
    {
        isTouching = false;
    }

     void  Ascend()
    {
        rb.AddForce(Vector2.up * engineForce * Time.deltaTime);
    }
}
