using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace BlazorServer.Auth;

public class AuthenticationProvider : AuthenticationStateProvider {
  private readonly ClaimsPrincipal _anonymous = new(new ClaimsIdentity());
  private readonly ProtectedSessionStorage _sessionStorage;

  public AuthenticationProvider(ProtectedSessionStorage sessionStorage) {
    _sessionStorage = sessionStorage;
  }

  public override async Task<AuthenticationState>
    GetAuthenticationStateAsync() {
    try {
      ProtectedBrowserStorageResult<UserSession> userSessionStorageResult =
        await _sessionStorage.GetAsync<UserSession>("UserSession");

      UserSession? userSession = userSessionStorageResult.Success
        ? userSessionStorageResult.Value
        : null;

      if (userSession == null)
        return await Task.FromResult(new AuthenticationState(_anonymous));

      ClaimsPrincipal claimsPrincipal = new(new ClaimsIdentity(new List<Claim> {
        new(ClaimTypes.Name, userSession.Email),
        new(ClaimTypes.Role, userSession.Role)
      }, "AuthedUser"));

      return await Task.FromResult(new AuthenticationState(claimsPrincipal));
    } catch {
      return await Task.FromResult(new AuthenticationState(_anonymous));
    }
  }

  public async Task UpdateAuthenticationState(UserSession userSession) {
    ClaimsPrincipal claimsPrincipal;

    if (userSession != null) {
      await _sessionStorage.SetAsync("UserSession", userSession);

      claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim> {
        new(ClaimTypes.Name, userSession.Email),
        new(ClaimTypes.Role, userSession.Role)
      }));
    } else {
      await _sessionStorage.DeleteAsync("UserSession");
      claimsPrincipal = _anonymous;
    }

    NotifyAuthenticationStateChanged(
      Task.FromResult(new AuthenticationState(claimsPrincipal)));
  }
}