using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
struct MyKeyValuePair<T1, T2>
{
	public T1 key;
	public T2 value;

	public MyKeyValuePair(T1 key, T2 value)
	{
		this.key = key;
		this.value = value;
	}

	public override bool Equals(object obj)
	{
		MyKeyValuePair<T1, T2>? myKeyValuePair = obj as MyKeyValuePair<T1, T2>?;

		if (myKeyValuePair.HasValue == false)
			return false;

		return myKeyValuePair.Value.key.Equals(key) && myKeyValuePair.Value.value.Equals(value);
	}
}
