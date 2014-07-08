<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Products001.aspx.cs" Inherits="BootStrap.Products001" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <table style="width: 100%;">
        <tr>
            <td style="text-align: right;">
                <input id="searchBar" class="FormElement ui-widget-content ui-corner-all" type="text" name="search" />
                <a id="searchBtn" class="fm-button ui-state-default ui-corner-all fm-button-icon-right ui-reset">
                    <span class="ui-icon ui-icon-search"></span>搜尋
                </a>
            </td>
        </tr>
        <tr>
            <td>
                <table id="gv">
                    <tr>
                        <td></td>
                    </tr>
                </table>
                <div id="pager"></div>
            </td>
        </tr>
    </table>

    <script type="text/javascript" src="Scripts/jqGrid/js/i18n/grid.locale-tw.js"></script>
    <script type="text/javascript" src="Scripts/jqGrid/js/jquery.jqGrid.min.js"></script>

    <script type="text/javascript">

        $(function () {
            $("#gv").jqGrid({
                url: "<%=appURL() %>/api/Products",
                datatype: "json",
                mtype: "GET",
                colNames: ["產品編號", "型號", "名稱", "顏色"],
                colModel: [
                    {
                        name: "ProductID", index: "ProductID", width: 55, align: "center"
                        , editable: false, key: true, edittype: "text", editoptions: { size: 2, maxlength: 2 }
                        , editrules: { required: true }
                        , search: false, stype: "text", searchrules: { required: true }, searchoptions: { sopt: ['eq', 'cn', 'bw', 'ew'] }
                    },
                    {
                        name: "ProductNumber", index: "ProductNumber", width: 90
                        , editable: true, edittype: "text", editoptions: { size: 22, maxlength: 20 }, editrules: { required: true }
                        , search: false, stype: "text", searchrules: { required: true }, searchoptions: { sopt: ['eq', 'cn', 'bw', 'ew'] }
                    },
                    {
                        name: "Name", index: "Name", width: 80, align: "left"
                        , editable: true, edittype: "text", editoptions: { size: 22, maxlength: 20 }, editrules: { required: true }
                        , search: false, stype: "text", searchrules: { required: true }, searchoptions: { sopt: ['eq', 'cn', 'bw', 'ew'] }
                    },
                    {
                        name: "Color", index: "Color", width: 80, align: "left"
                        , editable: true, edittype: "text", editoptions: { size: 22, maxlength: 20 }, editrules: { required: true }
                        , search: false, stype: "text", searchrules: { required: true }, searchoptions: { sopt: ['eq', 'cn', 'bw', 'ew'] }
                    }
                ],
                pager: "#pager",
                toppager: false,
                //loadonce: true,
                autowidth: true,
                rowNum: 1,
                rowNum: 10,
                //rowList: [1, 3, 5, 10],
                rowList: [10, 30, 50, 100],
                sortname: "ProductID,Name",
                sortorder: "desc",
                altRows: true,
                viewrecords: true,
                gridview: true,
                autoencode: true,
                caption: "產品資料"
 


            });


            $("#gv").jqGrid("navGrid", "#pager",
                {
                    edit: true,
                    add: true,
                    del: true
                    , search: false
                    //searchtext: "搜尋",
                    //edittext: "修改",
                    //deltext: "刪除",
                    //addtext: "新增"
                    //,cloneToTop: true
                }
                , editDialog("PUT")
                , editDialog("POST")
                , editDialog("DELETE")
                , { closeAfterSearch: true }
            );

            $("#searchBtn").click(function () {
                var searchValue = $("#searchBar").val();
                var gd = $("#gv");

                if (searchValue.length === 0) {
                    gd[0].p.search = false;
                    $.extend(gd[0].p.postData, { searchString: "", searchField: "", searchOper: "" });
                }
                else {
                    gd[0].p.search = true;
                    $.extend(gd[0].p.postData, { searchString: searchValue, searchField: "allFieldSearch", searchOper: "cn" });
                }

                gd.trigger("reloadGrid", [{ page: 1, current: true }]);
            });

        });


        function editDialog(action) {
            return {
                url: "<%=appURL() %>/api/Products"
                , closeAfterAdd: true
                , closeAfterEdit: true

                , afterShowForm: function (formId) { }
                , modal: true
                , onclickSubmit: function (params, posdata) {
                    var list = $("#gv");

                    if (action !== "POST") {
                        var selectedRow = list.getGridParam("selrow");
                        rowData = list.getRowData(selectedRow);
                        params.url += "/" + rowData.ProductID;
                    }
                    posdata.ProductID = rowData.ProductID;
                    params.mtype = action;
                }
                , afterShowForm: function (formid) {
                    if (action === "PUT") {
                        $("#ProductID").attr("readonly", "readonly");
                        $("#ProductID").addClass("ui-state-disabled");
                        $("#Name").focus();
                    }
                    else {
                        $("#ProductID").removeAttr("readonly");
                        $("#ProductID").removeClass("ui-state-disabled");
                    }

                }
                , errorTextFormat: function (data) {
                    return data.responseText;
                }
                , width: "300"


            };
        }

    </script>


    <!--jquery UI CSS -->
    <link rel="stylesheet" type="text/css" href="Scripts/jqGrid/css/sunny/jquery-ui-1.10.4.custom.min.css" />
    <!--原jQgrid CSS -->
    <link rel="stylesheet" type="text/css" href="Scripts/jqGrid/css/ui.jqgrid.css" />
    <!--覆寫過，用來適合bootstrap的jQgrid CSS -->
    <link rel="stylesheet" type="text/css" href="Scripts/jqGrid/jqgrid.bootstrap.css" />


</asp:Content>

