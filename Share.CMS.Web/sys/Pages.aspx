<%@ Page Title="Pages" Language="C#" MasterPageFile="master.master" AutoEventWireup="true" CodeBehind="Pages.aspx.cs" Inherits="Share.CMS.Web.sys.Pages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            <li class="active">Pages</li>
        </ul>
    </div>
    <div class="page-content">
        <div class="page-header position-relative">
            <h1>Pages Management</h1>
        </div>
        <div class="row">
            <div class="col-xs-12 widget-container-col">
                <div class="clearfix">
                    <a role="button" href="PagesAddEdit" class="btn btn-white btn-warning btn-bold"
                        tabindex="0" title="Add Page"><i class="fa fa-plus bigger-110"></i>Add Page</a>
                    <div class="pull-right tableTools-container"></div>
                </div>
                <div class="widget-box widget-color-blue" id="widget-box-2">
                    <div class="widget-header">
                        <h5 class="widget-title bigger lighter">
                            <i class="ace-icon fa fa-table"></i>
                            Pages List
                        </h5>
                        <div class="widget-toolbar">
                            <a href="Pages#" data-action="fullscreen" class="white">
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
                                        <th>Language</th>
                                        <th>Order</th>
                                        <th>Active</th>
                                        <th>Show top</th>
                                        <th>Show footer</th>
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
    <script src="/Scripts/sys/admin/PagesManager.js?v=1.2"></script>
</asp:Content>
