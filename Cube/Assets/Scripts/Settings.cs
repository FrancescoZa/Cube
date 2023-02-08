using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Settings : MonoBehaviour
{

    public Slider volumeSlider;
	public Toggle toggle;
	public Toggle toggleEasy;
	public Toggle toggleMedium;
	public Toggle toggleDifficult;


	public Toggle toggleWASD;
	public Toggle toggleArrows;
	public Toggle toggleShift;
	public Toggle toggleEnter;


	// Start is called before the first frame update
	void Start()
    {


		if (!PlayerPrefs.HasKey("musicVolume")) //se non ho mai salvato lo setto al 100%
		{
            PlayerPrefs.SetFloat("musicVolume", 1);
		}

		if (!PlayerPrefs.HasKey("soundsEffect")) //se non ho mai salvato lo setto al 100%
		{
			PlayerPrefs.SetInt("soundsEffect", 1);
		}

		if (!PlayerPrefs.HasKey("numeroVite")) //se non ho mai salvato lo setto a 3
		{
			PlayerPrefs.SetInt("numeroVite", 3);
		}

		if (!PlayerPrefs.HasKey("input")) //se non ho mai salvato lo setto le frecce
		{
			PlayerPrefs.SetString("input", "arrows");
		}

		if (!PlayerPrefs.HasKey("shoot")) //se non ho mai salvato lo setto shift
		{
			PlayerPrefs.SetString("shoot", "shift");
		}

		load();

	}

	public void valueChangedEasy()
	{
		if (toggleEasy.isOn == true)
		{
			toggleMedium.isOn = false;
			toggleDifficult.isOn = false;

		}
	}

	public void valueChangedMedium()
	{
		if (toggleMedium.isOn == true)
		{
			toggleEasy.isOn = false;
			toggleDifficult.isOn = false;

		}
	}

	public void valueChangedDifficult()
	{
		if (toggleDifficult.isOn == true)
		{
			toggleMedium.isOn = false;
			toggleEasy.isOn = false;

		}
	}

	public void valueChangedWASD()
	{
		if (toggleWASD.isOn == true)
		{
			toggleArrows.isOn = false;

		}
	}

	public void valueChangedArrows()
	{
		if (toggleArrows.isOn == true)
		{
			toggleWASD.isOn = false;

		}
	}

	public void valueChangedShift()
	{
		if (toggleShift.isOn == true)
		{
			toggleEnter.isOn = false;
		}
	}

	public void valueChangedEnter()
	{
		if (toggleEnter.isOn == true)
		{
			toggleShift.isOn = false;

		}
	}


	public void back()
	{
		save();
		SceneManager.LoadScene(0);	//menu
	}

	private void load()
	{

		toggle.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("soundsEffect"));


		volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");

		//lives

		if(PlayerPrefs.GetInt("numeroVite") == 3)
		{
			toggleEasy.isOn = true;
			toggleMedium.isOn = false;
			toggleDifficult.isOn = false;
		}else if (PlayerPrefs.GetInt("numeroVite") == 2)
		{
			toggleEasy.isOn = false;
			toggleMedium.isOn = true;
			toggleDifficult.isOn = false;
		}
		else
		{
			toggleEasy.isOn = false;
			toggleMedium.isOn = false;
			toggleDifficult.isOn = true;
		}

		if (PlayerPrefs.GetString("input").Equals("WASD"))
		{
			toggleWASD.isOn = true;
			toggleArrows.isOn = false;
		}
		else
		{
			toggleWASD.isOn = false;
			toggleArrows.isOn = true;
		}

		if (PlayerPrefs.GetString("shoot").Equals("shift"))
		{
			toggleShift.isOn = true;
			toggleEnter.isOn = false;
		}
		else
		{
			toggleShift.isOn = false;
			toggleEnter.isOn = true;
		}

	}

	private enum level{
		easy = 3,
		medium = 2,
		difficult = 1
	}

	delegate void saveImp(String impostazione);
	saveImp saveSettings;

	void saveMusicImp(String fieldName)
	{
		PlayerPrefs.SetFloat(fieldName, volumeSlider.value);

	}

	void saveSoundsImp(String fieldName)
	{

		if (toggle.isOn == true)
		{
			PlayerPrefs.SetInt(fieldName, 1);

		}
		else
		{
			PlayerPrefs.SetInt(fieldName, 0);

		}
	}

	void saveLevelImp(String fieldName)
	{
		if (toggleEasy.isOn == true)
		{
			PlayerPrefs.SetInt(fieldName, (int)level.easy);

		}

		if (toggleMedium.isOn == true)
		{
			PlayerPrefs.SetInt(fieldName, (int)level.medium);

		}

		if (toggleDifficult.isOn == true)
		{
			PlayerPrefs.SetInt(fieldName, (int)level.difficult);

		}
	}

	void saveInputImp(String fieldName)
	{
		if (toggleWASD.isOn == true)
		{
			PlayerPrefs.SetString(fieldName, "WASD");

		}
		else
		{
			PlayerPrefs.SetString(fieldName, "arrows");

		}


	}

	void saveShootImp(String fieldName)
	{
		if (toggleEnter.isOn == true)
		{
			PlayerPrefs.SetString(fieldName, "enter");

		}
		else
		{
			PlayerPrefs.SetString(fieldName, "shift");

		}
	}

	private void save()
	{

		saveSettings = saveSoundsImp;
		saveSettings("soundsEffect");

		saveSettings = saveMusicImp;
		saveSettings("musicVolume");

		saveSettings = saveInputImp;
		saveSettings("input");

		saveSettings = saveLevelImp;
		saveSettings("numeroVite");

		saveSettings = saveShootImp;
		saveSettings("shoot");

		
	}

}
