﻿// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using FMOD;
using FMOD.Studio;
using UnityEngine;
using UnityEngine.Events;
using static Depra.Spine.FMOD.Runtime.Common.Constants;

namespace Depra.Spine.FMOD.Runtime.Utils
{
	[AddComponentMenu(MENU_NAME, DEFAULT_ORDER)]
	internal sealed class FMODEventCallbacks : FMODEventDecorator
	{
		private const string MENU_NAME = MODULE_PATH + "/" + nameof(FMODEventCallbacks);

		[SerializeField] private Pair[] _callbacks;

		public override void Decorate(string eventName, EventInstance eventInstance)
		{
			foreach (var callback in _callbacks)
			{
				callback.Subscribe(eventInstance);
			}
		}

		[Serializable]
		private sealed class Pair
		{
			[SerializeField] private EVENT_CALLBACK_TYPE _eventType;
			[SerializeField] private UnityEvent<RESULT> _callback;

			public void Subscribe(EventInstance eventInstance)
			{
				eventInstance.setCallback((_, _, _) => Callback(), _eventType);
				return;

				RESULT Callback()
				{
					_callback?.Invoke(RESULT.OK);
					return RESULT.OK;
				}
			}
		}
	}
}