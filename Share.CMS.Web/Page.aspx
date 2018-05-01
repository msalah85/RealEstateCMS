<%@ Page Title="Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Page.aspx.cs" Inherits="Share.CMS.Web.About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/Scripts/site/controllers/pageDetailsController.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div class="about">
        <div class="container">
            <h1 id="Title"></h1>
            <hr />
            <br />
            <div class="contentsAbout" id="Body"></div>
            <br />
        </div>
    </div>
    <script>pageDetailsController.Init();</script>
</asp:Content>
