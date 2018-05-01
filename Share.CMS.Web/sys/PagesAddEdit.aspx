<%@ Page Title="Add/Edit Pages" Language="C#" MasterPageFile="master.master" AutoEventWireup="true" CodeBehind="PagesAddEdit.aspx.cs" Inherits="Share.CMS.Web.sys.PagesAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/content/sys/assets/css/bootstrap-editable.css" />
    <link href="/Scripts/select2/css/select2.min.css" rel="stylesheet" />
    <link href="/Scripts/select2/css/select2-optional.css" rel="stylesheet" />

    <script src="//cdn.ckeditor.com/4.7.1/standard/ckeditor.js"></script>

    <script src="/Scripts/sys/Common.js?v=1.3"></script>
    <script src="/Scripts/sys/DataService.min.js"></script>
    <script src="/Scripts/sys/DefaultGridVariables.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="breadcrumbs" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home home-icon"></i>
                <a href="Pages">Pages</a>
                <span class="divider">
                    <i class="icon-angle-right arrow-icon"></i>
                </span>
            </li>
            <li class="active">Add/Edit Pages</li>
        </ul>
    </div>
    <div class="page-content">
        <div class="page-header position-relative">
            <h1>Add/Edit Pages</h1>
        </div>
        <div class="row">
            <div class="col-xs-12 widget-container-col">
                <div class="clearfix">
                    <a role="button" href="Pages" class="btn btn-white btn-warning btn-bold"
                        tabindex="0" title="Add Page"><i class="fa fa-left-arrow bigger-110"></i>Back to list</a>
                </div>
                <div class="row">
                    <div class="col-xs-12 col-sm-10">
                        <form class="form-horizontal" role="form" id="addForm">
                            <input type="hidden" id="Id" value="0" />
                            <div class="form-group">
                                <label class="col-sm-3 control-label no-padding-right" for="LanguageId">Language <span class="text-danger">*</span></label>
                                <div class="col-sm-9">
                                    <select class="form-control col-sm-10 select2 required" id="LanguageId" name="LanguageId" data-fn-name="Languages_Names" data-placeholder="Language" data-allow-clear="true">
                                        <option value=""></option>
                                    </select>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="DisplayOrder" class="col-sm-3 control-label no-padding-right">Display Order <span class="text-danger">*</span></label>
                                <div class="col-sm-9">
                                    <input type="number" value="1" class="form-control col-sm-10 required" required id="DisplayOrder" name="DisplayOrder" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="Title" class="col-sm-3 control-label no-padding-right">Page Title <span class="text-danger">*</span></label>
                                <div class="col-sm-9">
                                    <input type="text" class="form-control col-sm-10 required" required id="Title" name="Title" placeholder="Title" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="Body" class="col-sm-3 control-label no-padding-right">Page Body</label>
                                <div class="col-sm-9">
                                    <textarea class="form-control col-sm-10 required ck-editor" id="Body" name="Body"></textarea>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="MetaTitle" class="col-sm-3 control-label no-padding-right">Meta title</label>
                                <div class="col-sm-9">
                                    <textarea cols="2" rows="2" class="form-control col-sm-10 required" id="MetaTitle" name="MetaTitle" placeholder="Meta title tag"></textarea>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="MetaKeywords" class="col-sm-3 control-label no-padding-right">Meta keywords</label>
                                <div class="col-sm-9">
                                    <textarea cols="2" rows="2" class="form-control col-sm-10 required" id="MetaKeywords" name="MetaKeywords" placeholder="Meta title tag"></textarea>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="MetaDescription" class="col-sm-3 control-label no-padding-right">Meta description</label>
                                <div class="col-sm-9">
                                    <textarea cols="2" rows="2" class="form-control col-sm-10 required" id="MetaDescription" name="MetaDescription" placeholder="Meta description tag"></textarea>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="Published" class="col-sm-3 control-label no-padding-right">Active</label>
                                <div class="col-sm-9">
                                    <div class="checkbox">
                                        <label>
                                            <input id="Published" type="checkbox" class="ace" />
                                            <span class="lbl">Yes (Active).</span>
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="IncludeInTopMenu" class="col-sm-3 control-label no-padding-right">Include In Top Menu</label>
                                <div class="col-sm-9">
                                    <div class="checkbox">
                                        <label>
                                            <input id="IncludeInTopMenu" type="checkbox" class="ace" />
                                            <span class="lbl">Yes, Show me.</span>
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="IncludeInFooterMenu" class="col-sm-3 control-label no-padding-right">Include In Footer Menu</label>
                                <div class="col-sm-9">
                                    <div class="checkbox">
                                        <label>
                                            <input id="IncludeInFooterMenu" type="checkbox" class="ace" />
                                            <span class="lbl">Yes, Show me.</span>
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label no-padding-right"></label>
                                <div class="col-sm-9">
                                    <button class="btn btn-app btn-success btnSave">
                                        <i class="ace-icon fa fa-check"></i>
                                        Save
                                    </button>
                                    <a href="Pages" class="btn btn-app btn-default">
                                        <i class="ace-icon fa fa-times"></i>
                                        Cancel
                                    </a>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <style>
        .error {
            color: #ff0000
        }

        .PhotoUrl {
            max-width: 200px;
        }
    </style>
    <script src="/content/sys/assets/js/jquery.validate.min.js"></script>
    <script src="/content/sys/assets/js/additional-methods.min.js"></script>

    <script src="/content/sys/assets/js/x-editable/bootstrap-editable.js"></script>
    <script src="/content/sys/assets/js/x-editable/ace-editable.js"></script>

    <script src="/Scripts/select2/js/select2.min.js"></script>
    <script src="/Scripts/select2/js/select2-optinal.js?v=1.3"></script>

    <script src="/Scripts/sys/admin/PagesAddManager.js?v=1.2"></script>
</asp:Content>
