<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="editamigos.aspx.cs" Inherits="W1T2B.editamigos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--HEAD - CABEÇALHO--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center text-primary">
        <h2>Editar Dados de Amigo</h2>
    </div>

    <div class="row" style="margin-top:15px">
        <div class="col-md-2">
            <label>ID:</label>
            <asp:TextBox ID="txtID" runat="server" MaxLength="100" CssClass="form-control"
                Enabled="false"></asp:TextBox>
        </div>
        <div class="col-md-10">
            <label>Nome:</label>
            <asp:RequiredFieldValidator ID="rfvNome" ControlToValidate="txtNome"
                ErrorMessage="*" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtNome" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="row" style="margin-top:15px">
        <div class="col-md-5">
            <label>Celular:</label>
            <asp:TextBox ID="txtCelular" runat="server" MaxLength="15" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-7">
            <label>E-mail:</label>
            <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <label>Cidade:</label>
            <asp:RequiredFieldValidator ID="rfvCidade" ControlToValidate="txtCidade"
                ErrorMessage="*" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtCidade" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="row" style="margin-top:15px">
        <div class="col-md-12 text-right">
            <asp:Button ID="btnAlterar" CssClass="btn btn-warning" runat="server" Text="Alterar" OnClick="btnAlterar_Click" />
        </div>
        <div class="col-md-12 text-right">
            <asp:Button ID="btnVoltar" CssClass="btn btn-primary" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
        </div>
 </div>

    <div class="row" style="margin-top:15px">
        <div class="col-md-12 text-right">
            <asp:Label ID="lblResultado" CssClass="text-danger" runat="server"></asp:Label>
        </div>
    </div>
    
    
</asp:Content>
