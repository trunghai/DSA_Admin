
var data = [];
var loginPages = {
    init: function () {
        loginPages.loginPagefb();
        loginPages.selectedCheckbox();
    },

    selectedCheckbox: function () {
        //$('.group-checkable').off('click').on('click', function (e) {
        //    e.preventDefault();
        //    if ($(this).is(':checked')) {
        //        data.push($(this).data('id'));
        //    }
        //})

        $('.group-checkable').bind('click', function () {
            if ($(this).is(":checked")) {
                // checkbox is checked
                data.push($(this).data('id'));
            } else {
                // checkbox is not checked
            }
        });
    },

    loginPagefb: function () {
        $('#loginPagefb').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                url: "/Login/AcceptPages",
                type: "POST",
                data: { data: data },
                dataType: 'json',
                success: function (response) {
                   
                    window.location.href = "/";
                },
                error: function (response) {
                    
                }
            });
        });
    }
}

loginPages.init();