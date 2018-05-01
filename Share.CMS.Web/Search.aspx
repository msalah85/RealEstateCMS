<%@ Page Title="نتيجة البحث" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Share.CMS.Web.Properties1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/Scripts/site/controllers/propertiesController.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="buildings text-center">
        <div class="slider">
            <div class="container">
                <img src="/content/MasknVr1/img/deals.png" class="img-responsive" />
                <h5>نتيجة البحث</h5>
                <p>
                    يمكنك تغيير معايير بحثك من الخيارات بأسفل
                </p>
                <i class="material-icons btn-floating waves-effect waves-light orange pull-left">room</i>
            </div>
        </div>
        <div class="buildingsDetails">
            <div class="container">
                <div class="filter">
                    <div class="row">
                        <div class="col-md-2">
                            <div class="input-group adv-search">
                                <div class="input-group-btn">
                                    <div class="btn-group" role="group">
                                        <div class="dropdown dropdown-lg">
                                            <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">الميزانية  <span class="caret"></span></button>
                                            <div class="dropdown-menu dropdown-menu-right" role="menu">
                                                <form class="form-horizontal" role="form">
                                                    <div class="row">
                                                        <div class="col m6 l6">
                                                            <div class="form-group">
                                                                <label>$ </label>
                                                                <input class="form-control" type="text" id="contain" />
                                                            </div>
                                                        </div>
                                                        <div class="col m6 l6">
                                                            <div class="form-group">
                                                                <label>$ </label>
                                                                <input class="form-control" type="text" id="contain2" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="collection">
                                                        <a href="#" class="collection-item">100</a>
                                                        <a href="#" class="collection-item ">200</a>
                                                        <a href="#" class="collection-item">300</a>
                                                        <a href="#" class="collection-item">400</a>
                                                    </div>
                                                </form>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="input-group adv-search bedroom">
                                <div class="input-group-btn">
                                    <div class="btn-group" role="group">
                                        <div class="dropdown dropdown-lg">
                                            <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">غرف النوم  <span class="caret"></span></button>
                                            <div class="dropdown-menu dropdown-menu-right" role="menu">
                                                <form class="form-horizontal" role="form">
                                                    <div class="row">
                                                        <div class="col m3">
                                                            <label>
                                                                <input type="checkbox" />
                                                                1 BHK
                                                            </label>
                                                        </div>
                                                        <div class="col m3">
                                                            <label>
                                                                <input type="checkbox" />
                                                                2 BHK
                                                            </label>
                                                        </div>
                                                        <div class="col m3">
                                                            <label>
                                                                <input type="checkbox" />
                                                                3 BHK
                                                            </label>
                                                        </div>
                                                        <div class="col m3">
                                                            <label>
                                                                <input type="checkbox" />
                                                                4 BHK
                                                            </label>
                                                        </div>
                                                    </div>
                                                </form>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="input-group adv-search more">
                                <div class="input-group-btn">
                                    <div class="btn-group" role="group">
                                        <div class="dropdown dropdown-lg">
                                            <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">المزيد  <span class="caret"></span></button>
                                            <div class="dropdown-menu dropdown-menu-right" role="menu" style="min-width: 750px">
                                                <form class="form-horizontal" role="form">
                                                    <div class="formLeft" style="width: 70%; float: right">
                                                        <div class="row">
                                                            <div class="col m12 12">
                                                                <h6>دورات المياه </h6>
                                                                <div class="row">
                                                                    <div class="col m2">
                                                                        <label class="bathroom">
                                                                            <input type="checkbox" />
                                                                            1 +
                                                                        </label>
                                                                    </div>
                                                                    <div class="col m2">
                                                                        <label class="bathroom">
                                                                            <input type="checkbox" />
                                                                            2 +
                                                                        </label>
                                                                    </div>
                                                                    <div class="col m2">
                                                                        <label class="bathroom">
                                                                            <input type="checkbox" />
                                                                            3 +
                                                                        </label>
                                                                    </div>
                                                                    <div class="col m2">
                                                                        <label class="bathroom">
                                                                            <input type="checkbox" />
                                                                            4 +
                                                                        </label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col l12 m12">
                                                                <div class="row">
                                                                    <div class="col m6 l6">
                                                                        <h6>مساحة العقار </h6>
                                                                        <select class="browser-default">
                                                                            <option value="" disabled selected>اختر </option>
                                                                            <option value="1">Option 1</option>
                                                                            <option value="2">Option 2</option>
                                                                            <option value="3">Option 3</option>
                                                                        </select>
                                                                    </div>
                                                                    <div class="col m6 l6">
                                                                        <h6>جديد / معاد بيعه </h6>
                                                                        <select class="browser-default">
                                                                            <option value="" disabled selected>اختر </option>
                                                                            <option value="1">الكل </option>
                                                                            <option value="2">جديد </option>
                                                                            <option value="3">معاد بيعه </option>
                                                                        </select>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col m12 l12">
                                                                <h6>Under Construction (Possession In)</h6>
                                                                <div class="row">
                                                                    <div class="col m3">
                                                                        <label class="bathroom">
                                                                            <input type="checkbox" />
                                                                            1 Year
                                                                        </label>
                                                                    </div>
                                                                    <div class="col m3">
                                                                        <label class="bathroom">
                                                                            <input type="checkbox" />
                                                                            2 Years
                                                                        </label>
                                                                    </div>
                                                                    <div class="col m3">
                                                                        <label class="bathroom">
                                                                            <input type="checkbox" />
                                                                            3 Years
                                                                        </label>
                                                                    </div>
                                                                    <div class="col m3">
                                                                        <label class="bathroom">
                                                                            <input type="checkbox" />
                                                                            4 Years
                                                                        </label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col m12 l12">
                                                                <h6>Under Construction (Possession In)</h6>
                                                                <div class="row">
                                                                    <div class="col m3">
                                                                        <label class="bathroom">
                                                                            <input type="checkbox" />
                                                                            1 Year
                                                                        </label>
                                                                    </div>
                                                                    <div class="col m3">
                                                                        <label class="bathroom">
                                                                            <input type="checkbox" />
                                                                            2 Years
                                                                        </label>
                                                                    </div>
                                                                    <div class="col m3">
                                                                        <label class="bathroom">
                                                                            <input type="checkbox" />
                                                                            3 Years
                                                                        </label>
                                                                    </div>
                                                                    <div class="col m3">
                                                                        <label class="bathroom">
                                                                            <input type="checkbox" />
                                                                            4 Years
                                                                        </label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="formRight" style="width: 30%; float: left">
                                                        <div class="row">
                                                            <div class="col m12 l12">
                                                                <div class="checkBoxProperty" style="float: right">
                                                                    <h6>property type </h6>
                                                                    <p style="margin-top: 20px;">
                                                                        <input type="checkbox" class="filled-in" id="choice1" />
                                                                        <label for="choice1">تجريبي </label>
                                                                    </p>
                                                                    <p style="margin-top: 5px;">
                                                                        <input type="checkbox" class="filled-in" id="choice2" />
                                                                        <label for="choice2">تجريبي </label>
                                                                    </p>
                                                                    <p style="margin-top: 5px;">
                                                                        <input type="checkbox" class="filled-in" id="choice3" />
                                                                        <label for="choice3">تجريبي </label>
                                                                    </p>
                                                                    <p style="margin-top: 5px;">
                                                                        <input type="checkbox" class="filled-in" id="choice4" />
                                                                        <label for="choice4">تجريبي </label>
                                                                    </p>
                                                                </div>
                                                            </div>
                                                            <div class="col m12 l12">
                                                                <div class="checkBoxProperty" style="float: right">
                                                                    <h6>property type </h6>
                                                                    <p style="margin-top: 20px;">
                                                                        <input type="checkbox" class="filled-in" id="choice5" />
                                                                        <label for="choice5">تجريبي </label>
                                                                    </p>
                                                                    <p style="margin-top: 5px;">
                                                                        <input type="checkbox" class="filled-in" id="choice6" />
                                                                        <label for="choice6">تجريبي </label>
                                                                    </p>
                                                                    <p style="margin-top: 5px;">
                                                                        <input type="checkbox" class="filled-in" id="choice7" />
                                                                        <label for="choice7">تجريبي </label>
                                                                    </p>
                                                                    <p style="margin-top: 5px;">
                                                                        <input type="checkbox" class="filled-in" id="choice8" />
                                                                        <label for="choice8">تجريبي </label>
                                                                    </p>
                                                                </div>
                                                            </div>
                                                            <div class="col m12 l12">
                                                                <div class="checkBoxProperty" style="float: right">
                                                                    <h6>property type </h6>
                                                                    <p style="margin-top: 20px;">
                                                                        <input type="checkbox" class="filled-in" id="choice9" />
                                                                        <label for="choice9"></label>
                                                                    </p>
                                                                    <p style="margin-top: 5px;">
                                                                        <input type="checkbox" class="filled-in" id="choice10" />
                                                                        <label for="choice10">تجريبي </label>
                                                                    </p>
                                                                    <p style="margin-top: 5px;">
                                                                        <input type="checkbox" class="filled-in" id="choice11" />
                                                                        <label for="choice11">تجريبي </label>
                                                                    </p>
                                                                    <p style="margin-top: 5px;">
                                                                        <input type="checkbox" class="filled-in" id="choice12" />
                                                                        <label for="choice12">تجريبي </label>
                                                                    </p>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </form>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col s12 m8 l8">
                        <div class="buildingLeftPart search-result"></div>
                        <div class="text-center more-button">
                            <div class="col m4 push-m1 ">
                                <a class="waves-effect waves-light orange btn btnMore" style="border-radius: 10px; margin-bottom: 20px;">عرض المزيد...</a>
                            </div>
                        </div>
                        <script>propertiesController.Init();</script>
                    </div>
                    <div class="col s12 m4">
                        <div class="buildingLeftPart">
                            <div class="card wow slideInLeft" data-wow-duration="2s" data-wow-delay=".9s">
                                <div class="card-content">
                                    <div class="row">
                                        <div class="col l12 m12 s12">
                                            <div class="media ">
                                                <div class="media-body" style="float: right; width: 70%; text-align: right">
                                                    <h5>تحميل التطبيق</h5>
                                                    <p style="width: 70%;">تطبيق مسكن متاح بجميع المتاجر الآن</p>
                                                    <a href="download-mobileapp" style="color: #ff8d0d;">
                                                        <h6 style="font-size: 17px; text-align: right">تحميل الآن</h6>
                                                    </a>

                                                </div>
                                                <a href="download-mobileapp" style="float: left!important; text-align: left; padding-top: 20px;">
                                                    <img class="media-object img-responsive" alt="img" src="/content/MasknVr1/img/download.png">
                                                </a>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                    </div>

                                </div>
                            </div>
                            <div class="card wow slideInLeft" data-wow-duration="2s" data-wow-delay=".9s">
                                <div class="card-content">
                                    <div class="row">
                                        <div class="col l12 m12 s12">
                                            <div class="media ">
                                                <div class="media-body" style="float: right; width: 70%; text-align: right">
                                                    <h5>تواصل معنا</h5>
                                                    <p style="width: 70%;">يسعدنا تلقى مشاركتك واستفساراتك.</p>
                                                    <a href="page/4" style="color: #ff8d0d;">
                                                        <h6 style="font-size: 17px; text-align: right">راسلنا الآن</h6>
                                                    </a>
                                                </div>
                                                <a href="page/4" style="float: left!important; text-align: left; padding-top: 20px;">
                                                    <img class="media-object img-responsive" alt="img" src="/content/MasknVr1/img/pyr.png">
                                                </a>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
