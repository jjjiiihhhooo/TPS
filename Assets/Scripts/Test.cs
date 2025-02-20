using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private float noiseStrength = 0.1f;
    [SerializeField] private float objectHeight = 4.0f;

    [SerializeField] private Material material;

    [SerializeField] private float initalHeight;

    private void Awake()
    {
        material = GetComponentInChildren<Renderer>().material;
        initalHeight = transform.position.y + (objectHeight / 2.0f);
    }

    private void Update()
    {
        var time = Time.time * Mathf.PI * noiseStrength;

        float height = initalHeight; // 초기 높이를 최상단으로 설정
        height -= Mathf.Abs(Mathf.Sin(time)) * objectHeight; // 변경된 부분
        SetHeight(height);

        float t = transform.position.y - (objectHeight / 2.0f) + 0.1f;
        
        if(Input.GetKeyDown(KeyCode.T))
        {
            SetHeight(initalHeight);
        }

        //if (height <= t)
        //{
        //    SetHeight(initalHeight);
        //}
    }

    private void SetHeight(float height)
    {
        material.SetFloat("_CutoffHeight", height);
        material.SetFloat("_NoiseStrength", noiseStrength);
    }
}
