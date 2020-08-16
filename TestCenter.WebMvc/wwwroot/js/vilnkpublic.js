///动态调用方法
function dynamic(fn, args) {
    try {
        fn = eval(fn);
    } catch (e) {
        console.log(e)
    }
    if (typeof fn === 'function') {
        fn.call(this, args);
    }
}
function setValue(d, v) {
    try {
        $(d).val(v)
    } catch (e) {
        alert(e);
    }
}
var bst = $(window).height() - 40;
//系统消息
function DevMsg(funcName, msg) {
    if (typeof (eval(funcName)) == "function") {
        eval(funcName + "('" + escape(msg) + "');");
    }
    else {
        // 函数不存在
    }
}

//关闭指定标题的tabs
function CloseTab(title) {
    var IndexTab = top.$('#tabs').tabs('getTab', title);
    var index = top.$('#tabs').tabs('getTabIndex', IndexTab);
    top.$('#tabs').tabs('close', index);
}    //关闭当前tab
function CloseTabthis() {
    var pp = self.parent.$('#tabs').tabs('getSelected');
    var tab = pp.panel('options');
    CloseTab(tab.title);

}
 

///easyui 扩展

/// easyui  扩展
function closeLoading() {
    $("#loadingDiv").fadeOut("normal");
}
var no;
$.parser.onComplete = function () {
    if (no) clearTimeout(no);
    no = setTimeout(closeLoading, 10);
}
setTimeout(function () {
    $(".combo").click(function () {
        try {
            $(this).prev().combogrid("showPanel");
            $(this).prev().combobox("showPanel");
            $(this).prev().datetimebox("showPanel");
            $(this).prev().datebox("showPanel");
        } catch (e) {

        }
    })
    $(".combo").children("input").focus(function () {
        try {
            $(this).parent().prev().combogrid("showPanel");
            $(this).parent().prev().combobox("showPanel");
            $(this).parent().prev().datetimebox("showPanel");
            $(this).parent().prev().datebox("showPanel");
        } catch (e) {

        }
    })
}, 2000);


