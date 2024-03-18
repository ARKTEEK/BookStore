﻿using Microsoft.AspNetCore.Components.Forms;

namespace BlazorServer.Services.Interface;

public class InputSelectNumber<T> : InputSelect<T> {
  protected override bool TryParseValueFromString(string value, out T result,
    out string validationErrorMessage) {
    if (typeof(T) == typeof(int)) {
      if (int.TryParse(value, out int resultInt)) {
        result = (T)(object)resultInt;
        validationErrorMessage = null;

        return true;
      }

      result = default;
      validationErrorMessage = "The chosen value is not a valid number.";

      return false;
    }

    return base.TryParseValueFromString(value, out result,
      out validationErrorMessage);
  }
}