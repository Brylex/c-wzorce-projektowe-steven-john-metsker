using System;
using System.Reflection;

public delegate void ChangeHandler();

/// <summary>
/// Instancje tej klasy sk�aduj� w�a�ciwo�� obiektu i informuj�
/// zainteresowane obiekty o zmianach.
/// </summary>
public class PropertyHolder
{
    private Object _obj;
    private PropertyInfo _prop;
    public event ChangeHandler Change;
    public PropertyHolder (Object o, String propertyName)
    {
        _obj = o;
        _prop = _obj.GetType().GetProperty(propertyName);
    }
    public Object Value
    {
        get
        { 
            return _prop.GetValue(_obj, null);
        }
        set 
        {
            _prop.SetValue(_obj, value, null);
            Change();
        }
    }
}