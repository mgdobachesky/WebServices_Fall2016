<%@ Page Title="" Language="C#" MasterPageFile="~/FinalProject.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Dobachesky_FinalProject.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <ol class="breadcrumb">
                    <li class="active">Home</li>
                </ol>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <h1 runat="server" id="lblArtists" class="center">Artists</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <ul class="pager">
                    <li class="previous">
                        <asp:LinkButton ID="lbtnPrev" runat="server" onClick="previous_Click">Previous</asp:LinkButton>
                    </li>
                    <li class="next">
                        <asp:LinkButton ID="lbtnNext" runat="server" onClick="next_Click">Next</asp:LinkButton>
                    </li>
                </ul>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:Table ID="tblArtists" runat="server" class="table table-hover">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell>Artist Name</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Genre</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Rating</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </div>
        </div>
    </div>
</asp:Content>
