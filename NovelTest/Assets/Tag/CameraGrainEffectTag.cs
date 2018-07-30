using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class CameraGrainEffectTag : MonoBehaviour, ITag
{
	PostProcessingBehaviour behaviour;
	const string intensity = "intensity";
	const string size = "size";
	const string contribution = "con";
	const string coloerd = "is_color";
	Dictionary<string, string> kvps = new Dictionary<string, string>();

    public void Create(string str)
    {
		behaviour = FindObjectOfType<PostProcessingBehaviour>();
		var commands = str.Split(' ');
        for (var i = 1; i < commands.Length; i++)
        {
            var kvp = commands[i].Replace("=", " ").Split(' ');
            kvps.Add(kvp[0], kvp[1]);
        }
    }

    public void Fire()
    {
		behaviour.profile.grain.enabled = true;
		var grainIntensity = kvps.ContainsKey(intensity) ? float.Parse(kvps[intensity]) : 0;
		var grainSize = kvps.ContainsKey(size) ? float.Parse(kvps[size]) : 0.3f;
		var grainContribution = kvps.ContainsKey(contribution) ? float.Parse(kvps[contribution]) : 0;
		var isColor = kvps.ContainsKey(coloerd) ? bool.Parse(kvps[coloerd]) : true;

		var setting = new GrainModel.Settings();
		setting.intensity = grainIntensity;
		setting.size = grainSize;
		setting.luminanceContribution = grainContribution;
		setting.colored = isColor;

		behaviour.profile.grain.settings = setting;

    }
}