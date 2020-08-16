$.fn.serializeJson = function () {
    var serializeObj = {};
    var array = this.serializeArray();
    var str = this.serialize();
    $(array).each(function () {
        if (serializeObj[this.name]) {
            if ($.isArray(serializeObj[this.name])) {
                serializeObj[this.name].push(this.value);
            } else {
                serializeObj[this.name] = [serializeObj[this.name], this.value];
            }
        } else {
            serializeObj[this.name] = this.value;
        }
    });
    return serializeObj;
};

$.extend($.fn.datagrid.methods, {
    keyCtr: function (jq) {
        return jq.each(function () {
            var grid = $(this);
            grid.datagrid('getPanel').panel('panel').attr('tabindex', 0).bind('keydown', function (e) {             
                switch (e.keyCode) {
                    case 38: // up                       
                        var selected = grid.datagrid('getSelections');
                        var l = selected.length;
                        if (l > 0) {
                            var index = grid.datagrid('getRowIndex', selected[0]);
                            grid.datagrid('selectRow', index - 1);
                        } else {
                            var rows = grid.datagrid('getRows');
                            grid.datagrid('selectRow', rows.length - 1);
                        }
                        break;
                    case 40: // down
                      
                        var selected = grid.datagrid('getSelections');
                        var l=selected.length;
                        if (l>0) {
                            var index = grid.datagrid('getRowIndex', selected[l-1]);
                            grid.datagrid('selectRow', index + 1);
                        } else {
                            grid.datagrid('selectRow', 0);
                        }
                        break;
                }
            });
        });
    }
});

/**  
     * layout方法扩展  
     * @param {Object} jq  
     * @param {Object} region  
     */  
$.extend($.fn.layout.methods, {   
    /**  
     * 面板是否存在和可见  
     * @param {Object} jq  
     * @param {Object} params  
     */  
    isVisible: function(jq, params) {   
        var panels = $.data(jq[0], 'layout').panels;   
        var pp = panels[params];   
        if(!pp) {   
            return false;   
        }   
        if(pp.length) {   
            return pp.panel('panel').is(':visible');   
        } else {   
            return false;   
        }   
    },   
    /**  
     * 隐藏除某个region，center除外。  
     * @param {Object} jq  
     * @param {Object} params  
     */  
    hidden: function(jq, params) {   
        return jq.each(function() {   
            var opts = $.data(this, 'layout').options;   
            var panels = $.data(this, 'layout').panels;   
            if(!opts.regionState){   
                opts.regionState = {};   
            }   
            var region = params;   
            function hide(dom,region,doResize){   
                var first = region.substring(0,1);   
                var others = region.substring(1);   
                var expand = 'expand' + first.toUpperCase() + others;   
                if(panels[expand]) {   
                    if($(dom).layout('isVisible', expand)) {   
                        opts.regionState[region] = 1;   
                        panels[expand].panel('close');   
                    } else if($(dom).layout('isVisible', region)) {   
                        opts.regionState[region] = 0;   
                        panels[region].panel('close');   
                    }   
                } else {   
                    panels[region].panel('close');   
                }   
                if(doResize){   
                    $(dom).layout('resize');   
                }   
            };   
            if(region.toLowerCase() == 'all'){   
                hide(this,'east',false);   
                hide(this,'north',false);   
                hide(this,'west',false);   
                hide(this,'south',true);   
            }else{   
                hide(this,region,true);   
            }   
        });   
    },   
    /**  
     * 显示某个region，center除外。  
     * @param {Object} jq  
     * @param {Object} params  
     */  
    show: function(jq, params) {   
        return jq.each(function() {   
            var opts = $.data(this, 'layout').options;   
            var panels = $.data(this, 'layout').panels;   
            var region = params;   
      
            function show(dom,region,doResize){   
                var first = region.substring(0,1);   
                var others = region.substring(1);   
                var expand = 'expand' + first.toUpperCase() + others;   
                if(panels[expand]) {   
                    if(!$(dom).layout('isVisible', expand)) {   
                        if(!$(dom).layout('isVisible', region)) {   
                            if(opts.regionState[region] == 1) {   
                                panels[expand].panel('open');   
                            } else {   
                                panels[region].panel('open');   
                            }   
                        }   
                    }   
                } else {   
                    panels[region].panel('open');   
                }   
                if(doResize){   
                    $(dom).layout('resize');   
                }   
            };   
            if(region.toLowerCase() == 'all'){   
                show(this,'east',false);   
                show(this,'north',false);   
                show(this,'west',false);   
                show(this,'south',true);   
            }else{   
                show(this,region,true);   
            }   
        });   
    }   
});
 
function V_keyHandler() {
    var obj = {
        up: function () {
            var pClosed = $(this).combogrid("panel").panel("options").closed;
            if (pClosed) {
                $(this).combogrid("showPanel");
            }
            var grid = $(this).combogrid("grid");
            var rowSelected = grid.datagrid("getSelected");
            if (rowSelected != null) {
                var rowIndex = grid.datagrid("getRowIndex", rowSelected);
                if (rowIndex > 0) {
                    rowIndex = rowIndex - 1;
                    grid.datagrid("selectRow", rowIndex);
                }
            } else if (grid.datagrid("getRows").length > 0) {
                grid.datagrid("selectRow", 0);
            }           
        },
        down: function () {
            var pClosed = $(this).combogrid("panel").panel("options").closed;
            if (pClosed) {
                $(this).combogrid("showPanel");
            }
            var grid = $(this).combogrid("grid");
            var rowSelected = grid.datagrid("getSelected");
            if (rowSelected != null) {
                var totalRow = grid.datagrid("getRows").length;
                var rowIndex = grid.datagrid("getRowIndex", rowSelected);
                if (rowIndex < totalRow - 1) {
                    rowIndex = rowIndex + 1;
                    grid.datagrid("selectRow", rowIndex);
                }
            } else if (grid.datagrid("getRows").length > 0) {
                grid.datagrid("selectRow", 0);
            }
        },
        enter: function () {
            var grid = $(this).combogrid('grid');//获取表格对象
            var p0 = grid.datagrid('getData').rows;
            var p = p0.length;
            if (p > 0) {
                var row = grid.datagrid('getSelected');//获取行数据
                if (row == null) {
                    grid.datagrid("selectRow", 0);
                }
            }
            $(this).combogrid('hidePanel');
        },
        query: function (q) {
            if ($.trim(q).length > 0) {
                $.fn.combogrid.defaults.keyHandler.query.call(this, q);
            } else {
                $(this).combogrid('hidePanel');
                $(this).combogrid('clear');
            }
        }
    }
    return obj;
}