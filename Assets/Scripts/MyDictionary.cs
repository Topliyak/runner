using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
class MyDictionary<T1, T2>
{
	[SerializeField] private List<MyKeyValuePair<T1, T2>> _keyValuePairsList;

	public MyDictionary()
	{
		_keyValuePairsList = new List<MyKeyValuePair<T1, T2>>();
	}

	public int Count => _keyValuePairsList.Count;

	public T2 this[T1 key] => _keyValuePairsList.First(pair => pair.key.Equals(key)).value;

	public void Add(T1 key, T2 value)
	{
		_keyValuePairsList.Add(new MyKeyValuePair<T1, T2>(key, value));
	}

	public void Remove(T1 key)
	{
		var pair = _keyValuePairsList.Find(pair => pair.key.Equals(key));
		_keyValuePairsList.Remove(pair);
	}

	public IEnumerator<MyKeyValuePair<T1, T2>> GetEnumerator() => _keyValuePairsList.GetEnumerator();
}
