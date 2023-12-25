﻿using UnityEngine;
using UnityEngine.UI;

namespace InsaneSystems.HealthbarsKit.UI
{
	/// <summary> Healthbar class draws healthbar on UI above target object. Also controls state of healthbar like health value, color, etc. </summary>
	public sealed class UIHealthbar : MonoBehaviour
	{
		[SerializeField] Image fillImage;

		RectTransform rectTransform;

		Transform target;
		float maxHealthValue;
		float targetHeight = 1f;

		void Awake()
		{
			rectTransform = GetComponent<RectTransform>();
			rectTransform.anchorMin = new Vector2(0, 0);
			rectTransform.anchorMax = new Vector2(0, 0);
		}

		/// <summary> We using cusstom method for update, which called on all healthbars from HealthbarsController. It increases performance for a bit on big healthbars count. </summary>
		public void OnUpdate()
		{
			if (!target)
			{
				Destroy(gameObject);
				return;
			}

			var barWorldPos = target.position + Vector3.up * targetHeight;
			rectTransform.anchoredPosition = UIHealthbars.Instance.CachedCamera.WorldToScreenPoint(barWorldPos);
		}

		public void SetColorByFillValue()
		{
			fillImage.color = UIHealthbars.GetColor(fillImage.fillAmount);
		}

		public void SetupWithTarget(Transform newTarget, float targetMaxHealth)
		{
			target = newTarget;
			maxHealthValue = targetMaxHealth;
		}

		public void SetTargetHeight(float newHeight) => targetHeight = newHeight;

		/// <summary> This method will be called by a event on your characters objects (dont forget to code it, see documentation) and update health to actual value. </summary>
		/// <param name="healthValue">Actual health of character.</param>
		public void OnHealthChanged(float healthValue)
		{
			fillImage.fillAmount = healthValue / maxHealthValue;

			if (UIHealthbars.Instance.SetColorByHealthPecents)
				SetColorByFillValue();

			if (fillImage.fillAmount <= 0)
				Destroy(gameObject);

			if (UIHealthbars.Instance.HideHealthbarsIfHealthFull)
				gameObject.SetActive(fillImage.fillAmount < 1f);
		}
	}
}