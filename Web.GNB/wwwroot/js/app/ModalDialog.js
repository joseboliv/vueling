function DialogPost(href, data, idtarget, title) {
    $(idtarget).dialog({
        dialogClass: 'dialog-style modal-lg',
        closeText: "x",
        modal: true,
        open: function () {
            var me = this;
            if (href)
                $.post(href, data)
                    .done(function (data) {
                        if (data !== "") {
                            $(idtarget).html(data);
                        }
                    });
            $(".ui-dialog-titlebar-close").text("x");
            $(".ui-dialog-titlebar-close").removeClass('ui-button-icon-only');
            // storing references
            arrDialogRef.push({
                Source: idtarget,// parent dialog reference
                Destination: me // child or open dialog refernce
                //Element: currentLinkRef // current link reference
            });
        },
        close: function (e) {
            var keepcontent = $(this).data("keepcontent");
            if (!keepcontent) {
                $(this).empty();
                $(this).dialog('destroy');
            }
        },
        width: "auto",
        minHeight: 250,
        title: title,
        position: {
            my: "center",
            at: "center",
            of: window,
            collision: "fit",
            using: function (pos) {
                var topScroll = window.parent.getTopPosition();
                $(this).css(pos).offset().top;
                $(this).css("top", "topScroll");
            }
        },
        resizable: false
    })
};