<%@ Page Title="Url Records" Language="C#" MasterPageFile="master.master" AutoEventWireup="true" EnableTheming="false" EnableViewState="false" ViewStateMode="Disabled" EnableSessionState="ReadOnly" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="/Scripts/sys/Common.js?v=1.3"></script>
    <script src="/Scripts/sys/DataService.min.js"></script>
    <script src="/Scripts/sys/DefaultGridVariables.js"></script>
    <script src="/content/sys/assets/js/jquery.validate.min.js"></script>
    <script src="/content/sys/assets/js/additional-methods.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs ace-save-state" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="ace-icon fa fa-home home-icon"></i>
                <a href="home">Home</a>
            </li>
            <li class="active">Url Records</li>
        </ul>
    </div>
    <div class="page-content">
        <div class="page-header">
            <h1>Url Records Manager</h1>
        </div>
        <div class="row">
            <div class="col-xs-12 widget-container-col">
                <div class="clearfix">
                    <a role="button" href="#addModal" data-toggle="modal" class="btn btn-white btn-warning btn-bold"
                        tabindex="0" title="Add new"><i class="fa fa-plus bigger-110"></i>Add new</a>
                    <div class="pull-right tableTools-container"></div>
                </div>

                <div class="widget-box widget-color-blue" id="widget-box-2">
                    <div class="widget-header">
                        <h5 class="widget-title bigger lighter">
                            <i class="ace-icon fa fa-table"></i>
                            Url Records List
                        </h5>

                        <div class="widget-toolbar">
                            <a href="#" data-action="fullscreen" class="white">
                                <i class="1 ace-icon fa fa-expand bigger-125"></i>
                            </a>
                        </div>
                    </div>
                    <div class="widget-body">
                        <div class="widget-main no-padding">
                            <table id="listItems" class="table table-striped table-bordered table-hover">
                                <thead>
                                    <tr>
                                        <th>#</th>
                                        <th>URL</th>
                                        <th>Entity Name</th>
                                        <th>Entity ID</th>
                                        <th>Active</th>
                                        <th class="hidden-print" style="width: 77px">Options</th>
                                    </tr>
                                </thead>
                                <tbody></tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <div id="addModal" class="modal fade" tabindex="-1">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header no-padding">
                                <div class="table-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                        <span class="white">&times;</span>
                                    </button>
                                    Add/Edit Url Record
                                </div>
                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-xs-12 col-sm-12">
                                        <form class="form-horizontal" role="form" id="aspnetForm">
                                            <div>
                                                <input type="hidden" id="URLID" value="0" />
                                            </div>
                                            <div class="form-group">
                                                <label for="LanguageId" class="col-sm-3 control-label no-padding-right">Language <span class="text-danger">*</span></label>
                                                <div class="col-sm-9">
                                                    <select class="col-sm-10" id="LanguageId" name="LanguageId">
                                                        <option value="1">English</option>
                                                        <option value="2">Arabic</option>
                                                    </select>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="EntityName" class="col-sm-3 control-label no-padding-right">Entity Name <span class="text-danger">*</span></label>
                                                <div class="col-sm-9">
                                                    <input type="text" class="col-sm-10 required" required id="EntityName" name="EntityName" placeholder="Entity name" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="EntityID" class="col-sm-3 control-label no-padding-right">Entity ID <span class="text-danger">*</span></label>
                                                <div class="col-sm-9">
                                                    <input type="text" class="col-sm-10 required" required id="EntityID" name="EntityID" placeholder="Entity ID" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="URL" class="col-sm-3 control-label no-padding-right">URL</label>
                                                <div class="col-sm-9">
                                                    <input type="text" class="col-sm-10" id="URL" name="URL" placeholder="Link" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="Active" class="col-sm-3 control-label no-padding-right">Active</label>
                                                <div class="col-sm-9">
                                                    <div class="checkbox">
                                                        <label>
                                                            <input id="Active" type="checkbox" class="ace" />
                                                            <span class="lbl">Yes (Active).</span>
                                                        </label>
                                                    </div>
                                                </div>
                                            </div>
                                        </form>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer no-margin-top">
                                <button class="btn btn-sm btn-primary" id="btnSave">
                                    <i class="ace-icon fa fa-check"></i>
                                    Save
                                </button>
                                <button class="btn btn-sm btn-danger" data-dismiss="modal">
                                    <i class="ace-icon fa fa-times"></i>
                                    Close
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="deleteModal" class="modal fade" tabindex="-1">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header no-padding">
                                <div class="table-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                        <span class="white">&times;</span>
                                    </button>
                                    Delete item
                                </div>
                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-xs-12 col-sm-12">
                                        <form action="#" class="form-horizontal" id="removeForm">
                                            <label id="Label2">Are you sure to delete the selected item (<label class="removeField"></label>)?</label>
                                        </form>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer no-margin-top">
                                <button class="btn btn-sm btn-primary btn-delete" id="btnDelete">
                                    <i class="ace-icon fa fa-check"></i>
                                    Delete
                                </button>
                                <button class="btn btn-sm btn-danger" data-dismiss="modal">
                                    <i class="ace-icon fa fa-times"></i>
                                    Cancel
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content runat="server" ID="ddd" ContentPlaceHolderID="ContentPlaceHolder2">
    <style>
        .select2-container {
            width: 83% !important;
        }
    </style>
    <script src="/Scripts/sys/DefaultGridManager.js"></script>
    <script src="/Scripts/sys/numeral.min.js"></script>
    <script src="/Scripts/util/validationForm.js"></script>
    <script src="/Scripts/sys/admin/UrlRecordsManager.js?v=1.2"></script>
    <link href="/Scripts/select2/css/select2.min.css" rel="stylesheet" />
    <link href="/Scripts/select2/css/select2-optional.css" rel="stylesheet" />
    <script src="/Scripts/select2/js/select2.min.js"></script>
    <script src="/Scripts/select2/js/select2-optinal.js"></script>
</asp:Content>
