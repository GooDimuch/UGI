using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class PrimitiveExtension {
	public static bool Invert(this ref bool value, bool changeValue = true) {
		if (!changeValue) { return !value; }
		value = !value;
		return value;
	}

	public static int Invert(this ref int value, bool changeValue = true) {
		if (!changeValue) { return -value; }
		value = -value;
		return value;
	}

	public static float Invert(this ref float value, bool changeValue = true) {
		if (!changeValue) { return -value; }
		value = -value;
		return value;
	}

	public static int Abs(this ref int value, bool changeValue = true) {
		if (!changeValue) { return Math.Abs(value); }
		value = Math.Abs(value);
		return value;
	}

	public static float Abs(this ref float value, bool changeValue = true) {
		if (!changeValue) { return Math.Abs(value); }
		value = Math.Abs(value);
		return value;
	}

	public static int TI(this bool value) => value ? 1 : 0;
	public static int TI(this float value) => (int) value;

	public static string TS(this bool value) => value.ToString();
	public static string TS(this int value) => value.ToString();
	public static string TS(this float value) => value.ToString();

	public static bool TB(this int value) => value != 0;
	public static bool TB(this float value) => Math.Abs(value) > float.Epsilon;

	public static int On(this ref int value, params int[] flags) {
		value = flags.Aggregate(value, (current, flag) => current | 1 << flag);
		return value;
	}

	public static int OnOnly(this ref int value, params int[] flags) {
		value.OffAll();
		return value.On(flags);
	}

	public static int OnAll(this ref int value) {
		value = int.MaxValue;
		return value;
	}

	public static int Off(this ref int value, params int[] flags) {
		value &= ~flags.Aggregate(0, (current, flag) => current | 1 << flag);
		return value;
	}

	public static int OffAll(this ref int value) {
		value = 0;
		return value;
	}

	public static void Set(this ref int value, bool b, params int[] flags) {
		if (b) { value.On(flags); }
		else { value.Off(flags); }
	}

	public static bool Contain(this ref int value, int flag) => ((1 << flag) & value) == 1 << flag;

	public static void SetArray<T, E>(T[] value, params E[] newValue) => SetArray(0, value, newValue);

	public static void SetArray<T, E>(int startIndex, T[] value, params E[] newValue) {
		for (var i = 0; i < Mathf.Min(value.Length - startIndex, newValue.Length); i++) {
			value[i + startIndex] = (T) Convert.ChangeType(newValue[i], typeof(T));
		}
	}

	public static void ClearArray<T>(T[] value) { Array.Clear(value, 0, value.Length); }

	public static void ClearArray<T>(T[] value, T defaultValue) {
		for (var i = 0; i < value.Length; i++) { value[i] = defaultValue; }
	}

	public static int IndexOfMin<T>(this IList<T> self) where T : IComparable<T> {
		if (self == null) { throw new ArgumentNullException("self"); }

		if (self.Count == 0) { throw new ArgumentException("List is empty.", "self"); }

		var min = self[0];
		var minIndex = 0;

		for (var i = 1; i < self.Count; ++i) {
			if (self[i].CompareTo(min) == -1) {
				min = self[i];
				minIndex = i;
			}
		}

		return minIndex;
	}

	public static int IndexOfMax<T>(this IList<T> self) where T : IComparable<T> {
		if (self == null) { throw new ArgumentNullException("self"); }

		if (self.Count == 0) { throw new ArgumentException("List is empty.", "self"); }

		var max = self[0];
		var maxIndex = 0;

		for (var i = 1; i < self.Count; ++i) {
			if (self[i].CompareTo(max) == 1) {
				max = self[i];
				maxIndex = i;
			}
		}

		return maxIndex;
	}
}