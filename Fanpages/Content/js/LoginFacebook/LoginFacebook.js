var facebook = {
    init: function () {
        facebook.loginFacebook();
    },

    loginFacebook: function () {
        $('#loginfacebook').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                url: "/LoginFacebook/LoginFacebook",
                type: "POST",
                data: {},
                dataType: 'json',
                success: function (response) {
                    alert(response);
                },
                error: function (response) {
                    alert(response);
                }
            });
        });
    }
}

facebook.init();