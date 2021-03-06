using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class UnityExtension {
	/// <summary> 
	/// Find all objects in the scene of type T with the given name, even if they are inactive. If name isn't specified, 
	/// any objects of type T will be returned instead. 
	/// </summary> 
	/// <typeparam name="T">the type of object to find</typeparam> 
	/// <param name="obj">extension method, for ease of use</param> 
	/// <param name="name">the name of the object to find</param> 
	/// <returns>the objects of type T in the scene</returns> 
	public static List<T> FindAll<T>(this Object obj, string name = null) where T : Object {
		var objects = Resources.FindObjectsOfTypeAll<T>()
				.Where(o => o.hideFlags != HideFlags.NotEditable &&
						o.hideFlags != HideFlags.HideAndDontSave &&
						(name == null || o.name == name));
		//#if UNITY_EDITOR
		//objects = objects.Where(o => UnityEditor.EditorUtility.IsPersistent(o)); 
		//#endif
		return objects.ToList();
	}

	/// <summary>
	/// Find the first GameObject with the given name, if it is loaded with scene.
	/// </summary>
	/// <param name="obj">extension method, for ease of use</param>
	/// <param name="name">the name of the object to find</param>
	/// <returns>GameObject with the given name</returns>
	public static GameObject FindFirst(this Object obj, string name = null) =>
			obj.FindAll<GameObject>(name).FirstOrDefault(o => o.scene.isLoaded);

	/// <summary>
	/// Find the first GameObject with the given name, if it is loaded with scene, and return component T.
	/// </summary>
	/// <typeparam name="T">the type of object to find</typeparam>
	/// <param name="obj">extension method, for ease of use</param>
	/// <param name="name">the name of the object to find</param>
	/// <returns>Component with given type <T></returns>
	public static T FindFirst<T>(this Object obj, string name = null) where T : Object {
		var gameObject = obj.FindFirst(name);
		return gameObject == null ? null : gameObject.GetComponent<T>();
	}
}