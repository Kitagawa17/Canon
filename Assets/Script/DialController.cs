using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialController : MonoBehaviour
{
    // Update is called once per frame
    int rotation;
    public void RightTurn()
    {
        transform.Rotate(0, 0, 30);
        rotation += 30;
        if (rotation >= 360)
            rotation = rotation % 360;
    }
    public void LeftTurn()
    {
        transform.Rotate(0, 0, -30);
        rotation -= 30;
        if (rotation < 0)
        {
            rotation += 360;
        }
    }
    public void SetRandomRotation()
    {
        int num = Random.Range(0, 12);
        rotation = num * 30;
        transform.Rotate(0, 0, num*30);
    }
    public int GetDialRotation()
    {
        return rotation;
    }
}
