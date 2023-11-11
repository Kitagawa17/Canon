using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�y���̖_�̈ړ�
public class RodController : MonoBehaviour
{
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector3(rectTransform.anchoredPosition.x+speed, rectTransform.anchoredPosition.y);
        if (rectTransform.anchoredPosition.x > 357)
            rectTransform.anchoredPosition = new Vector3(-369, rectTransform.anchoredPosition.y);
    }
}
