using System;

namespace BlazingModal.Services;

public class ModalResult
{
    public object? Data { get; }
    public Type? DataType { get; }
    public bool Cancelled { get; }
    public bool Confirmed => !Cancelled;

    private ModalResult(object? data, Type? resultType, bool cancelled)
    {
        Data = data;
        DataType = resultType;
        Cancelled = cancelled;
    }

    public static ModalResult Ok<T>(T result) 
        => Ok(result, typeof(T));

    public static ModalResult Ok<T>(T result, Type? dataType) => new ModalResult(result, dataType, false);

    public static ModalResult Ok() => new ModalResult(null, null, false);
    
    public static ModalResult Cancel() => new ModalResult(null, null, true);
    
    public static ModalResult Cancel<T>(T payload) => new ModalResult(payload, null, true);
}