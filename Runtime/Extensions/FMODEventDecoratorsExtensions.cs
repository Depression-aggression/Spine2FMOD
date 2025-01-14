﻿// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Generic;
using Depra.Spine.FMOD.Runtime.Utils;
using FMOD.Studio;

namespace Depra.Spine.FMOD.Runtime.Extensions
{
	internal static class FMODEventDecoratorsExtensions
	{
		public static void Decorate(this IEnumerable<FMODEventExtension> self, string eventName,
			EventInstance eventInstance)
		{
			foreach (var decorator in self)
			{
				decorator.Apply(eventName, eventInstance);
			}
		}
	}
}