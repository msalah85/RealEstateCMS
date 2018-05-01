<%@ Page Title="News" Language="C#" MasterPageFile="master.master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="Share.CMS.Web.sys.News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/content/sys/assets/css/bootstrap-editable.css" />
    <link href="/Scripts/select2/css/select2.min.css" rel="stylesheet" />
    <link href="/Scripts/select2/css/select2-optional.css" rel="stylesheet" />
    <script src="//cdn.ckeditor.com/4.7.1/standard/ckeditor.js"></script>
    <script src="/Scripts/sys/Common.js?v=1.3"></script>
    <script src="/Scripts/sys/DataService.min.js"></script>
    <script src="/Scripts/sys/DefaultGridVariables.js"></script>
    <script src="/Scripts/sys/DefaultGridManager.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="#">Home</a>
                <span class="divider">
                    <i class="icon-angle-right arrow-icon"></i>
                </span>
            </li>
            <li class="active">News</li>
        </ul>
    </div>
    <div class="page-content">
        <div class="page-header position-relative">
            <h1>News Management</h1>
        </div>
        <div class="row">
            <div class="col-xs-12 widget-container-col">
                <div class="clearfix">
                    <a role="button" href="NewsAddEdit" class="btn btn-white btn-warning btn-bold"
                        tabindex="0" title="Add new"><i class="fa fa-plus bigger-110"></i>Add new</a>
                    <div class="pull-right tableTools-container"></div>
                </div>
                <div class="widget-box widget-color-blue" id="widget-box-2">
                    <div class="widget-header">
                        <h5 class="widget-title bigger lighter">
                            <i class="ace-icon fa fa-table"></i>
                            News List
                        </h5>
                        <div class="widget-toolbar">
                            <a href="news#" data-action="fullscreen" class="white">
                                <i class="1 ace-icon fa fa-expand bigger-125"></i>
                            </a>
                        </div>
                    </div>
                    <div class="widget-body">
                        <div class="widget-main no-padding">
                            <table id="itemsDataTable" class="table table-striped table-bordered table-hover">
                                <thead>
                                    <tr>
                                        <th>#</th>
                                        <th>Title</th>
                                        <th>Brief Desc</th>
                                        <th>Language</th>
                                        <th>Active</th>
                                        <th>Date</th>
                                        <th>Photo</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Loading...</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div id="deleteModal" class="modal" tabindex="-1">
                <div class="modal-dialog">
                    <div class="modal-content no-padding">
                        <div class="table-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <span class="bigger">Delete Article</span>
                        </div>
                        <div class="modal-body">
                            <form class="form-horizontal" id="removeForm">
                                <div class="alert alert-warning">
                                    <label>Are you sure to delete this item  (  #<strong class="removeField"></strong>  )?</label>
                                </div>
                            </form>
                        </div>
                        <div class="modal-footer">
                            <button class="btn btn-small btn-danger pull-right btn-delete">
                                <i class="icon-trash"></i>
                                Delete
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <style>
        /*hide some controls in editor*/
        #cke_32,
        .cke_button__about {
            display: none !important
        }

        .select2 {
            min-width: 200px;
        }

        .error {
            color: #e15e5e
        }

        .form-horizontal .form-group {
            margin-left: 0 !important;
            margin-right: 0 !important
        }
    </style>
    <script src="/content/sys/assets/js/jquery.validate.min.js"></script>
    <script src="/content/sys/assets/js/additional-methods.min.js"></script>

    <script src="/content/sys/assets/js/x-editable/bootstrap-editable.js"></script>
    <script src="/content/sys/assets/js/x-editable/ace-editable.js"></script>

    <script src="/Scripts/sys/admin/newsManager.js?v=1.2"></script>
    <script src="/Scripts/select2/js/select2.min.js"></script>
    <script src="/Scripts/select2/js/select2-optinal.js?v=1.3"></script>
</asp:Content>
