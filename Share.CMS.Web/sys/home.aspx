<%@ Page Title="SMS System" Language="C#" MasterPageFile="master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Share.CMS.Web.sys.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="breadcrumbs ace-save-state" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="ace-icon fa fa-home home-icon"></i>
                <a>Home</a>
            </li>
            <li class="active">Dashboard</li>
        </ul>
    </div>
    <div class="page-content">
        <div class="page-header">
            <h1>Dashboard</h1>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="alert alert-block alert-success">
                    <strong>Welcome</strong> To Share CMS [Basher Systems]
                   <button type="button" class="close" data-dismiss="alert"><i class="ace-icon fa fa-times"></i></button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
