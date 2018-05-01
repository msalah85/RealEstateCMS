<%@ Page Title="تفاصيل الخبر" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewsDetails.aspx.cs" Inherits="Share.CMS.Web.NewsDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/Scripts/site/controllers/newsDetailsController.min.js"></script>
    <style>
        .news-image{max-height:500px;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div class="about">
        <div class="container">
            <h1 id="Title">عنوان الخبر</h1>
            <hr />
            <br />
            <br />
            <h5 id="Short"></h5>
            <br />
            <img id="ImageURL" src="Public/default.jpg" class="responsive-img news-image hidden" />
            <br /><br />
            <div class="contentsAbout" id="Details"></div>
            <br />
        </div>
    </div>
    <script>newsDetailsController.Init();</script>
</asp:Content>
