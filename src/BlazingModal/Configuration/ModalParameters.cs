using System.Collections;
using System.Collections.Generic;

namespace BlazingModal;

public class ModalParameters : IEnumerable<KeyValuePair<string, object?>>
{
    internal readonly Dictionary<string, object?> Parameters = new Dictionary<string, object?>();

    public ModalParameters Add(string parameterName, object? value)
    {
        Parameters[parameterName] = value;
        return this;
    }

    public T? Get<T>(string parameterName)
    {
        if (!Parameters.TryGetValue(parameterName, out object? value))
        {
            return default;
        }
            
        if (value is T val)
        {
            return val;
        }

        return default;
    }

    public T? TryGet<T>(string parameterName)
    {
        if (!Parameters.TryGetValue(parameterName, out object? value))
        {
            return default;
        }
            
        if (value is T val)
        {
            return val;
        }

        return default;
    }

    public IEnumerator<KeyValuePair<string, object?>> GetEnumerator() => Parameters.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator()=> Parameters.GetEnumerator();
}