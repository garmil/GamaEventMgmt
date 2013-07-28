<%@ Page Title="" Language="C#" MasterPageFile="~/Gama.Master" AutoEventWireup="true" CodeBehind="ManageCustomers.aspx.cs" Inherits="GamaEventMgmt.GamaAdmin.ManageCustomers" %>

<%@ Register TagPrefix="obout" Namespace="Obout.Grid" Assembly="obout_Grid_NET" %>
<%@ Register TagPrefix="obout" Namespace="Obout.Interface" Assembly="obout_Interface" %>

<%@ Register TagPrefix="cc1" Namespace="Obout.Grid" Assembly="obout_Grid_NET, Version=7.0.9.0, Culture=neutral, PublicKeyToken=5ddc49d3b53e3f98" %>



<%@ Register TagPrefix="obout" Namespace="Obout.SuperForm" Assembly="obout_SuperForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <asp:ObjectDataSource ID="Gamauserdatasource" InsertMethod="CreateNewUser" runat="server" SelectMethod="GetAllUsers" TypeName="GamaEventMgmt.ApplicationClasses.GamaUserAccessor" UpdateMethod="UpdateGamaUser">
                
                <UpdateParameters>
                    <asp:Parameter Name="UsertypeId" Type="Int32" />
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="Surname" Type="String" />
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="IsActive" Type="Boolean" />
                    <asp:Parameter Name="Id" Type="Boolean" />
    
                </UpdateParameters>

                <InsertParameters>
                 <asp:Parameter Name="UsertypeId" Type="Int32" />
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="Surname" Type="String" />
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="IsActive" Type="Boolean" />
                </InsertParameters>

            </asp:ObjectDataSource>



            <asp:ObjectDataSource ID="gamaform" runat="server" SelectMethod="GetById" TypeName="GamaEventMgmt.ApplicationClasses.GamaUserAccessor" UpdateMethod="UpdateGamaUser">
                <UpdateParameters>
                    <asp:Parameter Name="usertypeId" Type="Int32" />
                    <asp:Parameter Name="name" Type="String" />
                    <asp:Parameter Name="surname" Type="String" />
                    <asp:Parameter Name="email" Type="String" />
                    <asp:Parameter Name="isActive" Type="Boolean" />
                    <asp:Parameter Name="id" Type="Int32" />
                </UpdateParameters>

                <SelectParameters>
                    <asp:Parameter Name="Id" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>

            <div id="boutgrid">

                <obout:Grid ID="Grid1" runat="server" DataSourceID="Gamauserdatasource" AutoGenerateColumns="False">
                    <Columns>
                        <cc1:Column AllowEdit="True" AllowDelete="True"></cc1:Column>
                        <cc1:Column DataField="UsertypeId" Visible="False" HeaderText="User Type" Index="1">
                            <TemplateSettings RowEditTemplateControlId="SuperForm1_UsertypeId" RowEditTemplateControlPropertyName="value"></TemplateSettings>
                        </cc1:Column>
                        <cc1:Column DataField="UserType" HeaderText="User Type" Index="6">
            
                        </cc1:Column>
                        <cc1:Column DataField="Name" HeaderText="Name" Index="2">
                            <TemplateSettings RowEditTemplateControlId="SuperForm1_Name" RowEditTemplateControlPropertyName="value"></TemplateSettings>
                        </cc1:Column>
                        <cc1:Column DataField="Surname" HeaderText="Surname" Index="3">
                            <TemplateSettings RowEditTemplateControlId="SuperForm1_Surname" RowEditTemplateControlPropertyName="value"></TemplateSettings>
                        </cc1:Column>
                        <cc1:Column DataField="Email" HeaderText="Email" Index="4">
                            <TemplateSettings RowEditTemplateControlId="SuperForm1_Email" RowEditTemplateControlPropertyName="value"></TemplateSettings>
                        </cc1:Column>
                        <cc1:Column DataField="IsActive" HeaderText="IsActive" Index="5">
                            <TemplateSettings RowEditTemplateControlId="SuperForm1_IsActive" RowEditTemplateControlPropertyName="checked"></TemplateSettings>
                        </cc1:Column>


                    </Columns>
                    <AddEditDeleteSettings NewRecordPosition="Top"></AddEditDeleteSettings>
                    <TemplateSettings RowEditTemplateId="tplRowEdit" />

                    <Templates>
                        <obout:GridTemplate runat="server" ID="tplRowEdit">
                            <Template>
                                <input type="hidden" id="Id" />
                                <obout:SuperForm runat="server"
                                    DataSourceID="gamaform"
                                    AutoGenerateRows="false"
                                    AutoGenerateInsertButton="false"
                                    AutoGenerateEditButton="false"
                                    AutoGenerateDeleteButton="false"
                                    DefaultMode="Insert" Width="99%"
                                    DataKeyNames="Id">
                                    <Fields>

                                        <obout:DropDownListField DataField="UsertypeId" HeaderText="User Type" FieldSetID="FieldSet1" DataSourceID="fillUsertypes" DataTextField="GamaTypeName" DataValueField="Id"></obout:DropDownListField>
                                        <obout:BoundField DataField="Name" HeaderText="Name" FieldSetID="FieldSet1">
                                        </obout:BoundField>
                                        <obout:BoundField DataField="Surname" HeaderText="Surname" FieldSetID="FieldSet1">
                                        </obout:BoundField>
                                        <obout:BoundField DataField="Email" HeaderText="Email" FieldSetID="FieldSet1">
                                        </obout:BoundField>
                                        <obout:CheckBoxField DataField="IsActive" HeaderText="Is Active" FieldSetID="FieldSet1" />

                                        <obout:TemplateField FieldSetID="FieldSet4">
                                            <EditItemTemplate>
                                                <obout:OboutButton ID="OboutButton1" runat="server" Text="Save" OnClientClick="Grid1.save(); return false;" Width="75" />
                                                <obout:OboutButton ID="OboutButton2" runat="server" Text="Cancel" OnClientClick="Grid1.cancel(); return false;" Width="75" />
                                            </EditItemTemplate>
                                        </obout:TemplateField>
                                    </Fields>
                                    <FieldSets>
                                        <obout:FieldSetRow>
                                            <obout:FieldSet ID="FieldSet1" Title="User Information" />
                                        </obout:FieldSetRow>
                                        <obout:FieldSetRow>
                                            <obout:FieldSet ID="FieldSet4" ColumnSpan="3" CssClass="command-row" />
                                        </obout:FieldSetRow>
                                    </FieldSets>
                                    <CommandRowStyle HorizontalAlign="Center" />
                                    <FieldHeaderStyle HorizontalAlign="Right" Width="100px" />
                                    <PagerStyle HorizontalAlign="Center" />
                                </obout:SuperForm>
                            </Template>
                        </obout:GridTemplate>
                    </Templates>
                </obout:Grid>



            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:ObjectDataSource ID="fillUsertypes" runat="server" SelectMethod="GetAllUserTypes" TypeName="GamaEventMgmt.ApplicationClasses.GamaUserAccessor"></asp:ObjectDataSource>
</asp:Content>
