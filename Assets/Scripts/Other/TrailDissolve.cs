using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailDissolve : MonoBehaviour
{
    [SerializeField] private float noiseStrength = 0.1f;
    [SerializeField] private float objectHeight = 4.0f;

    [SerializeField] private Material material;

    [SerializeField] private float initalHeight;

    private float height;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
        height = transform.position.y + 2f;
    }

    private void Update()
    {
        //var time = Time.time * Mathf.PI * noiseStrength;

        //float height = transform.position.y + (objectHeight / 2.0f); // 초기 높이를 최상단으로 설정
        //height -= Mathf.Abs(Mathf.Sin(time)) * objectHeight; // 투명화 효과 적용
        //SetHeight(height);

        //float t = transform.position.y - (objectHeight / 2.0f) + 0.1f;

        if(height > 0)
        {
            height -= Time.deltaTime;
            if (height < 0) height = 0;

            SetHeight(height);
        }

        if (height <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void SetHeight(float height)
    {
        material.SetFloat("_CutoffHeight", height);
        material.SetFloat("_NoiseStrength", noiseStrength);
    }
}
