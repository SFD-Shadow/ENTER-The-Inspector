using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
	[SerializeField] private AudioMixer Mixer;
    [SerializeField] private Slider musicSlider;
	
	private void Start()
	{
		SetMusicVolume();
	}
	
 	public void SetMusicVolume()
	{
		float volume = musicSlider.value;
		Mixer.SetFloat("Music", Mathf.Log10(volume)*20);
	}
}
