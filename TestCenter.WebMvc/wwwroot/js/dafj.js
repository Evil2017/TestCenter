function delfiless(p) {
    $.messager.confirm('删除提示', '您确定要删除文件吗？', function (index) {
        if (index) {
            var msg = getAjax(p, '/config/delFj');
            try {
                msg = eval('(' + msg + ')');
                if (msg.Status == "1") {
                    successmsg("删除成功");
                    FnSearch();

                } else {
                    errmsg(msg.Sign);
                }



            } catch (e) {
                errmsg("操作失败！-1");
            }
        }

    });

}
function imgView(start) {
    $.ajax({
        url: '/Commom/getNetImgList',
        type: "post",
        data: { start: start },
        async: false,
        success: function (data) {
            try {
                data = eval('(' + data + ')');
                layer.photos({

                    photos: data //格式见API文档手册页
                 , anim: 0 //0-6的选择，指定弹出图片动画类型，默认随机
                });


            } catch (e) { }
        }
    });
}
function openFile(p, icno) {
    var index = layer.load(0, { shade: false });
    var icno = icno;
    if (icno == 'jj_img') {
        imgView(p);
        layer.close(index);
    } else {

        var obj = getAjaxNodata("/commom/FileView1?PID=" + p + "");
        try {

            obj = eval('(' + obj + ')');

            if (obj.View == '1') {
                Viewfunc("文件预览", "/Content/pdf/viewer.html?file=" + escape(obj.URL));


            } else if (obj.View == '0') {
                layer.msg(obj.MSG, { time: 800, icon: 2 });
            } else if (obj.View == '2') {
                var html = obj.MSG.replace(/[\r\n]/g, '<br/>')
                parent.layer.open({
                    title: '文件预览',
                    type: 1,
                    skin: 'layui-layer-molv',
                    area: ['80%', '80%'], //宽高
                    btn: ['确定', '关闭'],
                    content: "<img src='" + obj.URL + "'/>",
                });
            } else {

                var html = obj.MSG.replace(/[\r\n]/g, '<br/>')
                parent.layer.open({
                    title: '文件预览',
                    type: 1,
                    skin: 'layui-layer-molv',
                    area: ['80%', '80%'], //宽高
                    btn: ['确定', '关闭'],
                    content: html,
                });
            }




        } catch (e) {
            layer.close(index);
           
        }
        layer.close(index);



    }


}
function Viewfunc(title, url) {
    var layerWidth = $(window).width() * 0.9 > 1400 ? 1400 : $(window).width() * 0.9;
    var layerHeigth = $(window).height() * 0.9 > 900 ? 900 : $(window).height() * 0.9;

    var obj1 = parent;
    var obj = parent.parent;



    parent.layer.open({
        type: 2,
        content: url,
        shadeClose: false,
        maxmin: true, //开启最大化最小化按钮
        skin: 'layui-layer-molv',
        area: [layerWidth + 'px', layerHeigth + 'px'],
        title: title,
        btn: ["提  交", "取 消"],
        yes: function (index, layero) {
            layer.close(index)
        },
        closeBtn: 2
    });
}