using System.Threading.Tasks;
using BlazingModal.Services;

namespace BlazingModal;

public interface IModalReference
{
    Task<ModalResult> Result { get; }

    void Close();
    void Close(ModalResult result);
}