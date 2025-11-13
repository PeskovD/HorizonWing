using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PPE_Item : MonoBehaviour
{
    [Header("References")]
    public Volume globalVolume;

    [Header("Transition Settings")]

    [Range(0.1f, 10f)] public float transitionSpeed = 3f; // how fast it fades in/out

    [Header("Film Grain")]

    [Range(0f, 1f)] public float outsideGrain = 0.1f;
    [Range(0f, 1f)] public float insideGrain = 1f;

    [Header("Depth of Field (Blur)")]

    public bool blurOutside = false;
    public bool blurInside = true;

    [Range(0.01f, 1f)] public float dofFocusDistance = 0.5f;
    [Range(0.01f, 2f)] public float dofAperture = 0.1f;
    [Range(1f, 300f)] public float dofFocalLength = 50f;

    [Header("Vignette")]

    [Range(0f, 1f)] public float outsideVignette = 0.3f;
    [Range(0f, 1f)] public float insideVignette = 0.75f;

    [Header("Chromatic Aberration")]

    [Range(0f, 1f)] public float outsideChromatic = 0.05f;
    [Range(0f, 1f)] public float insideChromatic = 0.4f;

    [Header("Lens Distortion")]

    [Range(-1f, 1f)] public float outsideLens = 0f;
    [Range(-1f, 1f)] public float insideLens = -0.4f;

    private FilmGrain grain;
    private DepthOfField dof;
    private Vignette vignette;
    private ChromaticAberration chromatic;
    private LensDistortion lens;

    private bool inZone = false;

    void Start()
    {
        if (globalVolume != null)
        {
            globalVolume.profile.TryGet(out grain);
            globalVolume.profile.TryGet(out dof);
            globalVolume.profile.TryGet(out vignette);
            globalVolume.profile.TryGet(out chromatic);
            globalVolume.profile.TryGet(out lens);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            inZone = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            inZone = false;
    }

    void Update()
    {
        float t = Time.deltaTime * transitionSpeed;

        if (grain != null)
            grain.intensity.value = Mathf.Lerp(grain.intensity.value, inZone ? insideGrain : outsideGrain, t);

        if (vignette != null)
            vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, inZone ? insideVignette : outsideVignette, t);

        if (chromatic != null)
            chromatic.intensity.value = Mathf.Lerp(chromatic.intensity.value, inZone ? insideChromatic : outsideChromatic, t);

        if (lens != null)
            lens.intensity.value = Mathf.Lerp(lens.intensity.value, inZone ? insideLens : outsideLens, t);

        if (dof != null)
        {
            dof.active = inZone ? blurInside : blurOutside;
            if (inZone)
            {
                dof.focusDistance.value = dofFocusDistance;
                dof.aperture.value = dofAperture;
                dof.focalLength.value = dofFocalLength;
            }
        }
    }
}