function IdCodeValid(code) {
    //身份证号合法性验证
    //支持15位和18位身份证号
    //支持地址编码、出生日期、校验位验证
    var city = { 11: "北京", 12: "天津", 13: "河北", 14: "山西", 15: "内蒙古", 21: "辽宁", 22: "吉林", 23: "黑龙江 ", 31: "上海", 32: "江苏", 33: "浙江", 34: "安徽", 35: "福建", 36: "江西", 37: "山东", 41: "河南", 42: "湖北 ", 43: "湖南", 44: "广东", 45: "广西", 46: "海南", 50: "重庆", 51: "四川", 52: "贵州", 53: "云南", 54: "西藏 ", 61: "陕西", 62: "甘肃", 63: "青海", 64: "宁夏", 65: "新疆", 71: "台湾", 81: "香港", 82: "澳门", 91: "国外 " };
    var row = {
        'pass': true,
        'msg': '验证成功'
    };
    if (!code || !/^\d{6}(18|19|20)?\d{2}(0[1-9]|1[012])(0[1-9]|[12]\d|3[01])\d{3}(\d|[xX])$/.test(code)) {
        row = {
            'pass': false,
            'msg': '证书编号格式错误'
        };
    } else if (!city[code.substr(0, 2)]) {
        row = {
            'pass': false,
            'msg': '证书编号地址编码错误'
        };
    } else {
        //18位身份证需要验证最后一位校验位
        if (code.length == 18) {
            code = code.split('');
            //∑(ai×Wi)(mod 11)
            //加权因子
            var factor = [7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2];
            //校验位
            var parity = [1, 0, 'X', 9, 8, 7, 6, 5, 4, 3, 2];
            var sum = 0;
            var ai = 0;
            var wi = 0;
            for (var i = 0; i < 17; i++) {
                ai = code[i];
                wi = factor[i];
                sum += ai * wi;
            }
            console.log(sum)
            if (parity[sum % 11] != code[17].toUpperCase()) {
                row = {
                    'pass': false,
                    'msg': '证书编号校验位错误'
                };
            }
        }
    }
    return row;
}
var chnNumChar = ["零", "一", "二", "三", "四", "五", "六", "七", "八", "九"];
var chnUnitSection = ["", "万", "亿", "万亿", "亿亿"];
var chnUnitChar = ["", "十", "百", "千"];
function SectionToChinese(section) {
    var strIns = '', chnStr = '';
    var unitPos = 0;
    var zero = true;
    while (section > 0) {
        var v = section % 10;
        if (v === 0) {
            if (!zero) {
                zero = true;
                chnStr = chnNumChar[v] + chnStr;
            }
        } else {
            zero = false;
            strIns = chnNumChar[v];
            strIns += chnUnitChar[unitPos];
            chnStr = strIns + chnStr;
        }
        unitPos++;
        section = Math.floor(section / 10);
    }
    return chnStr;
}
function errmsg(msg) {
    layer.msg(msg, { icon: 2, time: 3000 });
}
function successmsg(msg) {
    layer.msg(msg, { icon: 1, time: 3000 });
}
//表单 回车后下一个文本款获取焦点 ff  表单的class
function fEnter(ff) {
    setTimeout(function () {
        var $inp = $('.' + ff + ' input:text:visible,.' + ff + ' select');
        if ($inp.length > 0) {
            $inp[0].focus();
            $inp.bind('keydown', function (e) {
                var ev = document.all ? window.event : e;
                var key = ev.keyCode;
                if (key == 13) {
                    e.preventDefault();
                    var nxtIdx = $inp.index(this) + 1;
                    if (nxtIdx != $inp.length) {
                        $inp[nxtIdx].focus();
                    } else {
                        try {

                            if ($('#sub_btn').length > 0) {
                                InSave();
                                // var bb = $('#sub_btn').focus().select();
                            }
                        } catch (e) { }

                    }
                }
            });
        }

    }, 1000);

}
var objectArraySort = function (keyName) {
    return function (objectN, objectM) {
        var valueN = objectN[keyName]
        var valueM = objectM[keyName]
        if (valueN < valueM) return 1
        else if (valueN > valueM) return -1
        else return 0
    }
}
function layerView(T, url, w, h) {
    var width = $(window).width();
    var height = $(window).height();
    if (width < w) {
        w = width - 50;
    }
    if (height < h) {
        h = height - 50;
    }
    if (isNumber(w)) {
        w = w + 'px';
    } if (isNumber(h)) {
        h = h + 'px';
    }
    layer.open({
        type: 2,
        title: T,
        shadeClose: false,
        shade: 0.8,
        area: [w, h],
        skin: 'layui-layer-lan',
        btn: ['确定', '关闭'], //只是为了演示
        content: url,
        yes: function (index, layero) {
            var ff = layero.find('iframe');            
            ff[0].contentWindow.InSave(index);
        }
   , btn2: function () {
       layer.closeAll();
   }
    });
}
function layerViewNext(T, url, w, h) {
    var width = $(window).height();
    var height = $(window).width();
    if (width < w) {
        w = width - 50;
    }
    if (height < h) {
        h = height - 50;
    }
    if (isNumber(w)) {
        w = w + 'px';
    } if (isNumber(h)) {
        h = h + 'px';
    }
    layer.open({
        type: 2,
        title: T,
        shadeClose: false,
        shade: 0.8,
        area: [w, h],
        skin: 'layui-layer-lan',
        btn: ['上一步', '下一步', '确定', '关闭'], //只是为了演示
        content: url,
        yes: function (index, layero) {
            var ff = layero.find('iframe');
            ff[0].contentWindow.Back(index);
            return false;
        }
   , btn2: function (index, layero) {
       var ff = layero.find('iframe');
       ff[0].contentWindow.Next(index);
       return false;
   }, btn3: function (index, layero) {
       var ff = layero.find('iframe');       
       ff[0].contentWindow.InSave(index);
       return false;
   }, btn4: function (index, layero) {
       layer.closeAll();
   }
    });
}

//表单 回车后执行FnSeach() 搜索方法
function fEnterFnSeach(ff) {
    setTimeout(function () {
        var $inp = $('.' + ff + ' input:text:visible');
        $inp.bind('keydown', function (e) {
            var ev = document.all ? window.event : e;
            var key = ev.keyCode;
            if (key == 13) {
                e.preventDefault();
                FnSearch();
            }
        });

    }, 1000);
}

