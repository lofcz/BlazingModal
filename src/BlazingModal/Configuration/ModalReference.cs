using System;
using System.Threading.Tasks;
using BlazingModal.Services;
using Microsoft.AspNetCore.Components;

namespace BlazingModal;

public class ModalReference : IModalReference
{
    private readonly TaskCompletionSource<ModalResult> resultCompletion = new TaskCompletionSource<ModalResult>(TaskCreationOptions.RunContinuationsAsynchronously);
    private readonly Action<ModalResult> closed;
    private readonly ModalService modalService;

    internal Guid Id { get; }
    internal RenderFragment ModalInstance { get; }
    internal BlazingModalInstance? ModalInstanceRef { get; set; }
    
    public ModalReference(Guid modalInstanceId, RenderFragment modalInstance, ModalService modalService)
    {
        Id = modalInstanceId;
        ModalInstance = modalInstance;
        closed = HandleClosed;
        this.modalService = modalService;
    }

    public void Close() 
        => modalService.Close(this);

    public void Close(ModalResult result) 
        => modalService.Close(this, result);

    public Task<ModalResult> Result => resultCompletion.Task;

    internal void Dismiss(ModalResult result) 
        => closed.Invoke(result);
    
    private void HandleClosed(ModalResult obj) 
        => _ = resultCompletion.TrySetResult(obj);
}