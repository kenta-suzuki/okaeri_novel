using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagConfig
{
	public const string CHARA_LOAD = "chara_load";
	public const string BG_LOAD = "bg_load";
	public const string LOAD_EFFECT = "load_effect";
	public const string TITLE_SHOW = "title_show";
	public const string WAIT = "wait";
	public const string TITLE_HIDE = "title_hide";
	public const string BG_SHOW = "bg_show";
	public const string CHARA_SHOW = "chara_show";
	public const string BGM_PLAY = "bgm_play";
	public const string NAME = "name";
	public const string MSG = "msg";
	public const string BGM_STOP = "bgm_stop";
	public const string EFFECT_SHOW = "effect_show";
	public const string SE_PLAY = "se_play";
	public const string CHARA_HIDE = "chara_hide";
	public const string BG_HIDE = "bg_hide";
	public const string START = "start";
	public const string END = "end";
	public const string P = "p";
	public const string ER = "er";

	public const string CAMERA_VIGNETTE = "vignette";
	public const string CAMERA_COLOR = "color";
	public const string CAMERA_GRAIN = "grain";
	public const string CAMERA_EFFECT_STOP = "camera_effect_stop";
}

public class TagCreater 
{
	public static ITag Create( string str)
	{
		ITag tag = null;
		var strTag = CreateTag(str);
		var value = CreateValue(str);

		switch(strTag)
		{
			case TagConfig.START:
				tag = new StartTag();
                break;
			case TagConfig.BGM_PLAY: 
				tag = new BgmPlayTag();
				break;
			case TagConfig.BGM_STOP:
				tag = new BgmStopTag();
				break;
			case TagConfig.EFFECT_SHOW:
				tag = new EffectShowTag();
                break;
			case TagConfig.END:
				tag = new EndTag();
                break;
			case TagConfig.CHARA_LOAD:
				tag = new CharaLoadTag();
                break;
			case TagConfig.BG_LOAD:
				tag = new BgLoadTag();
                break;
			case TagConfig.LOAD_EFFECT:
				tag = new LoadEffectTag();
                break;
			case TagConfig.MSG:
				tag = new MsgTag();
                break;
			case TagConfig.NAME:
				tag = new NameTag();
                break;
			case TagConfig.SE_PLAY:
				tag = new SePlayTag();
                break;
			case TagConfig.BG_SHOW:
				tag = new BgShowTag();
                break;
			case TagConfig.TITLE_HIDE:
				tag = new TitleHideTag();
                break;
			case TagConfig.TITLE_SHOW:
                tag = new TitleShowTag();
				break;
			case TagConfig.CHARA_SHOW:
				tag = new CharaShowTag();
				break;
			case TagConfig.BG_HIDE:
				tag = new BgHideTag();
                break;
			case TagConfig.CHARA_HIDE:
				tag = new CharaHideTag();
                break;
			case TagConfig.WAIT:
				tag = new WaitTag();
                break;
			case TagConfig.P:
				tag = new PTag();
                break;
			case TagConfig.ER:
				tag = new ErTag();
                break;
			case TagConfig.CAMERA_GRAIN:
				tag = new CameraGrainEffectTag();
                break;
			case TagConfig.CAMERA_COLOR:
				tag = new CameraColorEffectTag();
                break;
			case TagConfig.CAMERA_VIGNETTE:
				tag = new CameraVignetteEffectTag();
                break;
			case TagConfig.CAMERA_EFFECT_STOP:
				tag = new CameraEffectStopTag();
                break;
		}
        if(tag == null)
		{
			Debug.LogError(strTag + "にマッチするタグはありませんでした");
			return null;
		}

		tag.Create(value);
		return tag;
	}

    static string CreateTag(string str)
	{
		var paseStr = str.Replace("[", "").Replace("]", "");
		return paseStr.Split(' ')[0];
	}

    static string CreateValue(string str)
	{
		var paseStr = str.Replace("[", "").Replace("]", "");
		return paseStr;
	}
}