//填充页面  用于详情页 标签  前缀 <span class="mm_Sign"/>
function fullspan(p, url, ff, prefix) {
    var data1 = getAjax(p, url);
    data = eval('(' + data1 + ')');
    try {
        if (data.length > 0) {
            $.each(data[0], function (name, value) {
                var n = $("." + ff + " span[class=" + prefix + name + "]");
                if (n.length > 0) {
                    n.html(value);
                }
            });
        } else {
            $.each(data, function (name, value) {
                var n = $("." + ff + " span[class=" + prefix + name + "]");
                if (n.length > 0) {
                    n.html(value);
                }
            });
        }
    } catch (e) {
    }
}
function htmlfull(data, ff, prefix) {
    $.each(data, function (name, value) {
        var n = $("." + ff + " span." + prefix + name + "");
        if (n.length > 0) {
            n.html(value);
        }
    });
}
function htmlfullurl(url, ff, prefix) {
    var data = getAjaxNodata(url);
    try {
        var obj = eval('(' + data + ')');
        $.each(obj, function (name, value) {
            var n = $("." + ff + " span." + prefix + name + "");
            if (n.length > 0) {
                n.html(value);
            }
        });
    } catch (e) { }
}
function tsmust(f) {
    var html = "<font color='Red'>*</font>";
    var m = $('.' + f + ' [data-must="true"]');

    for (var n = 0; n < m.length; n++) {
        var obj = m[n];

        if ($(obj).parent().prev().length > 0) {
            $(obj).parent().prev().prepend(html);
        } else if ($(obj).parent().parent().prev().length > 0) {
            $(obj).parent().parent().prev().prepend(html);
        }

    }

}
//表单必填 在input 添加 data-must="true"
function Required(f) {
    var m = $(f + ' [data-must="true"]');
    for (var n = 0; n < m.length; n++) {
        var obj = m[n];
        var val = $(obj).val();

        if (typeof (val) != "undefined") {
            if ($(obj).val() == "") {

                var H = "";
                try {
                    if ($(obj).parent().prev().length > 0) {
                        H = $(obj).parent().prev()[0].innerText;
                    } else if ($(obj).parent().parent().prev().length > 0) {
                        H = $(obj).parent().parent().prev()[0].innerText
                    }
                    H = H.replace(":", "").replace("：", "").replace(new RegExp("\\*", "g"), "");
                    errmsg(H + '不能为空！');
                    $(obj).focus();
                    accobj0017 = 0;
                } catch (e) {


                }


                return false;
            }
        }
    }
    return true;
}

