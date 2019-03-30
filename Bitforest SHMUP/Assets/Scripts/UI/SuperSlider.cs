using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperSlider : MonoBehaviour 
{
	public Slider MainBar;
	public Slider BadBar;
	public Slider GoodBar;

	float _Value = 1f;
	public float Value
	{
		get
		{
			return _Value;
		}
		set
		{
			if (!IsSliding)
			{
				Timer = 0f;
			}
			if (value > _Value)
			{
				GoodBar.value = value;
				BadBar.value = value;
			}
			else
			{
				MainBar.value = value;
				GoodBar.value = value;
			}
			_Value = value;
		}
	}

	public float ResponsePause = 1f;
	public float AdjustmentTime = 1f;
	float Timer;
	bool IsSliding;

	void Start () 
	{
		MainBar.value = Value;
		GoodBar.value = Value;
		BadBar.value = Value;
	}
	
	void Update () 
	{
		if (MainBar.value != GoodBar.value || MainBar.value != BadBar.value)
		{
			Timer += Time.deltaTime;
			if (IsSliding)
			{
				float t = Timer / AdjustmentTime;
				if (MainBar.value == Value)
				{
					BadBar.value = Mathf.Lerp(BadBar.value, MainBar.value, t);
					if (BadBar.value <= MainBar.value)
					{
						BadBar.value = MainBar.value;
						IsSliding = false;
					}
				}
				else
				{
					MainBar.value = Mathf.Lerp(MainBar.value, GoodBar.value, t);
					if (MainBar.value >= GoodBar.value)
					{
						MainBar.value = GoodBar.value;
						IsSliding = false;
					}
				}
			}
			else if (Timer >= ResponsePause)
			{
				IsSliding = true;
				Timer = 0f;
			}
		}
	}
}
