<%@ Page Title="" Language="C#" MasterPageFile="~/Gama.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="GamaEventMgmt.Registration.Register" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../Stylesheets/styles.css" type="text/css" />

    <style type="text/css">
    .ModalPopupBG
    {
        background-color: #666699;
        filter: alpha(opacity=50);
        opacity: 0.7;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>

    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
        <ProgressTemplate>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/ajax-busy.gif" /><asp:Label ID="lblProcessing" runat="server" Text="Processing..."></asp:Label>
        </ProgressTemplate>
    </asp:UpdateProgress>
    
    
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div id="dvSystemMessages" class="success" runat="server" visible="false">
        &nbsp;<asp:Label ID="lblDisplayMessages" runat="server" Text="" ></asp:Label>
    </div>
    <div id="dvWarningMessages" class="warning" runat="server" visible="false"><asp:Label ID="lblWarningMessages" runat="server" CssClass="sysInstrMessagesWarning"></asp:Label></div>
    <div id="dvErrorMEssages" class="error" runat="server" visible="false">
        <asp:Label ID="lblInfo" runat="server" Text="" />

    </div>

    <asp:Label ID="lblMultiReg" runat="server" Text="Performing multiple registrations?"></asp:Label>
    <asp:CheckBox ID="chkMultiReg" AutoPostBack="true" runat="server" Text="Yes" OnCheckedChanged="chkMultiReg_CheckedChanged" /><br />

    <hr />

    <%--<asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" cancelcontrolid="btnCancel" 
	okcontrolid="btnOkay" targetcontrolid="chkMultiReg" 
	popupcontrolid="Panel1" popupdraghandlecontrolid="PopupHeader" 
	drag="true" backgroundcssclass="ModalPopupBG">

    </asp:ModalPopupExtender>--%>

   <div class="popupConfirmation" id="Panel1" style="display: none">
    <iframe id="frameeditexpanse" src="superRegistrantRegister.aspx" frameborder="0" width="800px" height="400px" >
    </iframe>
    <div class="popup_Buttons" style="display: none">
        <input id="btnOkay" type="button" value="Done" />
        <input id="btnCancel" type="button" value="Cancel" />
    </div>
</div>

    <asp:Label ID="lblRegEmailAddress" runat="server" Text="Email Address:"></asp:Label>&nbsp;
    <asp:TextBox ID="tbxRegistrantEmailAddress" runat="server"></asp:TextBox>

    <asp:TabContainer ID="tbcRegistration" runat="server" ActiveTabIndex="0">
        <asp:TabPanel runat="server" HeaderText="Business Information" ID="tbpBusInfo" >
            <ContentTemplate>
                
            <table>
                <tr>
                    <td>Title (*)</td>
                    <td><asp:DropDownList ID="ddlTitle" runat="server">
                        <asp:ListItem Text="-Choose One-" Value=""></asp:ListItem>
                        <asp:ListItem Text="Mr" Value="Mr"></asp:ListItem>
                        <asp:ListItem Text="Ms" Value="Ms"></asp:ListItem>
                        <asp:ListItem Text="Mrs" Value="Mrs"></asp:ListItem>
                        <asp:ListItem Text="Dr" Value="Dr"></asp:ListItem>
                        <asp:ListItem Text="Prof" Value="Prof"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvTitle" ControlToValidate="ddlTitle" runat="server" ErrorMessage="Please select title" Display="None"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" TargetControlID="rfvTitle" runat="server" CssClass="customCalloutStyle" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/close.png"></asp:ValidatorCalloutExtender>

                    </td>
                </tr>
                <tr>
                    <td>Last Name (*)</td>
                    <td><asp:TextBox ID="tbxLastName" runat="server"></asp:TextBox>                        
                        <asp:RequiredFieldValidator ID="rfvLastName" ControlToValidate="tbxLastName" runat="server" ErrorMessage="Please enter Last Name" Display="None"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" TargetControlID="rfvLastName" runat="server" CssClass="customCalloutStyle" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/close.png"></asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td>First Name (*)</td>
                    <td><asp:TextBox ID="tbxFirstName" runat="server"></asp:TextBox></td>
                        <asp:RequiredFieldValidator ID="rfvFirstName" ControlToValidate="tbxFirstName" runat="server" ErrorMessage="Please enter First Name" Display="None"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" TargetControlID="rfvFirstName" runat="server" CssClass="customCalloutStyle" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/close.png"></asp:ValidatorCalloutExtender>
                </tr>

                <tr>
                    <td>Middle Name</td>
                    <td><asp:TextBox ID="tbxMiddleName" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>Business Email Address(*)</td>
                    <td><asp:TextBox ID="tbxBusEmailAddress" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvBusEmailAddr" ControlToValidate="tbxBusEmailAddress" runat="server" ErrorMessage="Please enter Business Email Address" Display="None"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" TargetControlID="rfvBusEmailAddr" runat="server" CssClass="customCalloutStyle" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/close.png"></asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td>Confirm Business Email Address (*)</td>
                    <td><asp:TextBox ID="tbxConfBusEmailAddress" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvConfBusEmailAddr" ControlToValidate="tbxConfBusEmailAddress" runat="server" ErrorMessage="Please confirm Business Email Address" Display="None"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" TargetControlID="rfvConfBusEmailAddr" runat="server" CssClass="customCalloutStyle" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/close.png"></asp:ValidatorCalloutExtender>
                        <asp:CompareValidator ID="cmvBusEmail" runat="server" Display="None" ErrorMessage="Email addresses do not match" ControlToCompare="tbxBusEmailAddress" ControlToValidate="tbxConfBusEmailAddress"></asp:CompareValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender13" EnableViewState="false" TargetControlID="cmvBusEmail" runat="server" CssClass="customCalloutStyle" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/close.png"></asp:ValidatorCalloutExtender>
                    </td>
                </tr>

                <tr>
                    <td>Legal Name as it appears exactly in Passport or ID (*)</td>
                    <td><asp:TextBox ID="tbxLegalName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvLegalName" ControlToValidate="tbxLegalName" runat="server" ErrorMessage="Please enter Legal Name" Display="None"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" TargetControlID="rfvLegalName" runat="server" CssClass="customCalloutStyle" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/close.png"></asp:ValidatorCalloutExtender>
                    </td>
                </tr>

                <tr>
                    <td>Date of Birth (*) </td>
                    <td><asp:TextBox ID="tbxDateOfBirth" runat="server"></asp:TextBox>
                        <asp:CalendarExtender ID="cleDateOfBirth" TargetControlID="tbxDateOfBirth" runat="server" Format="yyyy/MM/dd"></asp:CalendarExtender>
                        <asp:RequiredFieldValidator ID="rfvDateofBirth" ControlToValidate="tbxDateOfBirth" runat="server" ErrorMessage="Please enter Date of Birth" Display="None"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" TargetControlID="rfvDateofBirth" runat="server" CssClass="customCalloutStyle" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/close.png"></asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">If traveling internationally, please fill out the following information:</td>
                </tr>
                <tr>
                    <td>Passport (ID) Number (*) </td>
                    <td>
                        <asp:TextBox ID="tbxPassportIdNum" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPassportId" ControlToValidate="tbxPassportIdNum" runat="server" ErrorMessage="Please enter Passport / ID Number" Display="None"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" TargetControlID="rfvPassportId" runat="server" CssClass="customCalloutStyle" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/close.png"></asp:ValidatorCalloutExtender>
                        <asp:FilteredTextBoxExtender ID="ftePassportIdNum" TargetControlID="tbxPassportIdNum" FilterType="Numbers" runat="server"></asp:FilteredTextBoxExtender>
                    </td>
                </tr>
                <tr>
                    <td>Place of Birth (*)</td>
                    <td><asp:TextBox ID="tbxPlaceofBirth" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPlaceofBirth" ControlToValidate="tbxPlaceofBirth" runat="server" ErrorMessage="Please enter Place of Birth" Display="None"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" TargetControlID="rfvPlaceofBirth" runat="server" CssClass="customCalloutStyle" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/close.png"></asp:ValidatorCalloutExtender>
                    </td>
                </tr>

                <tr>
                    <td>Place of Issue (State for ID, Country for International) (*) </td>
                    <td><asp:TextBox ID="tbxPlaceofIssue" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPlaceofIssue" ControlToValidate="tbxPlaceofIssue" runat="server" ErrorMessage="Please enter Place of Issue" Display="None"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" TargetControlID="rfvPlaceofIssue" runat="server" CssClass="customCalloutStyle" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/close.png"></asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td>Passport Date of Issue (*)</td>
                    <td><asp:TextBox ID="tbxDateofIssue" runat="server"></asp:TextBox>
                        <asp:CalendarExtender ID="cleDateofIssue" TargetControlID="tbxDateofIssue" runat="server" Format="yyyy/MM/dd"></asp:CalendarExtender>
                        <asp:RequiredFieldValidator ID="rfvDateofIssue" ControlToValidate="tbxDateofIssue" runat="server" ErrorMessage="Please enter Date of Issue" Display="None"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" TargetControlID="rfvDateofIssue" runat="server" CssClass="customCalloutStyle" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/close.png"></asp:ValidatorCalloutExtender>

                    </td>
                </tr>
                <tr>
                    <td>Passport Expiration Date (*)</td>
                    <td><asp:TextBox ID="tbxExpirationDate" runat="server"></asp:TextBox>
                        <asp:CalendarExtender ID="cleExpDate" TargetControlID="tbxExpirationDate" runat="server" Format="yyyy/MM/dd"></asp:CalendarExtender>
                        <asp:RequiredFieldValidator ID="rfvExpDate" ControlToValidate="tbxExpirationDate" runat="server" ErrorMessage="Please enter Expiration Date" Display="None"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" TargetControlID="rfvExpDate" runat="server" CssClass="customCalloutStyle" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/close.png"></asp:ValidatorCalloutExtender>

                    </td>
                </tr>
            </table>
                <asp:Button ID="btnUpdate" runat="server" Text="Update" Visible="false" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnSaveNextBusInfo" runat="server" Text="Save and Continue" OnClick="btnSaveNextBusInfo_Click" />

            </ContentTemplate>
        </asp:TabPanel>

        <asp:TabPanel HeaderText="Additional Travellers" ID="tbpAdditionalTravellers" runat="server">
            <ContentTemplate>
                <asp:GridView ID="gvwAddTravellers" runat="server" AutoGenerateColumns="False" ShowFooter="True" DataKeyNames="aam_id" OnRowCancelingEdit="gvwAddTravellers_RowCancelingEdit" OnRowCommand="gvwAddTravellers_RowCommand" OnRowDeleting="gvwAddTravellers_RowDeleting" OnRowEditing="gvwAddTravellers_RowEditing" OnRowUpdating="gvwAddTravellers_RowUpdating">

                <Columns>
                    <asp:TemplateField HeaderText="Name" SortExpression="aam_Name">
                        <EditItemTemplate>
                            <asp:TextBox ID="tbxEditName" runat="server" Text='<%# Bind("aam_Name") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="tbxNewName" runat="server"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%# Bind("aam_Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Surname" SortExpression="aam_Surname">
                        <EditItemTemplate>
                            <asp:TextBox ID="tbxEditSurname" runat="server" Text='<%# Bind("aam_Surname") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="tbxNewSurname" runat="server"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblSurname" runat="server" Text='<%# Bind("aam_Surname") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email" SortExpression="aam_Email">
                        <EditItemTemplate>
                            <asp:TextBox ID="tbxEditEmail" runat="server" Text='<%# Bind("aam_Email") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="tbxNewEmail" runat="server"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("aam_Email") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Update" Text="Update"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:LinkButton ID="lbtAddNew" runat="server" CommandName="AddNew" CausesValidation="false">Add New</asp:LinkButton>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>

            </asp:GridView>
                <asp:Button ID="btnAdditionalTrav" runat="server" Text="Save and Continue" OnClick="btnAdditionalTrav_Click" />
            </ContentTemplate>
        </asp:TabPanel>
        
        <asp:TabPanel HeaderText="Additional Business Info" ID="tbpAddBusInfo" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>Request Form ID (For official use only) </td>
                        <td><input type="text" /></td>
                    </tr>
                <tr>
                    <td>Travel # (For official use only) </td>
                    <td><input type="text" /></td>
                </tr>
                <tr>
                    <td>Site Personal (For official use only) </td>
                    <td><input type="text" /></td>
                </tr>
                <tr>
                    <td>Gama Personal (For official use only) </td>
                    <td><input type="text" /></td>
                </tr>
                <tr>
                    <td>Street Address </td>
                    <td><asp:TextBox ID="tbxStreetAddress1" runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td>Street Address 2</td>
                    <td><asp:TextBox ID="tbxStreetAddress2" runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td>Street Address 3</td>
                    <td><asp:TextBox ID="tbxStreetAddress3" runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td>City</td>
                    <td><asp:TextBox ID="tbxCity" runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td>State / Province</td>
                    <td><asp:TextBox runat="server" ID="tbxStateProvince"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Country </td>
                    <td>
                        <asp:DropDownList ID="ddlCountry" runat="server" DataSourceID="odsCountries" DataTextField="cnt_Name" DataValueField="cnt_id" AppendDataBoundItems="true">
                            <asp:ListItem Value="0" Text="Select Country"></asp:ListItem>
                        </asp:DropDownList>
            <asp:ObjectDataSource ID="odsCountries" runat="server" SelectMethod="getAllCountriesAndRegions" TypeName="Gama.Country"></asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td>Zip </td>
                    <td><asp:TextBox ID="tbxZip" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Business Phone </td>
                    <td><asp:TextBox ID="tbxBusPhone" runat="server"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="fteBusPhone" TargetControlID="tbxBusPhone" FilterType="Numbers" runat="server"></asp:FilteredTextBoxExtender>
                    </td>
                </tr>
                <tr>
                    <td>Business Fax </td>
                    <td><asp:TextBox ID="tbxBusFax" runat="server"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="fteBusFax" TargetControlID="tbxBusFax" FilterType="Numbers" runat="server"></asp:FilteredTextBoxExtender>

                    </td>
                </tr>
                </table>
                <asp:Button ID="btnSaveNextAddBusInfo" runat="server" Text="Save and Continue" OnClick="btnSaveNextAddBusInfo_Click" />
                <asp:Button ID="btnUpdateAddBusInfo" runat="server" Visible="false" Text="Update" OnClick="btnUpdateAddBusInfo_Click" />
            </ContentTemplate>
        </asp:TabPanel>

        <asp:TabPanel HeaderText="Personal Info" ID="tbpPersonalInfo" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>Home Phone Number</td>
                        <td><asp:TextBox ID="tbxHomePhoneNumber" runat="server"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="fteHomePhoneNumber" TargetControlID="tbxHomePhoneNumber" FilterType="Numbers" runat="server"></asp:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>Cellular Phone Number</td>
                        <td><asp:TextBox ID="tbxCellPhone" runat="server"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="fteCellPhone" TargetControlID="tbxCellPhone" FilterType="Numbers" runat="server"></asp:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>Alternate Email Address </td>
                        <td><asp:TextBox ID="tbxAltEmailAddress" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Confirm Alternate Email Address</td>
                        <td><asp:TextBox ID="tbxConfAltEmailAddress" runat="server"></asp:TextBox>
                            <asp:CompareValidator ID="cmvEmailAddress" runat="server" Display="None" ErrorMessage="Email addresses do not match" ControlToCompare="tbxAltEmailAddress" ControlToValidate="tbxConfAltEmailAddress"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender14" EnableViewState="false" TargetControlID="cmvEmailAddress" runat="server" CssClass="customCalloutStyle" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/close.png"></asp:ValidatorCalloutExtender>

                        </td>
                    </tr>
                    <tr>
                        <td>Emergency Contact Name </td>
                        <td><asp:TextBox ID="tbxEmergContactName" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Emergency Contact Phone Number </td>
                        <td><asp:TextBox ID="tbxEmergContPhoneNum" runat="server"></asp:TextBox></td>
                    </tr>
                </table>
                <asp:Button ID="btnSaveContinuePersInfo" runat="server" Text="Save and Continue" OnClick="btnSaveContinuePersInfo_Click" />
            </ContentTemplate>
        </asp:TabPanel>

        <asp:TabPanel HeaderText="General Requirements" ID="tbpGenReq" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>Class of Service</td>
                        <td><asp:DropDownList ID="ddlClassOfService" runat="server">
                            <asp:ListItem Value="" Text="-Select Service-"></asp:ListItem>
                            <asp:ListItem Value="Business" Text="Business"></asp:ListItem>
                            <asp:ListItem Value="Coach" Text="Coach"></asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>Seating Preference</td>
                        <td>
                            <asp:DropDownList ID="cblSeatingPref" runat="server">
                                <asp:ListItem Value="Aisle" Text="Aisle"></asp:ListItem>
                                <asp:ListItem Value="Window" Text="Window"></asp:ListItem>
                                <asp:ListItem Value="Front" Text="Front"></asp:ListItem>
                                <asp:ListItem Value="Back" Text="Back"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>Special Disability Requirements</td>
                        <td><asp:TextBox ID="tbxDisabilityComment" TextMode="MultiLine" Rows="5" runat="server"></asp:TextBox></td>
                    </tr>
                </table>
                <asp:Button ID="btnSaveContinueGenReqs" runat="server" Text="Save and Continue" OnClick="btnSaveContinueGenReqs_Click"  />
            </ContentTemplate>
        </asp:TabPanel>

        <asp:TabPanel HeaderText="City and Airport Info" ID="tbpCityAirportInfo" runat="server">
            <ContentTemplate>
            <asp:GridView ID="gvwCityAirport" runat="server" AutoGenerateColumns="False" DataKeyNames="aec_id, atn_id, evt_id" ShowFooter="True" OnInit="gvwCityAirport_Init" OnRowCancelingEdit="gvwCityAirport_RowCancelingEdit" OnRowCommand="gvwCityAirport_RowCommand" OnRowDataBound="gvwCityAirport_RowDataBound" OnRowDeleting="gvwCityAirport_RowDeleting" OnRowEditing="gvwCityAirport_RowEditing" OnRowUpdating="gvwCityAirport_RowUpdating">
        <Columns>
            <asp:TemplateField HeaderText="Departure City" SortExpression="aec_DepartureCity">
                <EditItemTemplate>
                    <asp:TextBox ID="tbxEditDepartCity" runat="server" Text='<%# Bind("aec_DepartureCity") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="tbxNewDepartCity" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblDepartureCity" runat="server" Text='<%# Bind("aec_DepartureCity") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Departure Airport" SortExpression="aec_DepartureAirport">
                <EditItemTemplate>
                    <asp:TextBox ID="tbxEditDepartAirport" runat="server" Text='<%# Bind("aec_DepartureAirport") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="tbxNewDepartAirport" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblDpartAirport" runat="server" Text='<%# Bind("aec_DepartureAirport") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Departure Date" SortExpression="aec_DepartureDate">
                <EditItemTemplate>
                    <asp:TextBox ID="tbxEditDepartDate" runat="server" Text='<%# Bind("aec_DepartureDate") %>'></asp:TextBox>
                    <asp:CalendarExtender ID="cleEditDepartDate" TargetControlID="tbxEditDepartDate" Format="yyyy/MM/dd" runat="server"></asp:CalendarExtender>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="tbxNewDepartDate" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="cleNewDepDate" TargetControlID="tbxNewDepartDate" Format="yyyy/MM/dd" runat="server"></asp:CalendarExtender>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblDepartDate" runat="server" Text='<%# Bind("aec_DepartureDate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Departure Time" SortExpression="aec_DepartureTime">
                <EditItemTemplate>
                    <asp:TextBox ID="tbxEditDepartTime" runat="server" Text='<%# Bind("aec_DepartureTime") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="tbxNewDepartTime" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblDepartTime" runat="server" Text='<%# Bind("aec_DepartureTime") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Arrival Date" SortExpression="aec_ArrivalDate">
                <EditItemTemplate>
                    <asp:TextBox ID="tbxEditArrDate" runat="server" Text='<%# Bind("aec_ArrivalDate") %>'></asp:TextBox>
                    <asp:CalendarExtender ID="cleEditArrDate" Format="yyyy/MM/dd" TargetControlID="tbxEditArrDate" runat="server"></asp:CalendarExtender>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="tbxNewArrDate" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="cleNewArrDate" Format="yyyy/MM/dd" TargetControlID="tbxNewArrDate" runat="server"></asp:CalendarExtender>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblArrDate" runat="server" Text='<%# Bind("aec_ArrivalDate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Arrival Time" SortExpression="aec_ArrivalTime">
                <EditItemTemplate>
                    <asp:TextBox ID="tbxEditArrTime" runat="server" Text='<%# Bind("aec_ArrivalTime") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="tbxNewArrTime" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblArrTime" runat="server" Text='<%# Bind("aec_ArrivalTime") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Pref Airline Name or Code" SortExpression="aec_PreferredAirlineName_Code">
                <EditItemTemplate>
                    <asp:TextBox ID="tbxEditPrefAirline" runat="server" Text='<%# Bind("aec_PreferredAirlineName_Code") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="tbxNewPrefAirline" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblPrefAirline" runat="server" Text='<%# Bind("aec_PreferredAirlineName_Code") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Pref Flight Number" SortExpression="aec_FlightNumber">
                <EditItemTemplate>
                    <asp:TextBox ID="tbxEditPrefFlightNum" runat="server" Text='<%# Bind("aec_FlightNumber") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="tbxNewPrefFlightNum" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblPrefFlightNum" runat="server" Text='<%# Bind("aec_FlightNumber") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Update" Text="Update"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:LinkButton ID="lbtAddNew" runat="server" CommandName="AddNew" CausesValidation="False">Add New</asp:LinkButton>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
            </asp:GridView>
                <asp:Button ID="btnSaveContinueAirportCity" runat="server" Text="Save and Continue" OnClick="btnSaveContinueAirportCity_Click" />
            </ContentTemplate>
        </asp:TabPanel>

        <asp:TabPanel HeaderText="Prefered Flight" ID="tbpPrefFligh" runat="server">
        <ContentTemplate>
                
                <asp:Button ID="btnPrefFlight" runat="server" Text="Save and Continue" OnClick="btnPrefFlight_Click" />
            </ContentTemplate>
        </asp:TabPanel>

        <asp:TabPanel HeaderText="Prefered Airline" ID="tbpPrefAirline" runat="server">
            <ContentTemplate>
                <asp:GridView ID="gvwPrefAirline" runat="server"></asp:GridView>

                <asp:Button ID="btnPrefAirline" runat="server" Text="Save and Continue" OnClick="btnPrefAirline_Click" />
            </ContentTemplate>
        </asp:TabPanel>

        <asp:TabPanel HeaderText="Airline and Membership Number" ID="TabPanel1" runat="server">
            <ContentTemplate>
                <asp:HiddenField ID="hdf_alm_id" runat="server" />
                <table>
                    <tr>
                        <td>Airline Name or Code</td>
                        <td><asp:TextBox ID="tbxAirlineNameOrCode" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr><td>Membership Number</td>
                        <td><asp:TextBox ID="tbxAirlineMemNumber" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td> <asp:Button ID="btnSaveAirline" runat="server" Text="Save" OnClick="btnSaveAirline_Click" />
                             <asp:Button ID="btnUpdateAirline" runat="server" Text="Update" OnClick="btnUpdateAirline_Click" Visible="false" CausesValidation="false" />
                        </td>
                    </tr>

                </table>
                <asp:GridView ID="gvwAirlineMemNumber" DataKeyNames="alm_id" AutoGenerateColumns="False" DataSourceID="odsAirlineMemNumber" runat="server" OnSelectedIndexChanged="gvwAirlineMemNumber_SelectedIndexChanged" OnRowCommand="gvwAirlineMemNumber_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Airline Membership Number">
                            <ItemTemplate>
                                <asp:Label ID="lblAirlineName" runat="server" Text='<%# Bind("aam_AirlineName_Code") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Airline Name or Code">
                            <ItemTemplate>
                                <asp:Label ID="lblAirlineMemberNum" runat="server" Text='<%# Bind("aam_MembershipNumber") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtSelect" runat="server" CausesValidation="false" 
                    CommandName="SelectRecord" Text="Select" CommandArgument='<%# Container.DataItemIndex %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                        
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsAirlineMemNumber" runat="server" SelectMethod="getAttendeeAirlineMembership" TypeName="Gama.Attendee">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="atn_id" Type="Int32" />
        </SelectParameters>
            </asp:ObjectDataSource>

                <asp:Button ID="btnSaveContinueAirlineMem" runat="server" Text="Continue" OnClick="btnSaveContinueAirlineMem_Click" CausesValidation="false" />
            </ContentTemplate>
        </asp:TabPanel>

        <asp:TabPanel HeaderText="Meal Info" ID="tbpMealInfo" runat="server">
            <ContentTemplate>
            <table>
                <tr>
                    <td>Special Meal Request</td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBoxList ID="cblMealReqs" OnDataBound="cblMealReqs_DataBound" DataSourceID="odsMealReqs" DataValueField="mrq_id" DataTextField="mrq_Meal" runat="server"></asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td>Any Allergies? <asp:TextBox ID="tbxAllergies" runat="server"></asp:TextBox></td>
                    
                </tr>
                <tr>
                    <td><asp:Button ID="btnSaveMealReq" runat="server" Text="Save Meal Requirement" OnClick="btnSaveMealReq_Click"/></td>
                </tr>
            </table>
            <asp:ObjectDataSource ID="odsMealReqs" runat="server" SelectMethod="getAllMealRequirements" TypeName="Gama.Attendee"></asp:ObjectDataSource>
            <asp:Button ID="btnSaveContinueMealInfo" runat="server" Text="Save and Continue" OnClick="btnSaveContinueMealInfo_Click" />
            </ContentTemplate>
        </asp:TabPanel>

        <asp:TabPanel HeaderText="Visa Check" ID="tbpVisaCheck" runat="server">
            <ContentTemplate>
            <table>
                <tr>
                    <td>Visa Check</td>
                </tr>
            </table>
            <asp:Button ID="btnSaveContinueVisaCheck" runat="server" Text="Save and Continue" OnClick="btnSaveContinueVisaCheck_Click" />
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel HeaderText="Visa Information" ID="tbpVisaInfo" runat="server">
            <ContentTemplate>
                <asp:HiddenField ID="hdf_avr_id" runat="server" />
                <table>
                    <tr>
                        <td>Citizenship(s)</td>
                        <td><asp:TextBox ID="tbxCitizenship" runat="server"></asp:TextBox></td>
                    </tr>
                </table>
                <asp:Button ID="btnSaveCitizenship" CausesValidation="false" runat="server" Text="Save Citizenship" OnClick="btnSaveCitizenship_Click" />
                <asp:Button ID="btnUpdateZitizenship" runat="server" Text="Update Citizenship" Visible="false" OnClick="btnUpdateZitizenship_Click" />
                
                <asp:GridView ID="gvwCitizenship" DataSourceID="odsCitizenship" DataKeyNames="avr_id" AutoGenerateColumns="false" runat="server" OnRowCommand="gvwCitizenship_RowCommand">
                    <Columns>
                    <asp:TemplateField HeaderText="Citizenship">
                        <ItemTemplate>
                            <asp:Label ID="lblCitizenship" runat="server" Text='<%# Bind("avr_Citizenship") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                                                
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtSelect" runat="server" CausesValidation="false" 
                    CommandName="SelectRecord" Text="Select" CommandArgument='<%# Container.DataItemIndex %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                        
                    </Columns>
                </asp:GridView>
        <asp:ObjectDataSource ID="odsCitizenship" runat="server" SelectMethod="getAttendeeCitizenship" TypeName="Gama.Attendee">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="atn_id" Type="Int32" />
        </SelectParameters>
        </asp:ObjectDataSource>
                <asp:Button ID="btnSaveContinueVisaInfo" runat="server" Text="Save" OnClick="btnSaveContinueVisaInfo_Click" />
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel HeaderText="Complete Registration" ID="tbpComplete" runat="server">
            <ContentTemplate>
                <asp:Button ID="btnRegistrationComplete" runat="server" Text="Notify Agent" OnClick="btnRegistrationComplete_Click" />
            </ContentTemplate>
        </asp:TabPanel>

    </asp:TabContainer>
            
            
    </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
