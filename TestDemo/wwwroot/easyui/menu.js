$(function () {
    $(".J_menuItem").click(function () {
        addTab($(this).data('title'), $(this).data('url'), $(this).data('icon'))
    });
    $(".J_menuModal").click(function () {
        WindowsOne($(this).data('title'), $(this).data('url'), $(this).data('gt'), $(this).data('wt'), $(this).data('icon'));

    });
    tabCloseEven();
    tabClose();
})
function createFrame(url) {
    var s = "<iframe scrolling='auto' align='ceter' frameborder='0' src='" + url + "' style='width:100%;height:99%;'></iframe>";
    return s;
}
function addTab(subtitle, url, icon) {
    if ($('#tabs').length == 0) {
        createPanel();
        $.parser.parse();
    }
    if (!$('#tabs').tabs('exists', subtitle)) {
        $('#tabs').tabs('add', {
            title: subtitle,
            content: createFrame(url),
            closable: true,
            icon: icon
        });
    } else {
        $('#tabs').tabs('select', subtitle);
        $('#mm-tabupdate').click();
    }
    tabClose();
}

function CloseaddTab(subtitle, url, icon, oldsubtitle, refreshtitle) {
    if ($('#tabs').tabs('exists', subtitle)) {
        $('#tabs').tabs('close', subtitle);
    }
    $('#tabs').tabs('add', {
        title: subtitle,
        content: createFrame(url),
        closable: true,
        icon: icon
    });
    $('#tabs').tabs('close', oldsubtitle);
    $('#tabs').tabs('close', oldsubtitle);
    tabClose();
}

function tabClose() {
    /*双击关闭TAB选项卡*/
    $(".tabs-inner").dblclick(function () {
        var subtitle = $(this).children(".tabs-closable").text();
        $('#tabs').tabs('close', subtitle);
    })
    /*为选项卡绑定右键*/
    $(".tabs-inner").bind('contextmenu', function (e) {
        $('#mm').menu('show', {
            left: e.pageX,
            top: e.pageY
        });
        var subtitle = $(this).children(".tabs-closable").text();
        $('#mm').data("currtab", subtitle);
        $('#tabs').tabs('select', subtitle);
        return false;
    });
}
//绑定右键菜单事件
function tabCloseEven() {
    //刷新
    $('#mm-tabupdate').click(function () {

        var currTab = $('#tabs').tabs('getSelected');
        var url = $(currTab.panel('options').content).attr('src');

        if (typeof (url) == "undefined") {
            url = "/home/index_v1";
        }
        $('#tabs').tabs('update', {
            tab: currTab,
            options: {
                content: createFrame(url)
            }
        })
    })
    //关闭当前
    $('#mm-tabclose').click(function () {

        var currtab_title = $('#mm').data("currtab");
        $('#tabs').tabs('close', currtab_title);
    })
    //全部关闭
    $('#mm-tabcloseall').click(function () {

        $('.tabs-inner span').each(function (i, n) {

            if (i > 0) {
                var t = $(n).text();
                $('#tabs').tabs('close', t);
            }
        });
        $('#mm').menu('hide');
    });
    //关闭除当前之外的TAB
    $('#mm-tabcloseother').click(function () {

        $('#mm-tabcloseright').click();
        $('#mm-tabcloseleft').click();
    });
    //关闭当前右侧的TAB
    $('#mm-tabcloseright').click(function () {

        var nextall = $('.tabs-selected').nextAll();
        if (nextall.length == 0) {
            //msgShow('系统提示','后边没有啦~~','error');
            //alert('后边没有啦~~');
            return false;
        }
        nextall.each(function (i, n) {
            var t = $('a:eq(0) span', $(n)).text();
            $('#tabs').tabs('close', t);
        });
        $('#mm').menu('hide');
        return false;
    });
    //关闭当前左侧的TAB
    $('#mm-tabcloseleft').click(function () {

        var prevall = $('.tabs-selected').prevAll();
        if (prevall.length == 0) {
            //alert('到头了，前边没有啦~~');
            return false;
        }
        prevall.each(function (i, n) {
            if (i < prevall.length - 1) {
                var t = $('a:eq(0) span', $(n)).text();
                $('#tabs').tabs('close', t);
            }
        });
        $('#mm').menu('hide');
        return false;
    });

    //退出
    $("#mm-exit").click(function () {

        $('#mm').menu('hide');
    })
}