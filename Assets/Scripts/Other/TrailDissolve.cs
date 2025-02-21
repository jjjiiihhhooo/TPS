using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailDissolve : MonoBehaviour
{
    [SerializeField] private float noiseStrength = 0.1f;
    [SerializeField] private Material material;

    private float height;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
        height = transform.position.y + 2f;
    }

    private void Update()
    {
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
