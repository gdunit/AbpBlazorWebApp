using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Acme.BookStore.Blazor.Client;

public abstract class WasmComponentBase : ComponentBase
{
  protected string handler { get; private set; }

  protected override void OnInitialized ()
  {
      handler = OperatingSystem.IsBrowser() ? "WASM" : "Server";
  }
}