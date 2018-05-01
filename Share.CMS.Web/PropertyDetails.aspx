<%@ Page Title="تفاصيل العقار" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PropertyDetails.aspx.cs" Inherits="Share.CMS.Web.PropertyDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/content/masknvr1/css/slider-pro.css" media="screen" />
    <script src="/Scripts/site/controllers/propertyDetailsController.js?v=1.1"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="example3" class="slider-pro">
        <div class="sp-slides">
            <%--<div class="sp-slide">
                <img class="sp-image" src="/content/MasknVr1/img/blank.gif"
                    data-src="/content/MasknVr1/img/brokers.png"
                    data-small="http://bqworks.com/slider-pro/images/image1_large.jpg" />
                <p class="sp-layer sp-white sp-padding"
                    data-horizontal="50" data-vertical="50"
                    data-show-transition="left" data-show-delay="400">
                </p>
                <p class="sp-layer sp-black sp-padding"
                    data-horizontal="180" data-vertical="50"
                    data-show-transition="left" data-show-delay="600">
                </p>
                <p class="sp-layer sp-white sp-padding"
                    data-horizontal="315" data-vertical="50"
                    data-show-transition="left" data-show-delay="800">
                </p>
            </div>
            <div class="sp-slide">
                <img class="sp-image" src="/content/MasknVr1/img/blank.gif"
                    data-src="http://bqworks.com/slider-pro/images/image2_large.jpg" />
                <h3 class="sp-layer sp-black sp-padding"
                    data-horizontal="40" data-vertical="40"
                    data-show-transition="left"></h3>
                <p class="sp-layer sp-white sp-padding"
                    data-horizontal="40" data-vertical="100"
                    data-show-transition="left" data-show-delay="200">
                </p>
                <p class="sp-layer sp-black sp-padding"
                    data-horizontal="40" data-vertical="160" data-width="350"
                    data-show-transition="left" data-show-delay="400">
                </p>
            </div>
            <div class="sp-slide">
                <img class="sp-image" src="/content/MasknVr1/img/blank.gif"
                    data-src="http://bqworks.com/slider-pro/images/image3_large.jpg" />
                <p class="sp-layer sp-white sp-padding"
                    data-position="centerCenter" data-vertical="-50"
                    data-show-transition="right" data-show-delay="500">
                </p>
                <p class="sp-layer sp-black sp-padding"
                    data-position="centerCenter" data-vertical="50"
                    data-show-transition="left" data-show-delay="700">
                </p>
            </div>
            <div class="sp-slide">
                <img class="sp-image" src="/content/MasknVr1/img/blank.gif"
                    data-src="http://bqworks.com/slider-pro/images/image4_large.jpg" />
                <p class="sp-layer sp-black sp-padding"
                    data-position="bottomLeft" data-vertical="0" data-width="100%"
                    data-show-transition="up">
                </p>
            </div>
            <div class="sp-slide">
                <img class="sp-image" src="/content/MasknVr1/img/blank.gif"
                    data-src="http://bqworks.com/slider-pro/images/image5_large.jpg" />
                <p class="sp-layer sp-white sp-padding"
                    data-vertical="5%" data-horizontal="5%" data-width="90%"
                    data-show-transition="down" data-show-delay="400">
                </p>
            </div>
            <div class="sp-slide">
                <img class="sp-image" src="/content/MasknVr1/img/blank.gif"
                    data-src="http://bqworks.com/slider-pro/images/image6_large.jpg" />
                <p class="sp-layer sp-white sp-padding"
                    data-horizontal="10" data-vertical="10" data-width="300">
                </p>
            </div>
            <div class="sp-slide">
                <img class="sp-image" src="/content/MasknVr1/img/blank.gif"
                    data-src="http://bqworks.com/slider-pro/images/image7_large.jpg" />
                <p class="sp-layer sp-black sp-padding"
                    data-position="bottomLeft" data-horizontal="5%" data-vertical="5%" data-width="90%"
                    data-show-transition="up" data-show-delay="400">
                </p>
            </div>
            <div class="sp-slide">
                <img class="sp-image" src="/content/MasknVr1/img/blank.gif"
                    data-src="http://bqworks.com/slider-pro/images/image8_large.jpg" />
            </div>--%>
        </div>
        <div class="sp-thumbnails">
            <%--<img class="sp-thumbnail" src="/content/MasknVr1/img/s1.png" />
            <img class="sp-thumbnail" src="http://bqworks.com/slider-pro/images/image2_thumbnail.jpg" />
            <img class="sp-thumbnail" src="http://bqworks.com/slider-pro/images/image3_thumbnail.jpg" />
            <img class="sp-thumbnail" src="http://bqworks.com/slider-pro/images/image4_thumbnail.jpg" />
            <img class="sp-thumbnail" src="http://bqworks.com/slider-pro/images/image5_thumbnail.jpg" />
            <img class="sp-thumbnail" src="http://bqworks.com/slider-pro/images/image6_thumbnail.jpg" />
            <img class="sp-thumbnail" src="http://bqworks.com/slider-pro/images/image7_thumbnail.jpg" />
            <img class="sp-thumbnail" src="http://bqworks.com/slider-pro/images/image8_thumbnail.jpg" />--%>
        </div>
    </div>
    <div class="MainContent">
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-md-8" style="float: right">
                    <div class="title">
                        <h5 id="PropertyTitle"></h5>
                        <h6 id="BrefDesc"></h6>
                    </div>
                    <p id="Description"></p>
                    <ul class="prop">
                        <li>
                            <h5>البلد</h5>
                            <h6 id="CountryName"></h6>
                        </li>
                        <li>
                            <h5>المدينة</h5>
                            <h6 id="CityName"></h6>
                        </li>
                        <li>
                            <h5>المنطقة</h5>
                            <h6 id="ResidanceName"></h6>
                        </li>
                        <li>
                            <h5>اسم الشارع</h5>
                            <h6 id="StreetName"></h6>
                        </li>
                        <li>
                            <h5>عدد غرف النوم</h5>
                            <h6 id="BedRooms"></h6>
                        </li>
                        <li>
                            <h5>غرف اضافية</h5>
                            <h6 id="AdditionalRooms"></h6>
                        </li>
                        <li>
                            <h5>عدد الحمامات</h5>
                            <h6 id="Bathrooms"></h6>
                        </li>
                        <li>
                            <h5>عدد البلكونات</h5>
                            <h6 id="Balconies"></h6>
                        </li>
                        <li>
                            <h5>المساحة</h5>
                            <h6><span id="Area"></span>
                                <span id="AreaTypeNameAr"></span>
                            </h6>
                        </li>
                        <li>
                            <h5>السعر</h5>
                            <h6>
                                <span id="Price"></span>
                                <span id="PriceTypeNameAr"></span></h6>
                        </li>
                        <li>
                            <h5>الدور</h5>
                            <h6 id="Floor"></h6>
                        </li>
                        <li>
                            <h5>التشطيب</h5>
                            <h6 id="FurnitureTypeNameAr"></h6>
                        </li>
                    </ul>
                    <h5>وسائل الراحة</h5>
                    <ul class="Amenities"></ul>
                </div>
                <div class="col m4 l4">
                    <div class="rightContent">
                        <img src="/content/MasknVr1/img/userAbout.png" class="img-responsive" style="width: 200px; height: 200px; margin: 20px auto">
                        <div class="userDe">
                            <h5>مسكن.كوم</h5>
                            <h6>المكتب الرئيسي</h6>
                        </div>
                        <div class="row">
                            <div class="col m4 l4">
                                <select class="browser-default form-control">
                                    <option value="">البلد</option>
                                    <option value="1">الإمارات</option>
                                    <option value="2">مصر</option>
                                </select>
                            </div>
                            <div class="col m8 l8">
                                <div class="form-group ">
                                    <input placeholder="رقم الجوال" id="first_name" type="text" class="validate form-control ">
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col m12">
                                <button type="submit" onclick="javascript:alert('يرجي ادخال رقم الهاتف بطريقة صحيحة.');" class="btn btn-block btn-success">اطلب اتصال</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" src="/content/MasknVr1/js/jquery.sliderPro.js"></script>
    <script>
        var fireImagesSlide = function () {
            $('#example3').sliderPro({
                width: 1700,
                height: 500,
                fade: true,
                arrows: true,
                buttons: false,
                fullScreen: true,
                shuffle: true,
                smallSize: 500,
                mediumSize: 1000,
                largeSize: 3000,
                thumbnailArrows: true,
                autoplay: false
            });
        }

        propertyDetailsController.Init();
    </script>
</asp:Content>
