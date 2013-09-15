<%@ Page Title="" Language="C#" MasterPageFile="~/Gama.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="GamaEventMgmt.Registration.Register" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    
    <script type="text/javascript" src="../Scripts/jquery-2.0.3.min.js"></script>
    
    

    <script type="text/javascript">
        function autoHide() {  //hide after 5 seconds   
            setTimeout(function () { document.getlementById('<%=dvSystemMessages.ClientID%>').style.display = 'none'; }, 5000);
        }
    </script>
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

    <%--<asp:Label ID="lblMultiReg" runat="server" Text="Performing multiple registrations?"></asp:Label>
    <asp:CheckBox ID="chkMultiReg" AutoPostBack="true" runat="server" Text="Yes" OnCheckedChanged="chkMultiReg_CheckedChanged" /><br />--%>

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

    <%--<asp:Label ID="lblRegEmailAddress" runat="server" Text="Email Address:"></asp:Label>&nbsp;
    <asp:TextBox ID="tbxRegistrantEmailAddress" runat="server"></asp:TextBox>--%>
     <asp:HiddenField ID="hdfCountryId" runat="server" />
    <asp:TabContainer ID="tbcRegistration" runat="server" ActiveTabIndex="1">
        <asp:TabPanel runat="server" HeaderText="Event" ID="tbpEventView">
            <HeaderTemplate><asp:Label ID="lblEventTabHeader" runat="server" Text="Event Info" ForeColor="Black" Font-Bold="True"></asp:Label></HeaderTemplate>
            <ContentTemplate>
                
                <asp:Button ID="btnRegisterForEvent" runat="server" Text="Click here to Register" OnClick="btnRegisterForEvent_Click" CssClass="registerButton" />
                <asp:Literal ID="ltrHTML" runat="server"></asp:Literal>
            </ContentTemplate>
        </asp:TabPanel>

        <asp:TabPanel runat="server" HeaderText="Business Information" ID="tbpBusInfo" >
            <ContentTemplate>
                <asp:Literal ID="ltrBusInfo" runat="server"></asp:Literal>
                <asp:CollapsiblePanelExtender ID="CollapsiblePanelExtender2" runat="server" CollapseControlID="pnlBusInfo" Collapsed="True" CollapsedText="Click for Busines Info" Enabled="True" ExpandControlID="pnlBusInfo" TargetControlID="pnlBus">
                </asp:CollapsiblePanelExtender>
                <asp:Panel ID="pnlBusInfo" runat="server" CssClass="cpHeader" HorizontalAlign="Left"><asp:Label ID="Label11" runat="server" Text="Business Info" ></asp:Label>&nbsp;<asp:Label ID="Label12" runat="server" Text="(Click to view)" Font-Size="Small" ForeColor="#3366CC"></asp:Label></asp:Panel>
                <asp:Panel ID="pnlBus" runat="server" CssClass="cpBody">    
            <table width="100%">
                <tr>
                    <td>Title (*)</td>
                    <td><asp:DropDownList ID="ddlTitle" runat="server">
                        <asp:ListItem Text="-Choose One-"></asp:ListItem>
                        <asp:ListItem Text="Mr" Value="Mr"></asp:ListItem>
                        <asp:ListItem Text="Ms" Value="Ms"></asp:ListItem>
                        <asp:ListItem Text="Mrs" Value="Mrs"></asp:ListItem>
                        <asp:ListItem Text="Dr" Value="Dr"></asp:ListItem>
                        <asp:ListItem Text="Prof" Value="Prof"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvTitle" ControlToValidate="ddlTitle" runat="server" ErrorMessage="Please select title" Display="None"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" TargetControlID="rfvTitle" runat="server" CssClass="customCalloutStyle" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/close.png" Enabled="True"></asp:ValidatorCalloutExtender>

                    </td>
                </tr>
                <tr>
                    <td>Last Name (*)</td>
                    <td><asp:TextBox ID="tbxLastName" runat="server"></asp:TextBox>                        
                        <asp:RequiredFieldValidator ID="rfvLastName" ControlToValidate="tbxLastName" runat="server" ErrorMessage="Please enter Last Name" Display="None"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" TargetControlID="rfvLastName" runat="server" CssClass="customCalloutStyle" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/close.png" Enabled="True"></asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td>First Name (*)</td>
                    <td><asp:TextBox ID="tbxFirstName" runat="server"></asp:TextBox></td>
                        <asp:RequiredFieldValidator ID="rfvFirstName" ControlToValidate="tbxFirstName" runat="server" ErrorMessage="Please enter First Name" Display="None"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" TargetControlID="rfvFirstName" runat="server" CssClass="customCalloutStyle" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/close.png" Enabled="True"></asp:ValidatorCalloutExtender>
                </tr>

                <tr>
                    <td>Middle Name</td>
                    <td><asp:TextBox ID="tbxMiddleName" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>Business Email Address(*)</td>
                    <td><asp:TextBox ID="tbxBusEmailAddress" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvBusEmailAddr" ControlToValidate="tbxBusEmailAddress" runat="server" ErrorMessage="Please enter Business Email Address" Display="None"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" TargetControlID="rfvBusEmailAddr" runat="server" CssClass="customCalloutStyle" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/close.png" Enabled="True"></asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td>Confirm Business Email Address (*)</td>
                    <td><asp:TextBox ID="tbxConfBusEmailAddress" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvConfBusEmailAddr" ControlToValidate="tbxConfBusEmailAddress" runat="server" ErrorMessage="Please confirm Business Email Address" Display="None"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" TargetControlID="rfvConfBusEmailAddr" runat="server" CssClass="customCalloutStyle" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/close.png" Enabled="True"></asp:ValidatorCalloutExtender>
                        <asp:CompareValidator ID="cmvBusEmail" runat="server" Display="None" ErrorMessage="Email addresses do not match" ControlToCompare="tbxBusEmailAddress" ControlToValidate="tbxConfBusEmailAddress"></asp:CompareValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender13" EnableViewState="False" TargetControlID="cmvBusEmail" runat="server" CssClass="customCalloutStyle" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/close.png" Enabled="True"></asp:ValidatorCalloutExtender>
                    </td>
                </tr>

                <tr>
                    <td>Legal Name as it appears exactly in Passport or ID (*)</td>
                    <td><asp:TextBox ID="tbxLegalName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvLegalName" ControlToValidate="tbxLegalName" runat="server" ErrorMessage="Please enter Legal Name" Display="None"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" TargetControlID="rfvLegalName" runat="server" CssClass="customCalloutStyle" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/close.png" Enabled="True"></asp:ValidatorCalloutExtender>
                    </td>
                </tr>

                <tr>
                    <td>Date of Birth (*) </td>
                    <td><asp:TextBox ID="tbxDateOfBirth" runat="server"></asp:TextBox>
                        <asp:CalendarExtender ID="cleDateOfBirth" TargetControlID="tbxDateOfBirth" runat="server" Format="yyyy/MM/dd" DefaultView="Years" Enabled="True"></asp:CalendarExtender>
                        <asp:RequiredFieldValidator ID="rfvDateofBirth" ControlToValidate="tbxDateOfBirth" runat="server" ErrorMessage="Please enter Date of Birth" Display="None"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" TargetControlID="rfvDateofBirth" runat="server" CssClass="customCalloutStyle" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/close.png" Enabled="True"></asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">If traveling internationally, please fill out the following information:</td>
                </tr>
                <tr>
                    <td>Passport Number</td>
                    <td>
                        <asp:TextBox ID="tbxPassportIdNum" runat="server"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="rfvPassportId" ControlToValidate="tbxPassportIdNum" runat="server" ErrorMessage="Please enter Passport / ID Number" Display="None"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" TargetControlID="rfvPassportId" runat="server" CssClass="customCalloutStyle" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/close.png" Enabled="True"></asp:ValidatorCalloutExtender>--%>
                        <asp:FilteredTextBoxExtender ID="ftePassportIdNum" TargetControlID="tbxPassportIdNum" FilterType="Numbers" runat="server" Enabled="True"></asp:FilteredTextBoxExtender>
                    </td>
                </tr>
                
                <tr>
                    <td>Issuing Country</td>
                    <td><asp:TextBox ID="tbxPlaceofIssue" runat="server"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="rfvPlaceofIssue" ControlToValidate="tbxPlaceofIssue" runat="server" ErrorMessage="Please enter Place of Issue" Display="None"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" TargetControlID="rfvPlaceofIssue" runat="server" CssClass="customCalloutStyle" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/close.png" Enabled="True"></asp:ValidatorCalloutExtender>--%>
                    </td>
                </tr>
                
            
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
                        <asp:DropDownList ID="ddlCountry" runat="server" DataSourceID="odsCountries" DataTextField="cnt_Name" DataValueField="cnt_id" AppendDataBoundItems="True" OnDataBound="ddlCountry_DataBound">
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
                        <asp:FilteredTextBoxExtender ID="fteBusPhone" TargetControlID="tbxBusPhone" FilterType="Numbers" runat="server" Enabled="True"></asp:FilteredTextBoxExtender>
                    </td>
                </tr>
                <tr>
                    <td>Business Fax </td>
                    <td><asp:TextBox ID="tbxBusFax" runat="server"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="fteBusFax" TargetControlID="tbxBusFax" FilterType="Numbers" runat="server" Enabled="True"></asp:FilteredTextBoxExtender>

                    </td>
                </tr>
                </table>
                <asp:Button ID="btnSaveNextAddBusInfo" runat="server" Text="Save and Continue" Visible="False" OnClick="btnSaveNextAddBusInfo_Click" OnClientClick="javascript:window.scrollTo(0,0);" /> 
                <asp:Button ID="btnUpdate" runat="server" Text="Update" Visible="False" OnClick="btnUpdate_Click" OnClientClick="javascript:window.scrollTo(0,0);" />
                <asp:Button ID="btnSaveNextBusInfo" runat="server" Text="Save" OnClick="btnSaveNextBusInfo_Click" OnClientClick="javascript:window.scrollTo(0,0);" />
            </asp:Panel>
            
                <asp:CollapsiblePanelExtender ID="CollapsiblePanelExtender3" runat="server" CollapseControlID="pnlPersInfo" Collapsed="True" CollapsedText="Click for Personal Info" Enabled="True" ExpandControlID="pnlPersInfo" TargetControlID="pnlPers">
                </asp:CollapsiblePanelExtender>
                <asp:Panel ID="pnlPersInfo" runat="server" CssClass="cpHeader" HorizontalAlign="Left"><asp:Label ID="Label13" runat="server" Text="Personal Info" ></asp:Label>&nbsp;<asp:Label ID="Label14" runat="server" Text="(Click to view)" Font-Size="Small" ForeColor="#3366CC"></asp:Label></asp:Panel>
                <asp:Panel ID="pnlPers" runat="server" CssClass="cpBody">
                    <table>
                    <tr>
                        <td>Home Phone Number</td>
                        <td><asp:TextBox ID="tbxHomePhoneNumber" runat="server"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="fteHomePhoneNumber" TargetControlID="tbxHomePhoneNumber" FilterType="Numbers" runat="server" Enabled="True"></asp:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>Cellular Phone Number</td>
                        <td><asp:TextBox ID="tbxCellPhone" runat="server"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="fteCellPhone" TargetControlID="tbxCellPhone" FilterType="Numbers" runat="server" Enabled="True"></asp:FilteredTextBoxExtender>
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
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender14" EnableViewState="False" TargetControlID="cmvEmailAddress" runat="server" CssClass="customCalloutStyle" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/close.png" Enabled="True"></asp:ValidatorCalloutExtender>

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
                <asp:Button ID="btnSaveContinuePersInfo" runat="server" Text="Save and Continue" OnClick="btnSaveContinuePersInfo_Click" OnClientClick="javascript:window.scrollTo(0,0);"/>  
            </asp:Panel>

            </ContentTemplate>
        </asp:TabPanel>

        <asp:TabPanel HeaderText="Additional Travellers" ID="tbpAdditionalTravellers" runat="server">
            <ContentTemplate>
                <asp:Literal ID="ltrAddTrav" runat="server"></asp:Literal>

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
                    <asp:TemplateField HeaderText="Last Name" SortExpression="aam_Surname">
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
                            <asp:TextBox ID="tbxEditEmail" CssClass="emailBox" runat="server" Text='<%# Bind("aam_Email") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="tbxNewEmail" CssClass="emailBox" runat="server"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("aam_Email") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False" HeaderText="Edit">
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
                <asp:Button ID="btnAdditionalTrav" runat="server" Text="Continue" OnClick="btnAdditionalTrav_Click" OnClientClick="javascript:window.scrollTo(0,0);" />
            </ContentTemplate>
        </asp:TabPanel>
        
        <asp:TabPanel HeaderText="Travel Details" ID="tbpCityAirportInfo" runat="server">
            <ContentTemplate>
                <asp:Literal ID="ltrTravDetails" runat="server"></asp:Literal>
                <asp:Panel ID="pnlAirportCity" ScrollBars="Horizontal" runat="server" Width="100%">
                    
        <asp:GridView ID="gvwCityAirport" runat="server"  AutoGenerateColumns="False" DataKeyNames="aec_id,atn_id,evt_id" ShowFooter="True" OnInit="gvwCityAirport_Init" OnRowCancelingEdit="gvwCityAirport_RowCancelingEdit" OnRowCommand="gvwCityAirport_RowCommand" OnRowDataBound="gvwCityAirport_RowDataBound" OnRowDeleting="gvwCityAirport_RowDeleting" OnRowEditing="gvwCityAirport_RowEditing" OnRowUpdating="gvwCityAirport_RowUpdating" OnPreRender="gvwCityAirport_PreRender">
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
                    
                    <asp:TextBox ID="tbxEditDepartAirport" runat="server"></asp:TextBox>
                    
                    <asp:AutoCompleteExtender runat="server" ID="aceEditAirport" TargetControlID="tbxEditDepartAirport" ServicePath="AutoCompleteDepartCity.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="2" CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ></asp:AutoCompleteExtender>
                    
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="tbxNewDepartAirport" runat="server"></asp:TextBox>
                    
                    <asp:AutoCompleteExtender runat="server" ID="aceNewDepartCity"  
                        TargetControlID="tbxNewDepartAirport" ServicePath="AutoCompleteDepartCity.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="2" 
                        CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ></asp:AutoCompleteExtender>
                    
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
                    <asp:DropDownList ID="ddlEditDeptTime" runat="server">
                        <asp:ListItem Value="00:00" Text="00:00"></asp:ListItem>
                        <asp:ListItem Value="00:15" Text="00:15"></asp:ListItem>
                        <asp:ListItem Value="00:30" Text="00:30"></asp:ListItem>
                        <asp:ListItem Value="00:45" Text="00:45"></asp:ListItem>
                        <asp:ListItem Value="01:00" Text="01:00"></asp:ListItem>
                        <asp:ListItem Value="01:15" Text="01:15"></asp:ListItem>
                        <asp:ListItem Value="01:30" Text="01:30"></asp:ListItem>
                        <asp:ListItem Value="01:45" Text="01:45"></asp:ListItem>
                        <asp:ListItem Value="02:00" Text="02:00"></asp:ListItem>
                        <asp:ListItem Value="02:15" Text="02:15"></asp:ListItem>
                        <asp:ListItem Value="02:30" Text="02:30"></asp:ListItem>
                        <asp:ListItem Value="02:45" Text="02:45"></asp:ListItem>
                        <asp:ListItem Value="03:00" Text="03:00"></asp:ListItem>
                        <asp:ListItem Value="03:15" Text="03:15"></asp:ListItem>
                        <asp:ListItem Value="03:30" Text="03:30"></asp:ListItem>
                        <asp:ListItem Value="03:45" Text="03:45"></asp:ListItem>
                        <asp:ListItem Value="04:00" Text="04:00"></asp:ListItem>
                        <asp:ListItem Value="04:15" Text="04:15"></asp:ListItem>
                        <asp:ListItem Value="04:30" Text="04:30"></asp:ListItem>
                        <asp:ListItem Value="04:45" Text="04:45"></asp:ListItem>
                        <asp:ListItem Value="05:00" Text="05:00"></asp:ListItem>
                        <asp:ListItem Value="05:15" Text="05:15"></asp:ListItem>
                        <asp:ListItem Value="05:30" Text="05:30"></asp:ListItem>
                        <asp:ListItem Value="05:45" Text="05:45"></asp:ListItem>
                        <asp:ListItem Value="06:00" Text="06:00"></asp:ListItem>
                        <asp:ListItem Value="06:15" Text="06:15"></asp:ListItem>
                        <asp:ListItem Value="06:30" Text="06:30"></asp:ListItem>
                        <asp:ListItem Value="06:45" Text="06:45"></asp:ListItem>
                        <asp:ListItem Value="07:00" Text="07:00"></asp:ListItem>
                        <asp:ListItem Value="07:15" Text="07:15"></asp:ListItem>
                        <asp:ListItem Value="07:30" Text="07:30"></asp:ListItem>
                        <asp:ListItem Value="07:45" Text="07:45"></asp:ListItem>
                        <asp:ListItem Value="08:00" Text="08:00"></asp:ListItem>
                        <asp:ListItem Value="08:15" Text="08:15"></asp:ListItem>
                        <asp:ListItem Value="08:30" Text="08:30"></asp:ListItem>
                        <asp:ListItem Value="08:45" Text="08:45"></asp:ListItem>
                        <asp:ListItem Value="09:00" Text="09:00"></asp:ListItem>
                        <asp:ListItem Value="09:15" Text="09:15"></asp:ListItem>
                        <asp:ListItem Value="09:30" Text="09:30"></asp:ListItem>
                        <asp:ListItem Value="09:45" Text="09:45"></asp:ListItem>
                        <asp:ListItem Value="10:00" Text="10:00"></asp:ListItem>
                        <asp:ListItem Value="10:15" Text="10:15"></asp:ListItem>
                        <asp:ListItem Value="10:30" Text="10:30"></asp:ListItem>
                        <asp:ListItem Value="10:45" Text="10:45"></asp:ListItem>
                        <asp:ListItem Value="11:00" Text="11:00"></asp:ListItem>
                        <asp:ListItem Value="11:15" Text="11:15"></asp:ListItem>
                        <asp:ListItem Value="11:30" Text="11:30"></asp:ListItem>
                        <asp:ListItem Value="11:45" Text="11:45"></asp:ListItem>
                        <asp:ListItem Value="12:00" Text="12:00"></asp:ListItem>
                        <asp:ListItem Value="12:15" Text="12:15"></asp:ListItem>
                        <asp:ListItem Value="12:30" Text="12:30"></asp:ListItem>
                        <asp:ListItem Value="12:45" Text="12:45"></asp:ListItem>
                        <asp:ListItem Value="13:00" Text="13:00"></asp:ListItem>
                        <asp:ListItem Value="13:15" Text="13:15"></asp:ListItem>
                        <asp:ListItem Value="13:30" Text="13:30"></asp:ListItem>
                        <asp:ListItem Value="13:45" Text="13:45"></asp:ListItem>
                        <asp:ListItem Value="14:00" Text="14:00"></asp:ListItem>
                        <asp:ListItem Value="14:15" Text="14:15"></asp:ListItem>
                        <asp:ListItem Value="14:30" Text="14:30"></asp:ListItem>
                        <asp:ListItem Value="14:45" Text="14:45"></asp:ListItem>
                        <asp:ListItem Value="15:00" Text="15:00"></asp:ListItem>
                        <asp:ListItem Value="15:15" Text="15:15"></asp:ListItem>
                        <asp:ListItem Value="15:30" Text="15:30"></asp:ListItem>
                        <asp:ListItem Value="15:45" Text="15:45"></asp:ListItem>
                        <asp:ListItem Value="16:00" Text="16:00"></asp:ListItem>
                        <asp:ListItem Value="16:15" Text="16:15"></asp:ListItem>
                        <asp:ListItem Value="16:30" Text="16:30"></asp:ListItem>
                        <asp:ListItem Value="16:45" Text="16:45"></asp:ListItem>
                        <asp:ListItem Value="17:00" Text="17:00"></asp:ListItem>
                        <asp:ListItem Value="17:15" Text="17:15"></asp:ListItem>
                        <asp:ListItem Value="17:30" Text="17:30"></asp:ListItem>
                        <asp:ListItem Value="17:45" Text="17:45"></asp:ListItem>
                        <asp:ListItem Value="18:00" Text="18:00"></asp:ListItem>
                        <asp:ListItem Value="18:15" Text="18:15"></asp:ListItem>
                        <asp:ListItem Value="18:30" Text="18:30"></asp:ListItem>
                        <asp:ListItem Value="18:45" Text="18:45"></asp:ListItem>
                        <asp:ListItem Value="19:00" Text="19:00"></asp:ListItem>
                        <asp:ListItem Value="19:15" Text="19:15"></asp:ListItem>
                        <asp:ListItem Value="19:30" Text="19:30"></asp:ListItem>
                        <asp:ListItem Value="19:45" Text="19:45"></asp:ListItem>
                        <asp:ListItem Value="20:00" Text="20:00"></asp:ListItem>
                        <asp:ListItem Value="20:15" Text="20:15"></asp:ListItem>
                        <asp:ListItem Value="20:30" Text="20:30"></asp:ListItem>
                        <asp:ListItem Value="20:45" Text="20:45"></asp:ListItem>
                        <asp:ListItem Value="21:00" Text="21:00"></asp:ListItem>
                        <asp:ListItem Value="21:15" Text="21:15"></asp:ListItem>
                        <asp:ListItem Value="21:30" Text="21:30"></asp:ListItem>
                        <asp:ListItem Value="21:45" Text="21:45"></asp:ListItem>
                        <asp:ListItem Value="22:00" Text="22:00"></asp:ListItem>
                        <asp:ListItem Value="22:15" Text="22:15"></asp:ListItem>
                        <asp:ListItem Value="22:30" Text="22:30"></asp:ListItem>
                        <asp:ListItem Value="22:45" Text="22:45"></asp:ListItem>
                        <asp:ListItem Value="23:00" Text="23:00"></asp:ListItem>
                        <asp:ListItem Value="23:15" Text="23:15"></asp:ListItem>
                        <asp:ListItem Value="23:30" Text="23:30"></asp:ListItem>
                        <asp:ListItem Value="23:45" Text="23:45"></asp:ListItem>
                    </asp:DropDownList>
                    
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="ddlNewDeptTime" runat="server">
                        <asp:ListItem Value="00:00" Text="00:00"></asp:ListItem>
                        <asp:ListItem Value="00:15" Text="00:15"></asp:ListItem>
                        <asp:ListItem Value="00:30" Text="00:30"></asp:ListItem>
                        <asp:ListItem Value="00:45" Text="00:45"></asp:ListItem>
                        <asp:ListItem Value="01:00" Text="01:00"></asp:ListItem>
                        <asp:ListItem Value="01:15" Text="01:15"></asp:ListItem>
                        <asp:ListItem Value="01:30" Text="01:30"></asp:ListItem>
                        <asp:ListItem Value="01:45" Text="01:45"></asp:ListItem>
                        <asp:ListItem Value="02:00" Text="02:00"></asp:ListItem>
                        <asp:ListItem Value="02:15" Text="02:15"></asp:ListItem>
                        <asp:ListItem Value="02:30" Text="02:30"></asp:ListItem>
                        <asp:ListItem Value="02:45" Text="02:45"></asp:ListItem>
                        <asp:ListItem Value="03:00" Text="03:00"></asp:ListItem>
                        <asp:ListItem Value="03:15" Text="03:15"></asp:ListItem>
                        <asp:ListItem Value="03:30" Text="03:30"></asp:ListItem>
                        <asp:ListItem Value="03:45" Text="03:45"></asp:ListItem>
                        <asp:ListItem Value="04:00" Text="04:00"></asp:ListItem>
                        <asp:ListItem Value="04:15" Text="04:15"></asp:ListItem>
                        <asp:ListItem Value="04:30" Text="04:30"></asp:ListItem>
                        <asp:ListItem Value="04:45" Text="04:45"></asp:ListItem>
                        <asp:ListItem Value="05:00" Text="05:00"></asp:ListItem>
                        <asp:ListItem Value="05:15" Text="05:15"></asp:ListItem>
                        <asp:ListItem Value="05:30" Text="05:30"></asp:ListItem>
                        <asp:ListItem Value="05:45" Text="05:45"></asp:ListItem>
                        <asp:ListItem Value="06:00" Text="06:00"></asp:ListItem>
                        <asp:ListItem Value="06:15" Text="06:15"></asp:ListItem>
                        <asp:ListItem Value="06:30" Text="06:30"></asp:ListItem>
                        <asp:ListItem Value="06:45" Text="06:45"></asp:ListItem>
                        <asp:ListItem Value="07:00" Text="07:00"></asp:ListItem>
                        <asp:ListItem Value="07:15" Text="07:15"></asp:ListItem>
                        <asp:ListItem Value="07:30" Text="07:30"></asp:ListItem>
                        <asp:ListItem Value="07:45" Text="07:45"></asp:ListItem>
                        <asp:ListItem Value="08:00" Text="08:00"></asp:ListItem>
                        <asp:ListItem Value="08:15" Text="08:15"></asp:ListItem>
                        <asp:ListItem Value="08:30" Text="08:30"></asp:ListItem>
                        <asp:ListItem Value="08:45" Text="08:45"></asp:ListItem>
                        <asp:ListItem Value="09:00" Text="09:00"></asp:ListItem>
                        <asp:ListItem Value="09:15" Text="09:15"></asp:ListItem>
                        <asp:ListItem Value="09:30" Text="09:30"></asp:ListItem>
                        <asp:ListItem Value="09:45" Text="09:45"></asp:ListItem>
                        <asp:ListItem Value="10:00" Text="10:00"></asp:ListItem>
                        <asp:ListItem Value="10:15" Text="10:15"></asp:ListItem>
                        <asp:ListItem Value="10:30" Text="10:30"></asp:ListItem>
                        <asp:ListItem Value="10:45" Text="10:45"></asp:ListItem>
                        <asp:ListItem Value="11:00" Text="11:00"></asp:ListItem>
                        <asp:ListItem Value="11:15" Text="11:15"></asp:ListItem>
                        <asp:ListItem Value="11:30" Text="11:30"></asp:ListItem>
                        <asp:ListItem Value="11:45" Text="11:45"></asp:ListItem>
                        <asp:ListItem Value="12:00" Text="12:00"></asp:ListItem>
                        <asp:ListItem Value="12:15" Text="12:15"></asp:ListItem>
                        <asp:ListItem Value="12:30" Text="12:30"></asp:ListItem>
                        <asp:ListItem Value="12:45" Text="12:45"></asp:ListItem>
                        <asp:ListItem Value="13:00" Text="13:00"></asp:ListItem>
                        <asp:ListItem Value="13:15" Text="13:15"></asp:ListItem>
                        <asp:ListItem Value="13:30" Text="13:30"></asp:ListItem>
                        <asp:ListItem Value="13:45" Text="13:45"></asp:ListItem>
                        <asp:ListItem Value="14:00" Text="14:00"></asp:ListItem>
                        <asp:ListItem Value="14:15" Text="14:15"></asp:ListItem>
                        <asp:ListItem Value="14:30" Text="14:30"></asp:ListItem>
                        <asp:ListItem Value="14:45" Text="14:45"></asp:ListItem>
                        <asp:ListItem Value="15:00" Text="15:00"></asp:ListItem>
                        <asp:ListItem Value="15:15" Text="15:15"></asp:ListItem>
                        <asp:ListItem Value="15:30" Text="15:30"></asp:ListItem>
                        <asp:ListItem Value="15:45" Text="15:45"></asp:ListItem>
                        <asp:ListItem Value="16:00" Text="16:00"></asp:ListItem>
                        <asp:ListItem Value="16:15" Text="16:15"></asp:ListItem>
                        <asp:ListItem Value="16:30" Text="16:30"></asp:ListItem>
                        <asp:ListItem Value="16:45" Text="16:45"></asp:ListItem>
                        <asp:ListItem Value="17:00" Text="17:00"></asp:ListItem>
                        <asp:ListItem Value="17:15" Text="17:15"></asp:ListItem>
                        <asp:ListItem Value="17:30" Text="17:30"></asp:ListItem>
                        <asp:ListItem Value="17:45" Text="17:45"></asp:ListItem>
                        <asp:ListItem Value="18:00" Text="18:00"></asp:ListItem>
                        <asp:ListItem Value="18:15" Text="18:15"></asp:ListItem>
                        <asp:ListItem Value="18:30" Text="18:30"></asp:ListItem>
                        <asp:ListItem Value="18:45" Text="18:45"></asp:ListItem>
                        <asp:ListItem Value="19:00" Text="19:00"></asp:ListItem>
                        <asp:ListItem Value="19:15" Text="19:15"></asp:ListItem>
                        <asp:ListItem Value="19:30" Text="19:30"></asp:ListItem>
                        <asp:ListItem Value="19:45" Text="19:45"></asp:ListItem>
                        <asp:ListItem Value="20:00" Text="20:00"></asp:ListItem>
                        <asp:ListItem Value="20:15" Text="20:15"></asp:ListItem>
                        <asp:ListItem Value="20:30" Text="20:30"></asp:ListItem>
                        <asp:ListItem Value="20:45" Text="20:45"></asp:ListItem>
                        <asp:ListItem Value="21:00" Text="21:00"></asp:ListItem>
                        <asp:ListItem Value="21:15" Text="21:15"></asp:ListItem>
                        <asp:ListItem Value="21:30" Text="21:30"></asp:ListItem>
                        <asp:ListItem Value="21:45" Text="21:45"></asp:ListItem>
                        <asp:ListItem Value="22:00" Text="22:00"></asp:ListItem>
                        <asp:ListItem Value="22:15" Text="22:15"></asp:ListItem>
                        <asp:ListItem Value="22:30" Text="22:30"></asp:ListItem>
                        <asp:ListItem Value="22:45" Text="22:45"></asp:ListItem>
                        <asp:ListItem Value="23:00" Text="23:00"></asp:ListItem>
                        <asp:ListItem Value="23:15" Text="23:15"></asp:ListItem>
                        <asp:ListItem Value="23:30" Text="23:30"></asp:ListItem>
                        <asp:ListItem Value="23:45" Text="23:45"></asp:ListItem>
                    </asp:DropDownList>
                    
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
                    <asp:DropDownList ID="ddlEditArrTime" runat="server">
                        <asp:ListItem Value="00:00" Text="00:00"></asp:ListItem>
                        <asp:ListItem Value="00:15" Text="00:15"></asp:ListItem>
                        <asp:ListItem Value="00:30" Text="00:30"></asp:ListItem>
                        <asp:ListItem Value="00:45" Text="00:45"></asp:ListItem>
                        <asp:ListItem Value="01:00" Text="01:00"></asp:ListItem>
                        <asp:ListItem Value="01:15" Text="01:15"></asp:ListItem>
                        <asp:ListItem Value="01:30" Text="01:30"></asp:ListItem>
                        <asp:ListItem Value="01:45" Text="01:45"></asp:ListItem>
                        <asp:ListItem Value="02:00" Text="02:00"></asp:ListItem>
                        <asp:ListItem Value="02:15" Text="02:15"></asp:ListItem>
                        <asp:ListItem Value="02:30" Text="02:30"></asp:ListItem>
                        <asp:ListItem Value="02:45" Text="02:45"></asp:ListItem>
                        <asp:ListItem Value="03:00" Text="03:00"></asp:ListItem>
                        <asp:ListItem Value="03:15" Text="03:15"></asp:ListItem>
                        <asp:ListItem Value="03:30" Text="03:30"></asp:ListItem>
                        <asp:ListItem Value="03:45" Text="03:45"></asp:ListItem>
                        <asp:ListItem Value="04:00" Text="04:00"></asp:ListItem>
                        <asp:ListItem Value="04:15" Text="04:15"></asp:ListItem>
                        <asp:ListItem Value="04:30" Text="04:30"></asp:ListItem>
                        <asp:ListItem Value="04:45" Text="04:45"></asp:ListItem>
                        <asp:ListItem Value="05:00" Text="05:00"></asp:ListItem>
                        <asp:ListItem Value="05:15" Text="05:15"></asp:ListItem>
                        <asp:ListItem Value="05:30" Text="05:30"></asp:ListItem>
                        <asp:ListItem Value="05:45" Text="05:45"></asp:ListItem>
                        <asp:ListItem Value="06:00" Text="06:00"></asp:ListItem>
                        <asp:ListItem Value="06:15" Text="06:15"></asp:ListItem>
                        <asp:ListItem Value="06:30" Text="06:30"></asp:ListItem>
                        <asp:ListItem Value="06:45" Text="06:45"></asp:ListItem>
                        <asp:ListItem Value="07:00" Text="07:00"></asp:ListItem>
                        <asp:ListItem Value="07:15" Text="07:15"></asp:ListItem>
                        <asp:ListItem Value="07:30" Text="07:30"></asp:ListItem>
                        <asp:ListItem Value="07:45" Text="07:45"></asp:ListItem>
                        <asp:ListItem Value="08:00" Text="08:00"></asp:ListItem>
                        <asp:ListItem Value="08:15" Text="08:15"></asp:ListItem>
                        <asp:ListItem Value="08:30" Text="08:30"></asp:ListItem>
                        <asp:ListItem Value="08:45" Text="08:45"></asp:ListItem>
                        <asp:ListItem Value="09:00" Text="09:00"></asp:ListItem>
                        <asp:ListItem Value="09:15" Text="09:15"></asp:ListItem>
                        <asp:ListItem Value="09:30" Text="09:30"></asp:ListItem>
                        <asp:ListItem Value="09:45" Text="09:45"></asp:ListItem>
                        <asp:ListItem Value="10:00" Text="10:00"></asp:ListItem>
                        <asp:ListItem Value="10:15" Text="10:15"></asp:ListItem>
                        <asp:ListItem Value="10:30" Text="10:30"></asp:ListItem>
                        <asp:ListItem Value="10:45" Text="10:45"></asp:ListItem>
                        <asp:ListItem Value="11:00" Text="11:00"></asp:ListItem>
                        <asp:ListItem Value="11:15" Text="11:15"></asp:ListItem>
                        <asp:ListItem Value="11:30" Text="11:30"></asp:ListItem>
                        <asp:ListItem Value="11:45" Text="11:45"></asp:ListItem>
                        <asp:ListItem Value="12:00" Text="12:00"></asp:ListItem>
                        <asp:ListItem Value="12:15" Text="12:15"></asp:ListItem>
                        <asp:ListItem Value="12:30" Text="12:30"></asp:ListItem>
                        <asp:ListItem Value="12:45" Text="12:45"></asp:ListItem>
                        <asp:ListItem Value="13:00" Text="13:00"></asp:ListItem>
                        <asp:ListItem Value="13:15" Text="13:15"></asp:ListItem>
                        <asp:ListItem Value="13:30" Text="13:30"></asp:ListItem>
                        <asp:ListItem Value="13:45" Text="13:45"></asp:ListItem>
                        <asp:ListItem Value="14:00" Text="14:00"></asp:ListItem>
                        <asp:ListItem Value="14:15" Text="14:15"></asp:ListItem>
                        <asp:ListItem Value="14:30" Text="14:30"></asp:ListItem>
                        <asp:ListItem Value="14:45" Text="14:45"></asp:ListItem>
                        <asp:ListItem Value="15:00" Text="15:00"></asp:ListItem>
                        <asp:ListItem Value="15:15" Text="15:15"></asp:ListItem>
                        <asp:ListItem Value="15:30" Text="15:30"></asp:ListItem>
                        <asp:ListItem Value="15:45" Text="15:45"></asp:ListItem>
                        <asp:ListItem Value="16:00" Text="16:00"></asp:ListItem>
                        <asp:ListItem Value="16:15" Text="16:15"></asp:ListItem>
                        <asp:ListItem Value="16:30" Text="16:30"></asp:ListItem>
                        <asp:ListItem Value="16:45" Text="16:45"></asp:ListItem>
                        <asp:ListItem Value="17:00" Text="17:00"></asp:ListItem>
                        <asp:ListItem Value="17:15" Text="17:15"></asp:ListItem>
                        <asp:ListItem Value="17:30" Text="17:30"></asp:ListItem>
                        <asp:ListItem Value="17:45" Text="17:45"></asp:ListItem>
                        <asp:ListItem Value="18:00" Text="18:00"></asp:ListItem>
                        <asp:ListItem Value="18:15" Text="18:15"></asp:ListItem>
                        <asp:ListItem Value="18:30" Text="18:30"></asp:ListItem>
                        <asp:ListItem Value="18:45" Text="18:45"></asp:ListItem>
                        <asp:ListItem Value="19:00" Text="19:00"></asp:ListItem>
                        <asp:ListItem Value="19:15" Text="19:15"></asp:ListItem>
                        <asp:ListItem Value="19:30" Text="19:30"></asp:ListItem>
                        <asp:ListItem Value="19:45" Text="19:45"></asp:ListItem>
                        <asp:ListItem Value="20:00" Text="20:00"></asp:ListItem>
                        <asp:ListItem Value="20:15" Text="20:15"></asp:ListItem>
                        <asp:ListItem Value="20:30" Text="20:30"></asp:ListItem>
                        <asp:ListItem Value="20:45" Text="20:45"></asp:ListItem>
                        <asp:ListItem Value="21:00" Text="21:00"></asp:ListItem>
                        <asp:ListItem Value="21:15" Text="21:15"></asp:ListItem>
                        <asp:ListItem Value="21:30" Text="21:30"></asp:ListItem>
                        <asp:ListItem Value="21:45" Text="21:45"></asp:ListItem>
                        <asp:ListItem Value="22:00" Text="22:00"></asp:ListItem>
                        <asp:ListItem Value="22:15" Text="22:15"></asp:ListItem>
                        <asp:ListItem Value="22:30" Text="22:30"></asp:ListItem>
                        <asp:ListItem Value="22:45" Text="22:45"></asp:ListItem>
                        <asp:ListItem Value="23:00" Text="23:00"></asp:ListItem>
                        <asp:ListItem Value="23:15" Text="23:15"></asp:ListItem>
                        <asp:ListItem Value="23:30" Text="23:30"></asp:ListItem>
                        <asp:ListItem Value="23:45" Text="23:45"></asp:ListItem>
                    </asp:DropDownList>
                    
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="ddlNewArrTime" runat="server">
                        <asp:ListItem Value="00:00" Text="00:00"></asp:ListItem>
                        <asp:ListItem Value="00:15" Text="00:15"></asp:ListItem>
                        <asp:ListItem Value="00:30" Text="00:30"></asp:ListItem>
                        <asp:ListItem Value="00:45" Text="00:45"></asp:ListItem>
                        <asp:ListItem Value="01:00" Text="01:00"></asp:ListItem>
                        <asp:ListItem Value="01:15" Text="01:15"></asp:ListItem>
                        <asp:ListItem Value="01:30" Text="01:30"></asp:ListItem>
                        <asp:ListItem Value="01:45" Text="01:45"></asp:ListItem>
                        <asp:ListItem Value="02:00" Text="02:00"></asp:ListItem>
                        <asp:ListItem Value="02:15" Text="02:15"></asp:ListItem>
                        <asp:ListItem Value="02:30" Text="02:30"></asp:ListItem>
                        <asp:ListItem Value="02:45" Text="02:45"></asp:ListItem>
                        <asp:ListItem Value="03:00" Text="03:00"></asp:ListItem>
                        <asp:ListItem Value="03:15" Text="03:15"></asp:ListItem>
                        <asp:ListItem Value="03:30" Text="03:30"></asp:ListItem>
                        <asp:ListItem Value="03:45" Text="03:45"></asp:ListItem>
                        <asp:ListItem Value="04:00" Text="04:00"></asp:ListItem>
                        <asp:ListItem Value="04:15" Text="04:15"></asp:ListItem>
                        <asp:ListItem Value="04:30" Text="04:30"></asp:ListItem>
                        <asp:ListItem Value="04:45" Text="04:45"></asp:ListItem>
                        <asp:ListItem Value="05:00" Text="05:00"></asp:ListItem>
                        <asp:ListItem Value="05:15" Text="05:15"></asp:ListItem>
                        <asp:ListItem Value="05:30" Text="05:30"></asp:ListItem>
                        <asp:ListItem Value="05:45" Text="05:45"></asp:ListItem>
                        <asp:ListItem Value="06:00" Text="06:00"></asp:ListItem>
                        <asp:ListItem Value="06:15" Text="06:15"></asp:ListItem>
                        <asp:ListItem Value="06:30" Text="06:30"></asp:ListItem>
                        <asp:ListItem Value="06:45" Text="06:45"></asp:ListItem>
                        <asp:ListItem Value="07:00" Text="07:00"></asp:ListItem>
                        <asp:ListItem Value="07:15" Text="07:15"></asp:ListItem>
                        <asp:ListItem Value="07:30" Text="07:30"></asp:ListItem>
                        <asp:ListItem Value="07:45" Text="07:45"></asp:ListItem>
                        <asp:ListItem Value="08:00" Text="08:00"></asp:ListItem>
                        <asp:ListItem Value="08:15" Text="08:15"></asp:ListItem>
                        <asp:ListItem Value="08:30" Text="08:30"></asp:ListItem>
                        <asp:ListItem Value="08:45" Text="08:45"></asp:ListItem>
                        <asp:ListItem Value="09:00" Text="09:00"></asp:ListItem>
                        <asp:ListItem Value="09:15" Text="09:15"></asp:ListItem>
                        <asp:ListItem Value="09:30" Text="09:30"></asp:ListItem>
                        <asp:ListItem Value="09:45" Text="09:45"></asp:ListItem>
                        <asp:ListItem Value="10:00" Text="10:00"></asp:ListItem>
                        <asp:ListItem Value="10:15" Text="10:15"></asp:ListItem>
                        <asp:ListItem Value="10:30" Text="10:30"></asp:ListItem>
                        <asp:ListItem Value="10:45" Text="10:45"></asp:ListItem>
                        <asp:ListItem Value="11:00" Text="11:00"></asp:ListItem>
                        <asp:ListItem Value="11:15" Text="11:15"></asp:ListItem>
                        <asp:ListItem Value="11:30" Text="11:30"></asp:ListItem>
                        <asp:ListItem Value="11:45" Text="11:45"></asp:ListItem>
                        <asp:ListItem Value="12:00" Text="12:00"></asp:ListItem>
                        <asp:ListItem Value="12:15" Text="12:15"></asp:ListItem>
                        <asp:ListItem Value="12:30" Text="12:30"></asp:ListItem>
                        <asp:ListItem Value="12:45" Text="12:45"></asp:ListItem>
                        <asp:ListItem Value="13:00" Text="13:00"></asp:ListItem>
                        <asp:ListItem Value="13:15" Text="13:15"></asp:ListItem>
                        <asp:ListItem Value="13:30" Text="13:30"></asp:ListItem>
                        <asp:ListItem Value="13:45" Text="13:45"></asp:ListItem>
                        <asp:ListItem Value="14:00" Text="14:00"></asp:ListItem>
                        <asp:ListItem Value="14:15" Text="14:15"></asp:ListItem>
                        <asp:ListItem Value="14:30" Text="14:30"></asp:ListItem>
                        <asp:ListItem Value="14:45" Text="14:45"></asp:ListItem>
                        <asp:ListItem Value="15:00" Text="15:00"></asp:ListItem>
                        <asp:ListItem Value="15:15" Text="15:15"></asp:ListItem>
                        <asp:ListItem Value="15:30" Text="15:30"></asp:ListItem>
                        <asp:ListItem Value="15:45" Text="15:45"></asp:ListItem>
                        <asp:ListItem Value="16:00" Text="16:00"></asp:ListItem>
                        <asp:ListItem Value="16:15" Text="16:15"></asp:ListItem>
                        <asp:ListItem Value="16:30" Text="16:30"></asp:ListItem>
                        <asp:ListItem Value="16:45" Text="16:45"></asp:ListItem>
                        <asp:ListItem Value="17:00" Text="17:00"></asp:ListItem>
                        <asp:ListItem Value="17:15" Text="17:15"></asp:ListItem>
                        <asp:ListItem Value="17:30" Text="17:30"></asp:ListItem>
                        <asp:ListItem Value="17:45" Text="17:45"></asp:ListItem>
                        <asp:ListItem Value="18:00" Text="18:00"></asp:ListItem>
                        <asp:ListItem Value="18:15" Text="18:15"></asp:ListItem>
                        <asp:ListItem Value="18:30" Text="18:30"></asp:ListItem>
                        <asp:ListItem Value="18:45" Text="18:45"></asp:ListItem>
                        <asp:ListItem Value="19:00" Text="19:00"></asp:ListItem>
                        <asp:ListItem Value="19:15" Text="19:15"></asp:ListItem>
                        <asp:ListItem Value="19:30" Text="19:30"></asp:ListItem>
                        <asp:ListItem Value="19:45" Text="19:45"></asp:ListItem>
                        <asp:ListItem Value="20:00" Text="20:00"></asp:ListItem>
                        <asp:ListItem Value="20:15" Text="20:15"></asp:ListItem>
                        <asp:ListItem Value="20:30" Text="20:30"></asp:ListItem>
                        <asp:ListItem Value="20:45" Text="20:45"></asp:ListItem>
                        <asp:ListItem Value="21:00" Text="21:00"></asp:ListItem>
                        <asp:ListItem Value="21:15" Text="21:15"></asp:ListItem>
                        <asp:ListItem Value="21:30" Text="21:30"></asp:ListItem>
                        <asp:ListItem Value="21:45" Text="21:45"></asp:ListItem>
                        <asp:ListItem Value="22:00" Text="22:00"></asp:ListItem>
                        <asp:ListItem Value="22:15" Text="22:15"></asp:ListItem>
                        <asp:ListItem Value="22:30" Text="22:30"></asp:ListItem>
                        <asp:ListItem Value="22:45" Text="22:45"></asp:ListItem>
                        <asp:ListItem Value="23:00" Text="23:00"></asp:ListItem>
                        <asp:ListItem Value="23:15" Text="23:15"></asp:ListItem>
                        <asp:ListItem Value="23:30" Text="23:30"></asp:ListItem>
                        <asp:ListItem Value="23:45" Text="23:45"></asp:ListItem>
                    </asp:DropDownList>
                    
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblArrTime" runat="server" Text='<%# Bind("aec_ArrivalTime") %>'></asp:Label>
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
                </asp:Panel>
                <asp:Button ID="btnSaveContinueAirportCity" runat="server" Text="Continue" OnClick="btnSaveContinueAirportCity_Click" OnClientClick="javascript:window.scrollTo(0,0);" />
            </ContentTemplate>
        </asp:TabPanel>
        
        <asp:TabPanel HeaderText="Preferences" ID="tbpPreferences" runat="server">
            <ContentTemplate>
                <asp:Literal ID="ltrPrefs" runat="server"></asp:Literal>
                <asp:CollapsiblePanelExtender ID="cpePreferredAirline" runat="server" CollapseControlID="pnlPrefInfo" Collapsed="True" CollapsedText="Click for Preferred Airline / Flight" Enabled="True" ExpandControlID="pnlPrefInfo" TargetControlID="pnlPrefAirlineInfo">
                </asp:CollapsiblePanelExtender>
                <asp:Panel ID="pnlPrefInfo" runat="server" CssClass="cpHeader" HorizontalAlign="Left"><asp:Label ID="Label7" runat="server" Text="Airline Preferences" ></asp:Label>&nbsp;<asp:Label ID="Label8" runat="server" Text="(Click to view)" Font-Size="Small" ForeColor="#3366CC"></asp:Label></asp:Panel>
                <asp:Panel ID="pnlPrefAirlineInfo" runat="server" CssClass="cpBody">
                    <asp:GridView ID="gvwPreferredAirline" runat="server" AutoGenerateColumns="False" DataKeyNames="apa_id,aln_id" ShowFooter="True" OnDataBound="gvwPreferredAirline_DataBound" OnRowCancelingEdit="gvwPreferredAirline_RowCancelingEdit" OnRowCommand="gvwPreferredAirline_RowCommand" OnRowDataBound="gvwPreferredAirline_RowDataBound" OnRowDeleting="gvwPreferredAirline_RowDeleting" OnRowEditing="gvwPreferredAirline_RowEditing" OnRowUpdating="gvwPreferredAirline_RowUpdating">
                    <Columns>
                        <asp:TemplateField HeaderText="Attendee" SortExpression="attName">
                            <EditItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("attName") %>'></asp:Label>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("attName") %>'></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblAttendee" runat="server" Text='<%# Bind("attName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Airline" SortExpression="aln_Airline">
                            <EditItemTemplate>
                                <asp:TextBox ID="tbxEditAirline" runat="server"></asp:TextBox>
                                <asp:AutoCompleteExtender runat="server" ID="aceNewPrefAirline" TargetControlID="tbxEditAirline" ServicePath="AutoCompleteService.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="2" CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ></asp:AutoCompleteExtender>
                                
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:HiddenField ID="hdfAirlineID" runat="server" />
                                <asp:TextBox ID="tbxNewAirline" runat="server"></asp:TextBox>
                                <asp:AutoCompleteExtender runat="server" ID="aceEditPrefAirline" TargetControlID="tbxNewAirline" ServicePath="AutoCompleteService.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="2" CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ></asp:AutoCompleteExtender>
                                
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("aln_Airline") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Flight Num" SortExpression="apa_FlightNum">
                            <EditItemTemplate>
                                <asp:TextBox ID="tbxEditFlightNum" runat="server" Text='<%# Bind("apa_FlightNum") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="tbxNewFlightNum" runat="server"></asp:TextBox>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("apa_FlightNum") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:LinkButton ID="lbtAddNew" runat="server" CommandName="AddNew">Add New</asp:LinkButton>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ShowHeader="True" />
                    </Columns>
                </asp:GridView>

                </asp:Panel>

                <asp:CollapsiblePanelExtender ID="cpeMealInfo" runat="server" CollapseControlID="pnlMealInformation" Collapsed="True" CollapsedText="Click for Meal Info" Enabled="True" ExpandControlID="pnlMealInformation" TargetControlID="pnlMealInfo">
                </asp:CollapsiblePanelExtender>
                <asp:Panel ID="pnlMealInformation" runat="server" CssClass="cpHeader" HorizontalAlign="Left"><asp:Label ID="lblMealInfo" runat="server" Text="Meal Info" ></asp:Label>&nbsp;<asp:Label ID="lblClickToView" runat="server" Text="(Click to view)" Font-Size="Small" ForeColor="#3366CC"></asp:Label></asp:Panel>
                <asp:Panel ID="pnlMealInfo" runat="server" CssClass="cpBody">
        
    
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
                    <td><asp:Button ID="btnSaveMealReq" runat="server" Text="Save Meal Requirement" OnClick="btnSaveMealReq_Click" OnClientClick="javascript:window.scrollTo(0,0);"/></td>
                </tr>
            </table>
            <asp:ObjectDataSource ID="odsMealReqs" runat="server" SelectMethod="getAllMealRequirements" TypeName="Gama.Attendee"></asp:ObjectDataSource>
        </asp:Panel>
                
                

                <asp:CollapsiblePanelExtender ID="cpeAirlineMembership" runat="server" CollapseControlID="pnlAirlineMemInfo" Collapsed="True" CollapsedText="Click for Airline Membership" Enabled="True" ExpandControlID="pnlAirlineMemInfo" TargetControlID="pnlAirlineMembership">
                </asp:CollapsiblePanelExtender>
                <asp:Panel ID="pnlAirlineMemInfo" runat="server" CssClass="cpHeader" HorizontalAlign="Left"><asp:Label ID="Label5" runat="server" Text="Airline Membership" ></asp:Label>&nbsp;<asp:Label ID="Label6" runat="server" Text="(Click to view)" Font-Size="Small" ForeColor="#3366CC"></asp:Label></asp:Panel>
                <asp:Panel ID="pnlAirlineMembership" runat="server" CssClass="cpBody">
                    <asp:HiddenField ID="hdf_alm_id" runat="server" />
               
                    <asp:GridView ID="gvwAirlineMembership" AutoGenerateColumns="False" ShowFooter="True" runat="server" DataKeyNames="alm_id,atn_id" OnRowCancelingEdit="gvwAirlineMembership_RowCancelingEdit" OnRowCommand="gvwAirlineMembership_RowCommand" OnRowDeleting="gvwAirlineMembership_RowDeleting" OnRowEditing="gvwAirlineMembership_RowEditing" OnRowUpdating="gvwAirlineMembership_RowUpdating">
                        <Columns>
                            <asp:TemplateField HeaderText="Attendee" SortExpression="AttName">
                                <EditItemTemplate>
                                    <asp:Label ID="lblEditAttendee" runat="server" Text='<%# Bind("AttName") %>'></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblNewAttendee" runat="server" Text='<%# Bind("AttName") %>'></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblAttendee" runat="server" Text='<%# Bind("AttName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Airline" SortExpression="aln_Airline">
                                <EditItemTemplate>
                                    <asp:TextBox ID="tbxEditMemberAirline" runat="server" Text='<%# Bind("aam_AirlineName_Code") %>'></asp:TextBox>
                                    <asp:AutoCompleteExtender runat="server" ID="aceEditMemAirline" TargetControlID="tbxEditMemberAirline" ServicePath="AutoCompleteService.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="2" CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ></asp:AutoCompleteExtender>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="tbxNewMemberAirline" runat="server"></asp:TextBox>
                                    <asp:AutoCompleteExtender runat="server" ID="aceNewMemAirline" TargetControlID="tbxNewMemberAirline" ServicePath="AutoCompleteService.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="2" CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ></asp:AutoCompleteExtender>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblAirline" runat="server" Text='<%# Bind("aam_AirlineName_Code") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Airline Membership No" SortExpression="aam_MembershipNumber">
                                <EditItemTemplate>
                                    <asp:TextBox ID="tbxEditAirlineMem" runat="server" Text='<%# Bind("aam_MembershipNumber") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="tbxNewAirlineMem" runat="server"></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblAirlineMemNumber" runat="server" Text='<%# Bind("aam_MembershipNumber") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="lbtAddNew" runat="server" CommandName="AddNew">Add New</asp:LinkButton>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ShowHeader="True" />
                        </Columns>
                        
                    </asp:GridView>
                    
                    

                </asp:Panel>
                
                
                
                <asp:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" CollapseControlID="pnlGenInfo" Collapsed="True" CollapsedText="Click for Preferred Airline / Fligh" Enabled="True" ExpandControlID="pnlGenInfo" TargetControlID="pnlGeneralReqInfo">
                </asp:CollapsiblePanelExtender>
                <asp:Panel ID="pnlGenInfo" runat="server" CssClass="cpHeader" HorizontalAlign="Left"><asp:Label ID="Label9" runat="server" Text="General Requirements" ></asp:Label>&nbsp;<asp:Label ID="Label10" runat="server" Text="(Click to view)" Font-Size="Small" ForeColor="#3366CC"></asp:Label></asp:Panel>
                <asp:Panel ID="pnlGeneralReqInfo" runat="server" CssClass="cpBody">
                    <table>
                    <tr>
                        <td>Class of Service</td>
                        <td><asp:DropDownList ID="ddlClassOfService" runat="server">
                            <asp:ListItem Text="-Select Service-"></asp:ListItem>
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
                <asp:Button ID="btnSaveContinueGenReqs" runat="server" Text="Save and Continue" OnClick="btnSaveContinueGenReqs_Click" OnClientClick="javascript:window.scrollTo(0,0);" />
                </asp:Panel>
                
                <asp:Button ID="btnPreferencesContinue" runat="server" Text="Continue" OnClick="btnPreferencesContinue_Click"  />

            </ContentTemplate>
        </asp:TabPanel>

        <asp:TabPanel HeaderText="Visa Information" ID="tbpVisaInfo" runat="server">
            <ContentTemplate>
                <asp:Literal ID="ltrVisaInfo" runat="server"></asp:Literal>
                <asp:HiddenField ID="hdf_avr_id" runat="server" />
                <iframe src="visaCheck.html" width="100%" height="120px" frameborder="0"></iframe>
                    
                
                <table width="100%">
                    
                    <tr>
                        <td width="20%">Citizenship(s)</td>
                        <td><asp:ComboBox ID="cmbCitizenship" AutoCompleteMode="Suggest" runat="server" DataSourceID="odsCitizenshipCountries" DataTextField="cnt_Name" DataValueField="cnt_id"></asp:ComboBox>
                            <asp:ObjectDataSource ID="odsCitizenshipCountries" runat="server" SelectMethod="getAllCountriesAndRegions" TypeName="Gama.Country"></asp:ObjectDataSource>
                            <asp:Button ID="btnSaveCitizenship" CausesValidation="false" runat="server" Text="Save Citizenship" OnClick="btnSaveCitizenship_Click" />
                            <asp:Button ID="btnUpdateZitizenship" runat="server" Text="Update Citizenship" Visible="false" OnClick="btnUpdateZitizenship_Click" />
                        </td>
                    </tr>
                </table>
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

            <table width="100%">
                
                <tr>
                    <td width="20%"><asp:Label ID="lblCountryReqdVisa" runat="server" Text="Specify country for required visa:"></asp:Label></td>
                    <td><asp:ComboBox ID="cmbCountryReqdVisa" AutoCompleteMode="Suggest" runat="server" DataSourceID="odsCitizenshipCountries" DataTextField="cnt_Name" DataValueField="cnt_id"></asp:ComboBox>
                    <asp:Button ID="btnSaveContinueVisaInfo" runat="server" Text="Save" OnClick="btnSaveVisaReqd_Click" OnClientClick="javascript:window.scrollTo(0,0);"/></td>
                </tr>
            </table>    
            </ContentTemplate>
        </asp:TabPanel>
        
        <asp:TabPanel HeaderText="Shirt Size" ID="tbpShirtOrder" runat="server">
            <ContentTemplate>
                <asp:Literal ID="ltrShirtSize" runat="server"></asp:Literal>
                <table>
                    <tr>
                        <td>Shirt Size:</td>
                        <td>
                            <asp:DropDownList ID="ddlShirtSize" runat="server">
                                <asp:ListItem Value="Men SM" Text="Men SM"></asp:ListItem>
                                <asp:ListItem Value="Men L" Text="Men L"></asp:ListItem>
                                <asp:ListItem Value="Men LG" Text="Men LG"></asp:ListItem>
                                <asp:ListItem Value="Men XL" Text="Men XL"></asp:ListItem>
                                <asp:ListItem Value="Women SM" Text="Women SM"></asp:ListItem>
                                <asp:ListItem Value="Women L" Text="Women L"></asp:ListItem>
                                <asp:ListItem Value="Women LG" Text="Women LG"></asp:ListItem>
                                <asp:ListItem Value="Women XL" Text="Women XL"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Button ID="btnSaveShirtSize" runat="server" Text="Save Shirt Size" OnClick="btnSaveShirtSize_Click" /></td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
 
               <asp:Button ID="btnRegistrationComplete" runat="server" Text="Submit Registration" Visible="False" OnClick="btnRegistrationComplete_Click" />
        <asp:ObjectDataSource ID="odsCitizenship" runat="server" SelectMethod="getAttendeeCitizenship" TypeName="Gama.Attendee">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="" Name="atn_id" SessionField="atn_id" Type="Int32" />
        </SelectParameters>
        </asp:ObjectDataSource>
            
            <asp:ObjectDataSource ID="odsAirports" runat="server" SelectMethod="GetAllAirports" TypeName="Gama.AirportAirline"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="odsAirlines" runat="server" SelectMethod="GetAllAirlines" TypeName="Gama.AirportAirline"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="odsAirlineMemNumber" runat="server" SelectMethod="getAttendeeAirlineMembership" TypeName="Gama.Attendee">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="" Name="atn_id" SessionField="atn_id" Type="Int32" />
        </SelectParameters>
            </asp:ObjectDataSource>
    </ContentTemplate>
    </asp:UpdatePanel>
    
    

</asp:Content>
