using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class SpotlightIllumination : MonoBehaviour
{
    public float illuminationRange = 10f;
    public Color illuminationColor = Color.white;
    private Light spotlight;

    void Start()
    {
        spotlight = GetComponent<Light>();
        if (spotlight.type != LightType.Spot)
        {
            Debug.LogWarning("This script is intended for spotlights!");
        }
    }

    void Update()
    {
        IlluminateObjectsInRange();
    }

    void IlluminateObjectsInRange()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, illuminationRange);
        foreach (Collider hitCollider in hitColliders)
        {
            Renderer renderer = hitCollider.GetComponent<Renderer>();
            if (renderer != null)
            {
                Material material = renderer.material;
                material.EnableKeyword("_EMISSION");
                material.SetColor("_EmissionColor", illuminationColor * Mathf.Clamp01(1.0f - Vector3.Distance(transform.position, hitCollider.transform.position) / illuminationRange));
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, illuminationRange);
    }
}
