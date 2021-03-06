using UnityEngine;

public static class Vector2Extension {
	public enum Axis {
		X = 0,
		Y = 1,
		Pitch = 0,
		Yaw = 1,
	}

	public static Vector2 Set(this ref Vector2 vector, Vector2 newVector) {
		vector.x = newVector.x;
		vector.y = newVector.y;
		return vector;
	}

	public static Vector2 SwapAxises(this Vector2 vector) {
		var temp = vector[(int) Axis.X];
		vector[(int) Axis.X] = vector[(int) Axis.Y];
		vector[(int) Axis.Y] = temp;
		return vector;
	}

	public static Vector2 Invert(this Vector2 vector, params Axis[] axises) {
		foreach (var axis in axises) { vector[(int) axis] = -vector[(int) axis]; }
		return vector;
	}
}

public static class Vector3Extension {
	public enum Axis {
		X = 0,
		Y = 1,
		Z = 2,
		Pitch = 0,
		Yaw = 1,
		Roll = 2,
	}

	public static Vector3 Set(this ref Vector3 vector, Vector3 newVector) {
		vector.x = newVector.x;
		vector.y = newVector.y;
		vector.z = newVector.z;
		return vector;
	}

	public static Vector3 SwapAxises(this Vector3 vector, Axis axis1 = Axis.X, Axis axis2 = Axis.Y) {
		var temp = vector[(int) axis1];
		vector[(int) axis1] = vector[(int) axis2];
		vector[(int) axis2] = temp;
		return vector;
	}

	public static Vector3 Invert(this Vector3 vector, params Axis[] axises) {
		foreach (var axis in axises) { vector[(int) axis] = -vector[(int) axis]; }
		return vector;
	}
}