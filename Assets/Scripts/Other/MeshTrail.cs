using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshTrail : MonoBehaviour
{
    [Header("Mesh Related")]
    public float meshRefreshRate = 0.1f;
    public float meshDestroyDelay = 3f;
    public Transform spawnTransform;

    [Header("Shader Related")]
    public Material mat;
    public string shaderVarRef;
    public float shaderVarRate = 0.1f;
    public float shaderVarRefreshRate = 0.05f;

    [Header("Dissolve")]
    [SerializeField] private Material dissolveMat;

    private SkinnedMeshRenderer skinnedMeshRenderer;
    private GameObject trailObject;
    private GameObject dissolveObject;
    private Mesh mesh;
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;

    private Coroutine trailCor;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        if (skinnedMeshRenderer == null)
            skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();

        trailObject = new GameObject();

        meshRenderer = trailObject.AddComponent<MeshRenderer>();
        meshFilter = trailObject.AddComponent<MeshFilter>();
        meshRenderer.material = mat;

        meshRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        mesh = new Mesh();
    }

    public void DashTrail()
    {
        trailObject.transform.SetPositionAndRotation(spawnTransform.position, spawnTransform.rotation);
        skinnedMeshRenderer.BakeMesh(mesh);
        meshFilter.mesh = mesh;

        dissolveObject = Instantiate(trailObject);
        dissolveObject.GetComponent<MeshRenderer>().material = dissolveMat;
        dissolveObject.AddComponent<TrailDissolve>();

        dissolveObject.transform.SetPositionAndRotation(spawnTransform.position, spawnTransform.rotation);

        if(trailCor != null)
        {
            StopCoroutine(trailCor);
            trailCor = null;
        }

        meshRenderer.material.SetFloat(shaderVarRef, 1f);

        trailCor = StartCoroutine(AnimateMaterialFloat(meshRenderer.material, 0, shaderVarRate, shaderVarRefreshRate));
    }

    private IEnumerator AnimateMaterialFloat(Material mat, float goal, float rate, float refrehRate)
    {
        float valueToAnimate = mat.GetFloat(shaderVarRef);

        while(valueToAnimate > goal)
        {
            valueToAnimate -= rate;
            mat.SetFloat(shaderVarRef, valueToAnimate);
            yield return Utils.GetWaitForSeconds(refrehRate);
        }
    }
}
