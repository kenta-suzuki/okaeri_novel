using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class CameraVignetteEffectTag : MonoBehaviour, ITag
{
	PostProcessingBehaviour behaviour;
	const string color = "color";
	const string intensity = "intensity";
	const string smooth = "smooth";
	const string round = "round";
	const string rounded = "is_round";
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
		behaviour.profile.vignette.enabled = true;
		var vigColor = kvps.ContainsKey(intensity) ? kvps[intensity] : "BLACK";
        var vigIntensity = kvps.ContainsKey(intensity) ? float.Parse(kvps[intensity]) : 0;
		var vigSmooth = kvps.ContainsKey(smooth) ? float.Parse(kvps[smooth]) : 0;
		var vigRound = kvps.ContainsKey(round) ? float.Parse(kvps[round]) : 0;
		var isRound = kvps.ContainsKey(rounded) ? bool.Parse(kvps[rounded]) : true;

		var setting = new VignetteModel.Settings();
		setting.intensity = vigIntensity;
		setting.color = ConvertColor(vigColor);
		setting.smoothness = vigSmooth;
		setting.rounded = isRound;
		setting.roundness = vigRound;
		setting.center = new Vector2(0.5f, 0.5f);

		behaviour.profile.vignette.settings = setting;
    }

	Color ConvertColor(string colorString)
	{
		switch(colorString)
		{
			case ColorConfig.BLACK: return Color.black;
			case ColorConfig.BLUE : return Color.blue;
			case ColorConfig.GRAY: return Color.gray;
			case ColorConfig.GREEN: return Color.green;
			case ColorConfig.RED: return Color.red;
			case ColorConfig.WHITE: return Color.white;
			case ColorConfig.YELLOW: return Color.yellow;
			default: return Color.black;
		}
	}
}

public struct ColorConfig
{
	public const string BLACK = "BLACK";
	public const string BLUE = "BLUE";
	public const string RED = "RED";
	public const string WHITE = "WHITE";
	public const string GRAY = "GRAY";
	public const string GREEN = "GREEN";
	public const string YELLOW = "YELLOW";
}