var AccountManager = function AccountManager(callBack) {
    _selfAccountManager = this;

    // Methods.
    AccountManager.prototype.CreateNewAccount = function () {
        debugger;
        var UserViewModel = {
            "Username": $("#txtNewAccName").val(),
            "Password": $("#txtNewAccPassword").val(),
            "Email": $("#txtNewAccEMail").val()
        }
        _selfAccountManager.SendRequest("/api/UsersService/Register", UserViewModel, function (result) {
            // sucess callback.
            $("#lblCreateNewAccMsg").html("Account Created Successfully");
            $("#modal3").hide();
            $("#modal1").hide();
            $("#lblCreateNewAccMsg").html("");
            _selfAccountManager.ClearControls();
            //window.parent.SucessNewAccount(result);
        }, function () {
            // user Already exist.
            $("#lblCreateNewAccMsg").html("UserName or Email Already Exist");
        });
    }


    AccountManager.prototype.LogInWithMail = function () {
        debugger;
        var _LogInViewModel = {
            "Username": $("#txtLogInEmail").val(),
            "Password": $("#txtLogInPassword").val()
        }
            /// api / UsersService / LogIn
        _selfAccountManager.SendRequest("/user/LogIn", _LogInViewModel, function (result) {
            debugger;
            // sucess callback.
            $("#modal2").hide();
            $("#modal1").hide();
            $("#lblLogInMsg").html("");
            _selfAccountManager.ClearControls();
            window.parent.SuccessLogIn();
            //window.parent.SucessNewAccount(result);
        }, function () {
            // Invalid username or password.
            $("#lblLogInMsg").html("Invalid username or password");
        });
    }


    // Helper Methods.

    AccountManager.prototype.SendRequest = function (url, data, _callback, _ExistingCallback) {
        $.ajax({
            url: ".." + url,
            type: 'POST',
            data: JSON.stringify(data),
            contentType: 'application/json; charset=utf-8',
            success: function (result) {
                if (result >= 1) {
                    _callback(result);
                } else if (result == -1) {
                    _ExistingCallback();
                }
            },
            error: function (error) {
                console.log(error);
            }
        });
    }


    AccountManager.prototype.ClearControls = function () {
        $("#txtNewAccName").val("");
        $("#txtNewAccPassword").val("");
        $("#txtNewAccEMail").val("");
        $("#txtLogInEmail").val("");
        $("#txtLogInPassword").val("");
    }

}
