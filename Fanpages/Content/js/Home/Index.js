var index = function () {
    return {
        initChat: function () {
            var cont = $('#chats');
            var list = $('.chats', cont);
            var form = $('.chat-form', cont);
            var input = $('input', form);
            var btn = $('.btn', form);

            var handleClick = function (e) {
                e.preventDefault();

                var text = input.val();
                if (text.length == 0) {
                    return;
                }

                var time = new Date();
                var time_str = (time.getHours() + ':' + time.getMinutes());
                var tpl = '';
                tpl += '<li class="out">';
                tpl += '<img class="avatar" alt="" src="' + Layout.getLayoutImgPath() + 'avatar1.jpg"/>';
                tpl += '<div class="message">';
                tpl += '<span class="arrow"></span>';
                tpl += '<a href="#" class="name">Bob Nilson</a>&nbsp;';
                tpl += '<span class="datetime">at ' + time_str + '</span>';
                tpl += '<span class="body">';
                tpl += text;
                tpl += '</span>';
                tpl += '</div>';
                tpl += '</li>';

                var msg = list.append(tpl);
                input.val("");

                var getLastPostPos = function () {
                    var height = 0;
                    cont.find("li.out, li.in").each(function () {
                        height = height + $(this).outerHeight();
                    });

                    return height;
                }

                cont.find('.scroller').slimScroll({
                    scrollTo: getLastPostPos()
                });
            }

            $('body').on('click', '.message .name', function (e) {
                e.preventDefault(); // prevent click event

                var name = $(this).text(); // get clicked user's full name
                input.val('@' + name + ':'); // set it into the input field
                App.scrollTo(input); // scroll to input if needed
            });

            btn.click(handleClick);

            input.keypress(function (e) {
                if (e.which == 13) {
                    handleClick(e);
                    return false; //<---- Add this line
                }
            });
        },

        initComment: function () {
            var btn = $('.mt-comment');
            var hanlderClick = function (e) {
                App.blockUI({
                    target: 'body',
                    animate: true
                });
                e.preventDefault();
                
                $.ajax({
                    url: "/Home/GetComment",
                    type: "GET",
                    data: { id: $(this).data('id') },
                    dataType: 'json',
                    success: function (response) {
                        var res = response;
                        var html = "";
                        for (var i = 0; i < res.data.length; i++) {
                            var obj = res.data[i];
                            html += '<div class="mt-comment">';
                            html += '<div class="mt-comment-img">';
                            html += '<img src="' + obj.fbker.linkImg+'" />';
                            html += '</div>';
                            html += '<div class="mt-comment-body">';
                            html += '<div class="mt-comment-info">';
                            html += '<span class="mt-comment-author">' + obj.fbker.name + '</span>';
                            html += '<span class="mt-comment-date">' + obj.created_time + '</span>';
                            html += '</div>';
                            html += '<div class="mt-comment-text"> ' + obj.message + '</div>';
                            html += '<div class="mt-comment-details">';
                            //html += '<span class="mt-comment-status mt-comment-status-pending">Pending</span>';
                            //html += '<ul class="mt-comment-actions">';
                            //html += '<li>< a href= "#" > Quick Edit</a ></li >';
                            //html += '<li> < a href= "#" > View</a ></li >';
                            //html += '<li>< a href= "#" > Delete</a ></li ></ul></div >';
                            html += '</div ></div >';      
                
                        }
                        document.getElementById("comments").innerHTML = html;
                        App.unblockUI('body');
                        
                    },
                    error: function (response) {

                    }
                });

            }
            btn.click(hanlderClick);
        },

        init: function () {
            this.initChat();
            this.initComment();
        }
    };
}();

if (App.isAngularJsApp() === false) {
    jQuery(document).ready(function () {
        index.init(); // init metronic core componets
    });
}

