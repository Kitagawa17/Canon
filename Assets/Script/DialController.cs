using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialController : MonoBehaviour
{
    // Update is called once per frame
    int rotation;
    [SerializeField] int dialNUmber;//Ž©g‚Ìƒ_ƒCƒ„ƒ‹‚Ì”Ô†
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
        int num;
        if (dialNUmber==0||dialNUmber==2||dialNUmber==4)
            num = Random.Range(0, 6);
        else
            num = Random.Range(6, 12);
        rotation = num * 30;
        transform.Rotate(0, 0, num*30);
    }
    public int GetDialRotation()
    {
        return rotation;
    }
}