//列表删除
function delrows(url, data, div, next) {
    $.messager.confirm('删除提示', '您确定要删除该条信息吗？', function (index) {
        if (index) {
            var msg = getAjax(data, url);
            try {
                var msg = JSON.parse(msg);
                if (msg.status == 1) {
                    successmsg("删除成功");
                    var n = 0;
                    if (div != "" && div != null && div != "undefined") {
                        n == 1;
                        if ($("#" + div + "").length > 0) {
                            try {
                                $('#' + div).datagrid('reload', queryParams());
                            } catch (e) { }
                        }
                    }
                    if (next != "" && next != null && next != "undefined") {
                        n == 1
                        setTimeout("" + next + "()", 100);

                    }
                    if (n == 0) {
                        try {
                            $('#bstrapTable0').datagrid('reload', queryParams());
                        } catch (e) { }
                    }

                } else {
                    errmsg(msg.message);
                }

            } catch (e) {
                errmsg("操作失败！-1");
            }


        }
    });
}
function getAjaxasync(ID, url) {

    var obj = "";
    $.ajax({
        url: url,
        data: { ID: ID, t: Math.random() },
        type: "get",
        async: true,
        success: function (data) {
            obj = data;
        }
    });
    return obj;
}
function getAjax(ID, url) {

    var obj = "";
    $.ajax({
        url: url,
        data: { ID: ID, t: Math.random() },
        type: "get",
        async: false,
        success: function (data) {
            obj = data;
        }
    });
    return obj;
}
function getAjaxNodataSync(url, backFun) {
    var obj = "";
    $.ajax({
        url: url,
        type: "get",       
        success: function (data) {
            backFun(data);
        }
    });
    return obj;
}
function getAjaxNodata(url) {
    var obj = "";
    $.ajax({
        url: url,
        type: "get",
        async: false,
        success: function (data) {
            obj = data;
        }
    });
    return obj;
}
function getAjaxPost(ff, url) {
    var obj = "";
    $.ajax({
        url: url,
        type: "post",
        async: false,
        data: $(ff).serialize(),
        success: function (data) {
            obj = data;

        }
    });
    return obj;
}
function getAsyncAjaxPost(ff, url, backFun) {
    $.ajax({
        url: url,
        type: "post",      
        data: $(ff).serialize(),
        success: function (data) {
            backFun(data);

        }
    });
    
}
function getAsyncAjaxDataPost(data, url,backFun) { 
    $.ajax({
        url: url,
        type: "post",     
        data: data,
        traditional: true,
        success: function (data) {
            backFun(data);
           
        }
    });   
}
function getAjaxDataPost(data, url) {
    var obj = "";
    $.ajax({
        url: url,
        type: "post",
        async: false,
        data: data,
        traditional: true,
        success: function (data) {
            obj = data; 
        }
    });
    return obj;
}
function formatYMD(cellvalue, options, row) {   if (cellvalue == null || cellvalue == '') { return '' } else { cellvalue = cellvalue.replace(/-/g, "/"); var date = new Date(cellvalue); var m = date.getMonth() + 1; if (m < 10) { m = 0 + '' + m } var d = date.getDate(); if (d < 10) { d = 0 + '' + d } return date.getFullYear() + '-' + m + '-' + d } }
function formatYMDhms(cellvalue, options, row) { if (cellvalue == null || cellvalue == '') { return '' } else { cellvalue = cellvalue.replace(/-/g, "/"); var date = new Date(cellvalue); var m = date.getMonth() + 1; if (m < 10) { m = 0 + '' + m } var d = date.getDate(); if (d < 10) { d = 0 + '' + d } var h = date.getHours(); if (h < 10) { h = 0 + '' + h } var mm = date.getMinutes(); if (mm < 10) { mm = 0 + '' + mm } var ss = date.getSeconds(); if (ss < 10) { ss = 0 + '' + ss } return date.getFullYear() + '-' + m + '-' + d + ' ' + h + ":" + mm + ":" + ss; } }

///判断字符串是否为数字
function isNumber(val) {

    var regPos = /^\d+(\.\d+)?$/; //非负浮点数
    var regNeg = /^(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))$/; //负浮点数
    if (regPos.test(val) || regNeg.test(val)) {
        return true;
    } else {
        return false;
    }
}
var parseParam = function (param, key) {
    var paramStr = "";
    if (param instanceof String || param instanceof Number || param instanceof Boolean) {
        paramStr += "&" + key + "=" + encodeURIComponent(param);
    } else {
        $.each(param, function (i) {
            var k = key == null ? i : key + (param instanceof Array ? "[" + i + "]" : "." + i);
            paramStr += '&' + parseParam(this, k);
        });
    }
    return paramStr.substr(1);
};
String.prototype.endWith = function (s) {
    if (s == null || s == "" || this.length == 0 || s.length > this.length)
        return false;
    if (this.substring(this.length - s.length) == s)
        return true;
    else
        return false;
    return true;
}

String.prototype.startWith = function (s) {
    if (s == null || s == "" || this.length == 0 || s.length > this.length)
        return false;
    if (this.substr(0, s.length) == s)
        return true;
    else
        return false;
    return true;
}


///ajax请求，要求按照格式进行
///入参：请求地址，数据，成功调用，失败调用
function get(URL, Data, CallBack, FailCallBack) {
    $.ajax({
        url: URL,
        type: "post",
        data: Data,
        success: function (msg) {

            var jo = eval("(" + msg + ")");
            if (jo.Status == "1") {
                CallBack(jo.Result);
            }
            else {
                FailCallBack(jo.Sign, jo.Result);
            }
        }
    });
}


function preview(ff) {
    var fulls = "left=0,screenX=0,top=0,screenY=0,scrollbars=1,location=no,fullscreen=yes";    //定义弹出窗口的参数
    if (window.screen) {
        var ah = screen.availHeight;
        var aw = screen.availWidth;
        fulls += ",height=" + ah;
        fulls += ",innerHeight=" + ah;
        fulls += ",width=" + aw;
        fulls += ",innerWidth=" + aw;
        fulls += ",resizable"
    } else {
        fulls += ",resizable"; // 对于不支持screen属性的浏览器，可以手工进行最大化。 manually
    }
    window.open(ff, "", fulls);
   
}
