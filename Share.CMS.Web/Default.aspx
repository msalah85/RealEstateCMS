<%@ Page Title="مرحبا بك فى" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Share.CMS.Web._Default" %>

<asp:Content runat="server" ContentPlaceHolderID="head" ID="topScripts">
    <script src="Scripts/site/homeController.js"></script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div class="video">
            <div class="container">
                <div class="video-container responsive-video">
                    <iframe width="853" height="300" src="//www.youtube.com/embed/YLLTFu8kqLs?rel=0" frameborder="0"></iframe>
                </div>
            </div>
            <div class="clearfix"></div>
        </div>
    </section>
    <section>
        <div class="news" id="news-list">
            <div class="container">
                <div class="section">
                    <h5>أحدث الأخبار</h5>
                    <h6>موقع مسكن اختيارك الأول للحصول على مسكنك الجديد</h6>
                </div>
                <div class="row top-news-list"></div>
                <script>homeController.Init();</script>
            </div>
            <div class="clearfix"></div>
        </div>
    </section>
    <div class="matches">
        <div class="container">
            <h2>مسكن.كوم عالم العقارات السهل والمميز</h2>
            <p>
                إلى كل من يشعر أنه يتوه في عالم الأرقام الكبيرة , مسكن توفر وسيلة سلسة و سهلة الفهم. بما أن الطريقة الوحيدة لتبسيط البيانات الهائلة هي الرسومات البيانية, تقدم مسكن خيار إظهار و استخدام العرض البياني لبحث العقارات الشائع, مما يجعل عملية استقطاب المعلومات أسهل لك.
إذا كنت ممن هم على علم بكيفية تطبيق هذه الأداة و لديك فكرة عن مدى تأثيرها فأنت تعلم تماماً كيف يمكنها مساعدتك في اتخاذ أكثر قرارات الأعمال ذكاءً في مشوارك المهني.
            </p>
        </div>
    </div>
    <div class="pin ">
        <div class="container">
            <div class="pinImg">
                <div class="img1">
                    <div class="row">
                        <div class="col-md-5 col-md-push-3">
                            <img src="/content/masknvr1/img/second.jpg" class="img-responsive">
                        </div>
                        <div class="col-md-7">
                            <p class="imgName">&nbsp;&nbsp;&nbsp;زيارة الموقع</p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 col-md-push-1">
                            <p>تعتبر زيارتك لمسكن جزء من نجاح الموقع على شبكة الأنترنت.</p>
                        </div>
                    </div>
                </div>
                <div class="img2">
                    <div class="row">
                        <div class="col-md-4 col-md-push-3">
                            <img src="/content/masknvr1/img/search.png" class="img-responsive">
                        </div>
                        <div class="col-md-8">
                            <p class="imgName">أدوات البحث</p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <p>يقدم موقع مسكن.كوم أدوات بحث سهله وذات نتيجه سريعه للمعاير التى تختارها.</p>
                        </div>
                    </div>
                </div>
                <div class="img3">
                    <div class="row">
                        <div class="col-md-4 col-md-push-3">
                            <img src="/content/masknvr1/img/happy.png" class="img-responsive">
                        </div>
                        <div class="col-md-8">
                            <p class="imgName">البيت السعيد</p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <p>يوجد لدينا فريق عمل للتواصل مع العملاء على مدار الاسبوع لتسهيل الحصول على العقار الذي وقع عليه الاختيار.</p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="pinMobile">
                <div class="row">
                    <div class="col col-sm-12">
                        <img src="/content/masknvr1/img/second.jpg" class="img-responsive" style="width: 150px; height: 180px; margin: 0 auto">
                        <h5>زيارة الموقع</h5>
                        <p>هذا النص هو مثال لنص يمكن أن يستبدل في نفس المساحة، لقد تم توليد هذا النص من مولد النص العربى، حيث يمكنك أن تولد مثل هذا النص أو العديد من النصوص الأخرى إضافة إلى زيادة عدد الحروف التى يولدها التطبيق.</p>
                    </div>
                    <div class="col col-sm-12">
                        <img src="/content/masknvr1/img/search.png" class="img-responsive" style="width: 150px; height: 180px; margin: 0 auto">
                        <h5>بحث  </h5>
                        <p>هذا النص هو مثال لنص يمكن أن يستبدل في نفس المساحة، لقد تم توليد هذا النص من مولد النص العربى، حيث يمكنك أن تولد مثل هذا النص أو العديد من النصوص الأخرى إضافة إلى زيادة عدد الحروف التى يولدها التطبيق.</p>
                    </div>
                    <div class="col col-sm-12">
                        <img src="/content/masknvr1/img/happy.png" class="img-responsive" style="width: 150px; height: 180px; margin: 0 auto">
                        <h5>البيت السعيد </h5>
                        <p>هذا النص هو مثال لنص يمكن أن يستبدل في نفس المساحة، لقد تم توليد هذا النص من مولد النص العربى، حيث يمكنك أن تولد مثل هذا النص أو العديد من النصوص الأخرى إضافة إلى زيادة عدد الحروف التى يولدها التطبيق.</p>
                    </div>
                </div>
            </div>
        </div>
        <div class="clearfix"></div>
    </div>
    <div class="update">
        <div class="container">
            <h2>الاشتراك فى النشرة الإخبارية لمسكن</h2>
            <p>
                لمتابعة أخبار مسكن أول بأول
                يرجي إدخال البريد الإلكتروني الخاص بك والإشتراك فى القائمة البريدية لموقع مسكن
            </p>
            <div class="row">
                <form class="col s6 pull-s3">
                    <div class="custom-search-input">
                        <div class="input-group col-md-12">
                            <input type="text" class="form-control input-lg" placeholder="البريد الإلكتروني" />
                            <span class="input-group-btn">
                                <button class="btn btn-info btn-lg" type="button">
                                    <i class="glyphicon glyphicon-send"></i>
                                </button>
                            </span>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>