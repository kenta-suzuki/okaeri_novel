using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class CameraEffectStopTag : MonoBehaviour, ITag
{
    PostProcessingBehaviour behaviour;

    public void Create(string str)
    {
		behaviour = FindObjectOfType<PostProcessingBehaviour>();
    }

    public void Fire()
    {
		behaviour.profile.grain.enabled = false;
		behaviour.profile.vignette.enabled = false;
		behaviour.profile.colorGrading.enabled = false;
    }
}