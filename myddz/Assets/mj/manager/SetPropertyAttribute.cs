using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;

class SetPropertyAttribute : Attribute
{
	public string Name { get; private set; }
	public bool IsDirty { get; set; }
	
	public SetPropertyAttribute(string name)
	{
		this.Name = name;
	}
}


