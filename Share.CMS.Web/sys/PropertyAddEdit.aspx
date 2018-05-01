<%@ Page Title="Add/Edit Property" Language="C#" MasterPageFile="master.master" AutoEventWireup="true" CodeBehind="PropertyAddEdit.aspx.cs" Inherits="Share.CMS.Web.sys.AddProperty" %>

<%@ Register Src="UserControls/PageSettings.ascx" TagPrefix="uc1" TagName="PageSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="/Scripts/sys/Common.min.js"></script>
    <script src="/Scripts/sys/DataService.min.js"></script>
    <script src="/Scripts/sys/DefaultGridVariables.min.js"></script>
    <script src="/content/sys/assets/js/jquery.validate.js"></script>
    <script src="/content/sys/assets/js/additional-methods.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs ace-save-state" id="breadcrumbs">
        <ul class="breadcrumb">
            <li>
                <i class="ace-icon fa fa-home home-icon"></i>
                <a href="home">Home</a>
            </li>
            <li class="active">Add/Edit Property</li>
        </ul>
    </div>
    <div class="page-content">
        <div class="page-header">
            <h1>Add/Edit Property</h1>
        </div>
        <div class="row">
            <form class="form-horizontal" role="form" id="masterForm">
                <div class="col-xs-6">
                    <div class="form-group">
                        <!--sale, rent -->
                        <label class="col-sm-3 control-label no-padding-right" for="ProjectTypeID">Project type <span class="text-danger">*</span></label>
                        <div class="col-sm-9">
                            <input type="hidden" id="PropertyID" value="0" />
                            <select id="ProjectTypeID" name="ProjectTypeID" class="required col-xs-10 col-sm-10 select2" required data-placeholder="Choose a one..." data-fn-name="ProjectTypes_Names" data-allow-clear="true">
                                <option></option>
                            </select>
                        </div>
                    </div>
                    <div class="form-group">
                        <!--villa, flat, land -->
                        <label class="col-sm-3 control-label no-padding-right" for="PropertyTypeID">Property type <span class="text-danger">*</span></label>
                        <div class="col-sm-9">
                            <select id="PropertyTypeID" name="PropertyTypeID" class="required col-xs-10 col-sm-10 select2" required data-placeholder="Choose a one..." data-fn-name="PropertyTypes_Names" data-allow-clear="true">
                                <option></option>
                            </select>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="CountryID">Country <span class="text-danger">*</span></label>
                        <div class="col-sm-9">
                            <select id="CountryID" name="CountryID" class="required col-xs-10 col-sm-10 select2" required data-placeholder="Choose a one..." data-fn-name="Regions_Names" data-allow-clear="true">
                                <option></option>
                            </select>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="CityID">City <span class="text-danger">*</span></label>
                        <div class="col-sm-9">
                            <select id="CityID" name="CityID" class="required col-xs-10 col-sm-10 select2" required data-placeholder="Choose a one..." data-fn-name="Regions_Names" data-allow-clear="true">
                                <option></option>
                            </select>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="ResidanceID">Residance <span class="text-danger">*</span></label>
                        <div class="col-sm-9">
                            <select id="ResidanceID" name="ResidanceID" class="required col-xs-10 col-sm-10 select2" required data-placeholder="Choose a one..." data-fn-name="Regions_Names" data-allow-clear="true">
                                <option></option>
                            </select>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="StreetID">Street <span class="text-danger">*</span></label>
                        <div class="col-sm-9">
                            <select id="StreetID" name="StreetID" class="required col-xs-10 col-sm-10 select2" required data-placeholder="Choose a one..." data-fn-name="Regions_Names" data-allow-clear="true">
                                <option></option>
                            </select>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="CreationDate">Date <span class="text-danger">*</span></label>
                        <div class="col-sm-9">
                            <input type="text" id="CreationDate" name="CreationDate" required class="required today date-picker col-xs-10 col-sm-10" data-date-format="mm/dd/yyyy" />
                        </div>
                    </div>
                </div>
                <div class="col-xs-6">
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="LocationLat">Location Lat <span class="text-danger">*</span></label>
                        <div class="col-sm-9">
                            <input type="text" id="LocationLat" name="LocationLat" required class="required col-xs-10 col-sm-10" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="LocationLang">Location Lang <span class="text-danger">*</span></label>
                        <div class="col-sm-9">
                            <input type="text" id="LocationLang" name="LocationLang" required class="required col-xs-10 col-sm-10" data-date-format="mm/dd/yyyy" />
                        </div>
                    </div>
                </div>

                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 control-label no-padding-right" for="PropertyTitle">Title</label>
                        <div class="col-sm-10">
                            <input type="text" id="PropertyTitle" required class="required" name="PropertyTitle" style="width: 92%" placeholder="Title..." />
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 control-label no-padding-right" for="Description">Description</label>
                        <div class="col-sm-10">
                            <textarea cols="12" rows="3" id="Description" required class="required" name="Description" style="width: 92%" placeholder="Description..."></textarea>
                        </div>
                    </div>
                </div>

                <div class="col-xs-6">
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="Area">Area <span class="text-danger">*</span></label>
                        <div class="col-sm-9">
                            <input type="number" id="Area" name="Area" class="required col-xs-10 col-sm-10" required />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="AreaTypeID">Area type <span class="text-danger">*</span></label>
                        <div class="col-sm-9">
                            <select id="AreaTypeID" name="AreaTypeID" class="required col-xs-10 col-sm-10 select2" required data-placeholder="Choose a one..." data-fn-name="AreaTypes_Names" data-allow-clear="true">
                                <option></option>
                            </select>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="Price">Price <span class="text-danger">*</span></label>
                        <div class="col-sm-9">
                            <input type="text" id="Price" name="Price" class="required col-xs-10 col-sm-10" required data-placeholder="00.00" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="PriceTypeID">Price type <span class="text-danger">*</span></label>
                        <div class="col-sm-9">
                            <select id="PriceTypeID" name="PriceTypeID" class="required col-xs-10 col-sm-10 select2" required data-placeholder="Choose a one..." data-fn-name="PriceTypes_Names" data-allow-clear="true">
                                <option></option>
                            </select>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="BedRooms">BedRooms <span class="text-danger">*</span></label>
                        <div class="col-sm-9">
                            <input type="number" id="BedRooms" name="BedRooms" class="required col-xs-10 col-sm-10" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="AdditionalRooms">Additional Rooms <span class="text-danger">*</span></label>
                        <div class="col-sm-9">
                            <input type="number" id="AdditionalRooms" name="AdditionalRooms" class="required col-xs-10 col-sm-10" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="Bathrooms">Bathrooms <span class="text-danger">*</span></label>
                        <div class="col-sm-9">
                            <input type="number" id="Bathrooms" name="Bathrooms" class="required col-xs-10 col-sm-10" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="Balconies">Balconies <span class="text-danger">*</span></label>
                        <div class="col-sm-9">
                            <input type="number" id="Balconies" name="Balconies" class="required col-xs-10 col-sm-10" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="Floor">Floor <span class="text-danger">*</span></label>
                        <div class="col-sm-9">
                            <input type="number" id="Floor" name="Floor" class="required col-xs-10 col-sm-10" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="FurnitureTypeID">Furniture type <span class="text-danger">*</span></label>
                        <div class="col-sm-9">
                            <select id="FurnitureTypeID" name="FurnitureTypeID" class="required col-xs-10 col-sm-10 select2" required data-placeholder="Choose a one..." data-fn-name="FurnitureTypes_Names" data-allow-clear="true">
                                <option></option>
                            </select>
                        </div>
                    </div>
                </div>
                <div class="col-xs-6">
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="FeatureID">Features <span class="text-danger">*</span></label>
                        <div class="col-sm-8">
                            <select class="required col-xs-10 col-sm-10 select2 form-control" name="FeatureID" multiple required
                                data-placeholder="Choose a feature..." data-fn-name="Features_Names" data-allow-clear="true">
                                <option></option>
                            </select>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="ContactPersonID">Agent <span class="text-danger">*</span></label>
                        <div class="col-sm-8">
                            <select class="required col-xs-10 col-sm-10 select2 form-control" id="ContactPersonID" name="ContactPersonID" required
                                data-placeholder="Choose agent..." data-fn-name="ContactPersons_Names" data-allow-clear="true">
                                <option></option>
                            </select>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="clearfix form-actions">
                        <div class="col-xs-10 col-xs-offset-1">
                            <button class="btn btn-app btn-success" type="submit" id="btnSave">
                                <i class="fa fa-save bigger-230"></i>
                                <br />
                                Save</button>
                        </div>
                    </div>
                </div>
            </form>
        </div>
        <div class="row">
            <div class="hr hr-24 sp-hr"></div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script src="/Scripts/sys/jquery.xml2json.min.js"></script>
    <script src="/Scripts/sys/numeral.min.js"></script>
    <script src="/Scripts/sys/DefaultMasterDetailsManager.js"></script>
    <link href="/Scripts/select2/css/select2.min.css" rel="stylesheet" />
    <link href="/Scripts/select2/css/select2-optional.css" rel="stylesheet" />
    <script src="/Scripts/select2/js/select2.min.js"></script>
    <script src="/Scripts/select2/js/select2-optinal.js?v=1.3"></script>
    <script src="/Scripts/sys/admin/PropertyAddEdit.js?v=2.2"></script>
    <script>pageManager.Init();</script>    
    <style>
        .error {
            border-color: #f2a696!important;
            color: #d68273!important;
            -webkit-box-shadow: none;
            box-shadow: none;
        }
    </style>
</asp:Content>